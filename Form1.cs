using System;
using System.Windows.Forms;

namespace JiraGitHubPRCreator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var branch = txtBranchName.Text;
            var jiraBugId = txtJiraBugId.Text;
            var title = txtPrTitle.Text;
            var prTitleHalfway = jiraBugId + ": " + title;
            var description = txtLongDescription.Text;
            var personalAccessToken = txtPersonalAccessToken.Text;

            var x = new GitHubWrapper(personalAccessToken);
            if (chkNext.Checked)
            {
                x.CreatePullRequest(branch, prTitleHalfway, description, "grantadesign", "mi", "next", "next");
            }
        }
    }
}
