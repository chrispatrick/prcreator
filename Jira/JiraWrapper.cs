using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace JiraGitHubPRCreator.Jira
{
    public class JiraWrapper
    {
        public static async Task<bool> SubmitComment(string issueNumber, string commentString)
        {
            // https://developer.atlassian.com/jiradev/api-reference/jira-rest-apis/jira-rest-api-tutorials/jira-rest-api-example-add-comment
            // https://grantadesign.atlassian.net/rest/api/latest/project/10000
            // https://grantadesign.atlassian.net/rest/api/latest/issue/MI-9111/editmeta/

            var credentials = new NetworkCredential(Constants.UserName, Constants.Password);
            var handler = new HttpClientHandler {Credentials = credentials, PreAuthenticate = true};
            using (var client = new HttpClient(handler))
            {
                var authHeader = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", Constants.UserName, Constants.Password))));
                client.DefaultRequestHeaders.Authorization = authHeader;
                client.BaseAddress = new Uri("https://grantadesign.atlassian.net/rest/api/latest/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jiraComment = new JiraComment { Body = commentString };
                var response = await client.PostAsJsonAsync("issue/" + issueNumber + "/comment", jiraComment);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
        }

        public static async Task<bool> SetPendingMerge(string jiraBugId)
        {
            return false;
            // TODO
        }
    }
}