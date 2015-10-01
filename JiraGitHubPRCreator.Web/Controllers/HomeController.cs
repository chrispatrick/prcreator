using System.Threading.Tasks;
using JiraGitHubPRCreator.Core.GitHub;
using JiraGitHubPRCreator.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace JiraGitHubPRCreator.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Submit(PRRequestModel model)
        {
            var linkedPrCreator = new LinkedPrCreator(model.PersonalAccessToken, model.BranchName, model.JiraIssueId, model.PullRequestTitle, model.Description, "grantadesign", "mi", new WebUserNotifier());

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

            return View("Index");
        }
    }
}