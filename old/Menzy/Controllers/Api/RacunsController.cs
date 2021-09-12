using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Menzy.Controllers.Api
{
    public class RacunsController : ApiController
    {
        [HttpPost]
        public string Post([FromBody] string value) {
            return value;
            //return "aawfawf";
        }
    }
}
