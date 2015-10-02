using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JiraGitHubPRCreator.Core.GitHub
{
    public class RepositoryFetcher
    {
        private readonly IUserNotifier userNotifier;

        public RepositoryFetcher(IUserNotifier userNotifier)
        {
            this.userNotifier = userNotifier;
        }

        public async Task<IEnumerable<string>> GetAllRepositoryNames(string personalAccessToken, string organisation)
        {
            var github = new GitHubWrapper(personalAccessToken, userNotifier);
            var organisationRepos = await github.GetRepositoriesForOrg(organisation);

            return organisationRepos.Select(r => r.Name);
        } 
    }
}
