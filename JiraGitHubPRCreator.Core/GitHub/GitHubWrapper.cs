using System;
using System.Threading.Tasks;
using Octokit;

namespace JiraGitHubPRCreator.Core.GitHub
{
    internal class GitHubWrapper
    {
        private readonly GitHubClient client;
        private readonly IUserNotifier notifier;

        public GitHubWrapper(string personalAccessToken, IUserNotifier userNotifier)
        {
            if (userNotifier == null)
            {
                throw new ArgumentNullException("userNotifier");
            }

            if (string.IsNullOrEmpty(personalAccessToken))
            {
                throw new ArgumentNullException("personalAccessToken");
            }

            this.client = new GitHubClient(new ProductHeaderValue("mikeparker-testapp"));
            var authToken = new Credentials(personalAccessToken); // ask user to enter this from ui
            this.client.Credentials = authToken;
            notifier = userNotifier;
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
                notifier.NotifyUser("Success! Created PR #" + pullRequest.Number + ": " + pullRequest.Title);
                return pullRequest;
            }
            catch (ApiValidationException e)
            {
                notifier.NotifyUser(e.Message + "\n\n" + e.HttpResponse.Body);
                throw;
            }
            catch (Exception)
            {
                notifier.NotifyUser("Error!");
                throw;
            }
        }
    }
}