using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace JavaScriptImplicitClient_Simple.Api
{
    [Route("api/test")]
    public class TestController : ApiController
    {
        public IHttpActionResult Get()
        {
            var cp = User as ClaimsPrincipal;
            
            var claims = new Dictionary<string, object>();
            var groups =
                from c in cp.Claims
                group c by c.Type into g
                select g;
            foreach(var item in groups)
            {
                if (item.Count() > 1)
                {
                    claims.Add(item.Key, item.Select(x=>x.Value).ToArray());
                }
                else
                {
                    claims.Add(item.Key, item.First().Value);
                }
            }
            
            return Json(new { message = "API called", access_token_claims=claims });
        }
    }
}