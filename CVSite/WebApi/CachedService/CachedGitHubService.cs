using Microsoft.Extensions.Caching.Memory;
using Service.Classes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.CachedService
{
    public class CachedGitHubService : IGitHubService
    {
        private readonly IGitHubService _gitHubService;
        private readonly IMemoryCache _memoryCache;
        private const string UserPortfolioKey = "UserPortfolioKey";

        public CachedGitHubService(IGitHubService gitHubService, IMemoryCache memoryCache)
        {
            _gitHubService = gitHubService;
            _memoryCache = memoryCache;
        }

        public async Task<List<RepositoryInfo>> GetUserRepositories()
        {
            // 1. מנסה לקבל נתונים מהמטמון. אם נמצא, מחזיר אותם.

            if (!_memoryCache.TryGetValue(UserPortfolioKey, out List<RepositoryInfo> repositoryInfo))
            {
                // 2. אם לא נמצא במטמון, מקבל את הנתונים משירות GitHub האמיתי.
                repositoryInfo = await _gitHubService.GetUserRepositories();

                // 3. מגדיר אפשרויות מטמון (זמן תפוגה מוחלט וחלקי).
                var cacheOption = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(30))
                    .SetSlidingExpiration(TimeSpan.FromSeconds(10));

                // 4. שומר את הנתונים שהתקבלו במטמון.
                _memoryCache.Set(UserPortfolioKey, repositoryInfo, cacheOption);

                // 5. מחזיר את הנתונים (מהשירות או מהמטמון).
                return repositoryInfo;
            }

            return repositoryInfo;
        }
    }
}
