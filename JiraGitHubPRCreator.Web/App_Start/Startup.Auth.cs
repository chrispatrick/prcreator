﻿using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Owin.Security.Providers.GitHub;

namespace JiraGitHubPRCreator.Web
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType("ExternalCookie");
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ExternalCookie",
                AuthenticationMode = AuthenticationMode.Passive,
                CookieName = ".AspNet.ExternalCookie",
                ExpireTimeSpan = TimeSpan.FromMinutes(5),
            });

            var options = new GitHubAuthenticationOptions
            {
                ClientId = "9b93842bb29d1e80bbb2",
                ClientSecret = "47254d4151ee2e91b9e2a8b841e6458a394847af",
                Provider = new GitHubAuthenticationProvider
                {
                    OnAuthenticated = context =>
                    {
                        context.Identity.AddClaim(new Claim("urn:github:token", context.AccessToken));
                        context.Identity.AddClaim(new Claim("urn:github:username", context.UserName));

                        return Task.FromResult(true);
                    }
                }
            };
            options.Scope.Add("user:email");
            options.Scope.Add("repo");

            app.UseGitHubAuthentication(options);
        }
    }
}