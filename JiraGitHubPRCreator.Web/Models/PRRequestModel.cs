using System.Collections.Generic;

namespace JiraGitHubPRCreator.Web.Models
{
    public class PRRequestModel
    {
        public IEnumerable<string> Branches { get; set; } 
        public string BranchName { get; set; }
        public string JiraIssueId { get; set; }
        public string PullRequestTitle { get; set; }
        public string Description { get; set; }
        public string[] TargetBranches { get; set; }
        public bool AddLinksToJira { get; set; }
        public bool SetJiraIssuePendingMerge { get; set; }
        public IEnumerable<string> Messages { get; set; }
        public string Repository { get; set; }
        public IEnumerable<string> Repositories { get; set; }
        public IEnumerable<string> AvailableTargetBranches { get; set; }
    }
}