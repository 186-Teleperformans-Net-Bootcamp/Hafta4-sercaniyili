using Hafta4_Sercanİyili.DataAccess;
using Hafta4_Sercanİyili.DTOs;
using Hafta4_Sercanİyili.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System.Text;
using System.Text.Json;

namespace Hafta4_Sercanİyili.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IMemoryCache _memoryCache;
        private readonly IDistributedCache _distributedCache;
        private readonly AppDbContext _appDbContext;

        public UserController(IMemoryCache memoryCache, AppDbContext appDbContext, IDistributedCache distributedCache) =>
            (_memoryCache, _appDbContext, _distributedCache) = (memoryCache, appDbContext, distributedCache);


        //Kullanıcıların hepsini gösteren metod, in memory cache'de varsa oradan erişim yoksa veri tabınından
        //User/Users
        [HttpGet]
        [Route("Users")]
        public async Task<IActionResult> GetAllUsersByMemoryCache()
        {
            const string key = "userList";

            if (!_memoryCache.TryGetValue(key, out List<AppUser> users))
            {
                users = await _appDbContext.Users.ToListAsync();

                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1),
                    SlidingExpiration = TimeSpan.FromSeconds(45),
                    Priority=CacheItemPriority.Normal
                };
                    _memoryCache.Set(key, users, cacheEntryOptions);
            };
            return Ok(users);
        }


        //Kullanıcıların hepsini gösteren metod, disributed cache olarak redis'de varsa oradan erişim yoksa veri tabınından
        //User/Users
        [HttpGet]
        [Route("UsersByRedis")]
        public async Task<IActionResult> GetAllUsersByRedisCache()
        {
            var key = "userList";
            string serializedUsers;

            var users = new List<AppUser>();
            var redisUser = await _distributedCache.GetAsync(key);
            if (redisUser != null)
            {
                serializedUsers = Encoding.UTF8.GetString(redisUser);
                users = JsonSerializer.Deserialize<List<AppUser>>(serializedUsers);
            }
            else
            {
                users = await _appDbContext.Users.ToListAsync();
                serializedUsers = JsonSerializer.Serialize(users);
                redisUser = Encoding.UTF8.GetBytes(serializedUsers);
                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(1))
                    .SetSlidingExpiration(TimeSpan.FromSeconds(30));
                await _distributedCache.SetAsync(key, redisUser, options);
            }
            return Ok(users);
        }

    }


         
}
