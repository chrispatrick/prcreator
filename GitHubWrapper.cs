using System;
using System.Windows.Forms;
using Octokit;

namespace JiraGitHubPRCreator
{
    internal class GitHubWrapper
    {
        private string currentUsername;
        private readonly GitHubClient client;

        public GitHubWrapper(string personalAccessToken)
        {
            this.client = new GitHubClient(new ProductHeaderValue("mikeparker-testapp"));
            var authToken = new Credentials(personalAccessToken); // ask user to enter this from ui
            this.client.Credentials = authToken;
        }

        public async void CreatePullRequest(string branchToMerge, string prTitleHalfway, string description, string targetUsername, string targetRepository, string targetBranch, string shortTargetBranchName)
        {
            var user = await this.client.User.Current();
            var username = user.Login;

            var headRef = username + ":" + targetRepository + "/" + branchToMerge;
            var baseRef = targetBranch;
            var title = prTitleHalfway + " (" + shortTargetBranchName + ")";
            var newPR = new NewPullRequest(title, headRef, baseRef);
            newPR.Body = description;
            try
            {
                var pullRequest = await this.client.Repository.PullRequest.Create(targetUsername, targetRepository, newPR);
                MessageBox.Show("Success!");
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
                throw;
            }
        }
    }
}