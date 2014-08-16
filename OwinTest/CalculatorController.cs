using System.Collections.Generic;
using System.Web.Http;

namespace OwinTest
{
    [RoutePrefix("api/calculator")]
    public class CalculatorController : ApiController
    {
        [Route("add/{a:double}/{b:double}")]
        [HttpGet]
        public double Add(double a, double b)
        {
            return a + b;
        }

        [Route("divide/{dividend:double}/{divisor:double}")]
        [HttpGet]
        public double Divide(double dividend, double divisor)
        {
            return dividend / divisor;
        }

    }
}