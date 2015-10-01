using System.Linq;
using System.Threading.Tasks;
using System.Web;
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

            var username = await GetGithubUserName();

            var webUserNotifier = new WebUserNotifier();
            var branchFetcher = new BranchFetcher(webUserNotifier);
            var branches = await branchFetcher.GetAllBranchNames(accessToken, username, "mi");

            return View(new PRRequestModel {Branches = branches, Messages = webUserNotifier.Messages});
        }

        public async Task<ActionResult> Submit(PRRequestModel model)
        {
            var accessToken = await GetGithubToken();
            var webUserNotifier = new WebUserNotifier();
            var linkedPrCreator = new LinkedPrCreator(accessToken, model.BranchName, model.JiraIssueId, model.PullRequestTitle, model.Description, "grantadesign", "mi", webUserNotifier);

            var branchDefinitions = new List<BranchDefinition>();

            if (model.MIvNext)
            {
                branchDefinitions.Add(new BranchDefinition("next", "next"));
            }
            if (model.MIv81)
            {
                branchDefinitions.Add(new BranchDefinition("releases/8.1/next", "8.1"));
            }
            if (model.MIv80)
            {
                branchDefinitions.Add(new BranchDefinition("releases/8.0/next", "8.0"));
            }
            if (model.MIv7)
            {
                branchDefinitions.Add(new BranchDefinition("releases/7.0/next", "7.0"));
            }

            await linkedPrCreator.MakeLinkedPullRequests(branchDefinitions, model.AddLinksToJira, model.SetJiraIssuePendingMerge);

            model.Messages = webUserNotifier.Messages;
            return View("Index", model);
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
    }
}