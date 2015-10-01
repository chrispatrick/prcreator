namespace JiraGitHubPRCreator.Core.GitHub
{
    public class BranchDefinition
    {
        private readonly string branch;
        private readonly string shortBranchName;

        public BranchDefinition(string branch, string shortBranchName)
        {
            this.branch = branch;
            this.shortBranchName = shortBranchName;
        }

        public string Branch
        {
            get { return this.branch; }
        }

        public string ShortBranchName
        {
            get { return this.shortBranchName; }
        }
    }
}