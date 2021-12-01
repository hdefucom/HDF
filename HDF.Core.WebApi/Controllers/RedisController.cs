using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.Core.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RedisController : ControllerBase
    {


        private IDistributedCache _Cache;

        /// <summary>
        ///   构造注入
        /// </summary>
        /// <param name="cache"></param>
        public RedisController(IDistributedCache cache)
        {
            _Cache = cache;
        }



        [HttpGet]
        public string Get(string key)
        {

            var bytes = _Cache.Get(key);

            var res = Encoding.UTF8.GetString(bytes);
            return res;
        }

        [HttpGet]
        public void Set(string key, string value)
        {

            var res = Encoding.UTF8.GetBytes(value);
            _Cache.Set(key, res);

        }


        [HttpGet]
        public async Task<string> GetAsync(string key)
        {

            var bytes = await _Cache.GetAsync(key);

            var res = Encoding.UTF8.GetString(bytes);
            return res;
        }


        [HttpGet]
        public async Task SetAsync(string key, string value)
        {

            var res = Encoding.UTF8.GetBytes(value);
            await _Cache.SetAsync(key, res);
        }






    }
}
