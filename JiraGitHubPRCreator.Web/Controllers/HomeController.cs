using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Antlr.Runtime;
using JiraGitHubPRCreator.Core.GitHub;
using JiraGitHubPRCreator.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace JiraGitHubPRCreator.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult AuthorizeGitHub()
        {
            return new ChallengeResult("GitHub", Url.Action("Index"));
        }

        public async Task<ActionResult> Index()
        {
            var accessToken = await GetGithubToken();
            if (accessToken == null)
            {
                return AuthorizeGitHub();
            }

            var webUserNotifier = new WebUserNotifier();

            return View(await GetModel(webUserNotifier, null, accessToken));
        }

        public async Task<ActionResult> Submit(PRRequestModel model)
        {
            var accessToken = await GetGithubToken();
            var webUserNotifier = new WebUserNotifier();
            var linkedPrCreator = new LinkedPrCreator(accessToken, model.BranchName, model.JiraIssueId, model.PullRequestTitle, model.Description, "grantadesign", "mi", webUserNotifier);

            var branchDefinitions = CreateBranchDefinitions(model.TargetBranches);

            await linkedPrCreator.MakeLinkedPullRequests(branchDefinitions, model.AddLinksToJira, model.SetJiraIssuePendingMerge);

            return View("Index", await GetModel(webUserNotifier, model, accessToken));
        }

        private static List<BranchDefinition> CreateBranchDefinitions(IEnumerable<string> targetBranches)
        {
            var regex = new Regex(@"releases/(?<version>\S+)/next", RegexOptions.Compiled);

            return targetBranches.Select(branch => regex.IsMatch(branch) ? new BranchDefinition(branch, regex.Match(branch).Groups["version"].Value) : new BranchDefinition(branch, branch)).ToList();
        }

        private async Task<PRRequestModel> GetModel(WebUserNotifier webUserNotifier, PRRequestModel model, string accessToken)
        {
            if (model == null)
            {
                model = new PRRequestModel();
            }

            var username = await GetGithubUserName();

            var branchFetcher = new BranchFetcher(webUserNotifier);
            var branches = await branchFetcher.GetAllBranchNames(accessToken, username, "mi");
            var availableTargetBranches = await branchFetcher.GetAllBranchNames(accessToken, "grantadesign", "mi");

            var repositoryFetcher = new RepositoryFetcher(webUserNotifier);
            var repositories = await repositoryFetcher.GetAllRepositoryNames(accessToken, "grantadesign");

            model.Repositories = repositories;
            model.Repository = "mi";

            model.Branches = branches;
            model.AvailableTargetBranches = availableTargetBranches;
            model.Messages = webUserNotifier.Messages;

            return model;
        }

        private async Task<string> GetGithubToken()
        {
            var authenticateResult = await HttpContext.GetOwinContext().Authentication.AuthenticateAsync("ExternalCookie");
            if (authenticateResult != null)
            {
                var tokenClaim = authenticateResult.Identity.Claims.FirstOrDefault(claim => claim.Type == "urn:github:token");
                if (tokenClaim != null)
                {
                    return tokenClaim.Value;
                }
            }

            return null;
        }

        private async Task<string> GetGithubUserName()
        {
            var authenticateResult = await HttpContext.GetOwinContext().Authentication.AuthenticateAsync("ExternalCookie");
            if (authenticateResult != null)
            {
                var tokenClaim = authenticateResult.Identity.Claims.FirstOrDefault(claim => claim.Type == "urn:github:username");
                if (tokenClaim != null)
                {
                    return tokenClaim.Value;
                }
            }

            return null;
        }

        public async Task<ActionResult> FetchBranches(string repository)
        {
            var accessToken = await GetGithubToken();
            var username = await GetGithubUserName();

            var branchFetcher = new BranchFetcher(new WebUserNotifier());

            IEnumerable<string> branches;

            try
            {
                branches = await branchFetcher.GetAllBranchNames(accessToken, username, repository);
            }
            catch (Exception)
            {
                return Json(new[] {"Could not fetch branches"});
            }

            return Json(branches.ToArray());
        }
    }
}