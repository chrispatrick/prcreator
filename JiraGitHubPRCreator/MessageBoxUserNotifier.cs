using JiraGitHubPRCreator.Core;
using System.Windows.Forms;

namespace JiraGitHubPRCreator
{
    internal class MessageBoxUserNotifier : IUserNotifier
    {
        public void NotifyUser(string message)
        {
            MessageBox.Show(message);
        }
    }
}
