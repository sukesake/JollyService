using System.Web.Http;

namespace OwinTest
{
    public class HealthController : ApiController
    {
        [Route("api/health")]
        public string Get()
        {
            return "I'm Healthy!";
        }
    }
}