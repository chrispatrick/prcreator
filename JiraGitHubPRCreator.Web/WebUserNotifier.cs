using System.Collections.Generic;
using JiraGitHubPRCreator.Core;

namespace JiraGitHubPRCreator.Web
{
    public class WebUserNotifier : IUserNotifier
    {
        public WebUserNotifier()
        {
            Messages = new List<string>();
        }

        public void NotifyUser(string message)
        {
            Messages.Add(message);
        }

        public IList<string> Messages { get; private set; }
    }
}