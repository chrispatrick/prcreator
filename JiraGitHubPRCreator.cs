using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JiraGitHubPRCreator
{
    public partial class JiraGitHubPRCreator : Form
    {
        public JiraGitHubPRCreator()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var branch = txtBranchName.Text;
            var jiraBugId = txtJiraBugId.Text;
            var title = txtPrTitle.Text;
            var description = txtLongDescription.Text;
            var personalAccessToken = this.txtPersonalAccessToken.Text;

            var linkedPrCreator = new LinkedPrCreator(personalAccessToken, branch, jiraBugId, title, description, "grantadesign", "mi");

            var branchDefinitions = new List<BranchDefinition>();

            if (chkNext.Checked)
            {
                branchDefinitions.Add(new BranchDefinition("next", "next"));
            }
            if (chk81.Checked)
            {
                branchDefinitions.Add(new BranchDefinition("releases/8.1/next", "8.1"));
            }
            if (chk8.Checked)
            {
                branchDefinitions.Add(new BranchDefinition("releases/8.0/next", "8.0"));
            }
            if (chk7.Checked)
            {
                branchDefinitions.Add(new BranchDefinition("releases/7.0/next", "7.0"));
            }

            linkedPrCreator.MakeLinkedPullRequests(branchDefinitions);
        }
    }
}
