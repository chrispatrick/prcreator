using Octokit;

namespace JiraGitHubPRCreator
{
    public class MikesPullRequest
    {
        private readonly PullRequest pullRequest;
        private readonly string shortBranchName;

        public MikesPullRequest(PullRequest pullRequest, string shortBranchName)
        {
            this.pullRequest = pullRequest;
            this.shortBranchName = shortBranchName;
        }

        public int Number
        {
            get { return pullRequest.Number; }
        }

        public string ShortBranchName
        {
            get { return shortBranchName; }
        }
    }
}