using Repository.Interface;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StackExchange.Redis;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Repository
{
    public class Repository : IRepository
    {
        private IDistributedCache _cache;
        public Repository(IDistributedCache idistributedcache)
        {
            _cache = idistributedcache;
         }
        public async Task<bool> AddUser(UserModel user)
        {
            await _cache.SetStringAsync(user.EmailAddress, JsonSerializer.Serialize<UserModel>(user));
            return true;
        }

        public async Task<UserModel> GetUser(string email)
        {
            var userdata = await _cache.GetAsync(email);
            if (userdata != null) 
            { 
                var user = Encoding.ASCII.GetString(userdata);
                return JsonSerializer.Deserialize<UserModel>(user);
            }
            else
            {
                return null;
            }
        }
      
    }
}
