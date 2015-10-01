using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JiraGitHubPRCreator.Core.GitHub
{
    public class BranchFetcher
    {
        private readonly IUserNotifier userNotifier;

        public BranchFetcher(IUserNotifier userNotifier)
        {
            this.userNotifier = userNotifier;
        }

        public async Task<IEnumerable<string>> GetAllBranchNames(string personalAccessToken, string username, string repository)
        {
            var github = new GitHubWrapper(personalAccessToken, userNotifier);

            return (await github.GetBranches(username, repository)).Select(b => b.Name);
        } 
    }
}
