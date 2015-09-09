using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Octokit;

namespace JiraGitHubPRCreator
{
    internal class GitHubWrapper
    {
        private readonly GitHubClient client;

        public GitHubWrapper(string personalAccessToken)
        {
            if (string.IsNullOrEmpty(personalAccessToken))
            {
                throw new ArgumentNullException(personalAccessToken);
            }

            this.client = new GitHubClient(new ProductHeaderValue("mikeparker-testapp"));
            var authToken = new Credentials(personalAccessToken); // ask user to enter this from ui
            this.client.Credentials = authToken;
        }

        public async Task<PullRequest> CreatePullRequest(string branchToMerge, string prTitleHalfway, string description, string targetUsername, string targetRepository, string targetBranch, string shortTargetBranchName)
        {
            var user = await this.client.User.Current();
            var username = user.Login;

            var headRef = username + ":" + branchToMerge;
            var baseRef = targetBranch;
            var title = prTitleHalfway + " (" + shortTargetBranchName + ")";
            var newPR = new NewPullRequest(title, headRef, baseRef);
            newPR.Body = description;
            try
            {
                var pullRequest = await this.client.Repository.PullRequest.Create(targetUsername, targetRepository, newPR);
                MessageBox.Show("Success! Created PR #" + pullRequest.Number + ": " + pullRequest.Title);
                return pullRequest;
            }
            catch (Octokit.ApiValidationException e)
            {
                MessageBox.Show(e.Message + "\n\n" + e.HttpResponse.Body);
                throw;
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
                throw;
            }
        }
    }
}