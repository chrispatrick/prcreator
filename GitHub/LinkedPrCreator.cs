using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JiraGitHubPRCreator.Jira;
using Octokit;

namespace JiraGitHubPRCreator
{
    public class LinkedPrCreator
    {
        private readonly string personalAccessToken;
        private readonly string branch;
        private readonly string jiraBugId;
        private readonly string descriptionWithJiraLink;
        private readonly string targetUsername;
        private readonly string targetRepository;
        private readonly string prTitleHalfway;

        public LinkedPrCreator(string personalAccessToken, string branch, string jiraBugId, string title, string description, string targetUsername, string targetRepository)
        {
            this.personalAccessToken = personalAccessToken;
            this.branch = branch;
            this.jiraBugId = jiraBugId;
            this.descriptionWithJiraLink = MakeJIRALink() + "\n\n" + description;
            this.targetUsername = targetUsername;
            this.targetRepository = targetRepository;
            this.prTitleHalfway = jiraBugId + ": " + title;
        }

        // Will place the full description on the first PR in this list, and link to it from the others.
        public async void MakeLinkedPullRequests(List<BranchDefinition> pullRequestDefinitions)
        {
            var gitHubWrapper = new GitHubWrapper(this.personalAccessToken);
            var newPullRequests = new List<MikesPullRequest>();

            foreach (var pullRequestDefinition in pullRequestDefinitions)
            {
                var pullRequest = await MakePullRequest(newPullRequests.FirstOrDefault(), gitHubWrapper, pullRequestDefinition.Branch, pullRequestDefinition.ShortBranchName);
                newPullRequests.Add(new MikesPullRequest(pullRequest, pullRequestDefinition.ShortBranchName));
            }

            JiraWrapper.SubmitComment(jiraBugId, MakeFullJIRAComment(newPullRequests));
        }

        private string MakeFullJIRAComment(List<MikesPullRequest> newPullRequests)
        {
            return string.Join("\n", newPullRequests.Select(MakeOneJIRALineComment));
        }

        private string MakeOneJIRALineComment(MikesPullRequest pr)
        {
            return Constants.GitHubUrl + "/pulls/" + pr.Number + " (" + pr.ShortBranchName + ")";
        }

        private string MakeJIRALink()
        {
            return Constants.JiraUrl + jiraBugId;
        }

        private async Task<PullRequest> MakePullRequest(MikesPullRequest highestBranchPR, GitHubWrapper gitHubWrapper, string targetBranch, string shortTargetBranchName)
        {
            var currentDescription = this.descriptionWithJiraLink;
            if (highestBranchPR != null)
            {
                currentDescription = "See #" + highestBranchPR.Number;
            }

            return await gitHubWrapper.CreatePullRequest(this.branch, this.prTitleHalfway, currentDescription, this.targetUsername, this.targetRepository, targetBranch, shortTargetBranchName);
        }
    }
}