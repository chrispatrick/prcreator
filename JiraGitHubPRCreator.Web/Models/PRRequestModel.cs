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
        public bool MIv7 { get; set; }
        public bool MIv80 { get; set; }
        public bool MIv81 { get; set; }
        public bool MIvNext { get; set; }
        public bool AddLinksToJira { get; set; }
        public bool SetJiraIssuePendingMerge { get; set; }
        public IEnumerable<string> Messages { get; set; } 
    }
}