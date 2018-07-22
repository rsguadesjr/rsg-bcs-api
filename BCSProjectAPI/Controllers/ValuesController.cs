using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BCSProjectAPI.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        [AllowAnonymous]
        [HttpGet]
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Authorize]
        [HttpGet]
        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("api/data/get2")]
        public string Get2()
        {
            return $"Value is 2";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
