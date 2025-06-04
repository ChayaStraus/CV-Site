using Microsoft.Extensions.DependencyInjection;
using Service.Interfaces;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourNamespace.Services;

namespace Service.Classes
{

    public static class Extensions
    {
        public static void AddGitHubIntegration(this IServiceCollection services, Action<GitHubIntegrationOptions> configuration)
        {
            services.Configure(configuration);
            services.AddScoped<IGitHubService, GitHubService>();
            services.AddScoped<IGitHubSearchService,GitHubSearchService>();

        }
    }
}
