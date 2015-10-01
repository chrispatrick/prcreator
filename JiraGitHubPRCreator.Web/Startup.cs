using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JiraGitHubPRCreator.Web.Startup))]
namespace JiraGitHubPRCreator.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
