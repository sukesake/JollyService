using System;
using System.Net;
using System.Net.Http;
using FluentAssertions;
using Microsoft.Owin.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OwinTest;

namespace OwinTest.Tests
{
    [TestClass, TestFixture]
    public class Given_a_valid_request_to_Divide
    {
        private const string BaseAddress = "http://localhost:9000/";

        [TestMethod, Test]
        public void when_dividing_possitive_ints_then_success_is_returned()
        {
            using (WebApp.Start<Startup>(url: BaseAddress))
            {
                // Create HttpCient and make a request to api/values 
                HttpClient client = new HttpClient();

                var response = client.GetAsync(BaseAddress + "api/calculator/divide/10/2").Result;

                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        [TestMethod, Test]
        public void when_dividing_possitive_ints_then_the_result_is_as_expected()
        {
            using (WebApp.Start<Startup>(url: BaseAddress))
            {
                // Create HttpCient and make a request to api/values 
                HttpClient client = new HttpClient();

                var response = client.GetAsync(BaseAddress + "api/calculator/divide/10/2").Result;

                response.Content.ReadAsStringAsync().Result.Should().Be("5.0");
            }
        }

        [TestMethod, Test]
        public void when_dividing_by_zero_then_bad_request_is_returned()
        {
            using (WebApp.Start<Startup>(url: BaseAddress))
            {
                // Create HttpCient and make a request to api/values 
                HttpClient client = new HttpClient();

                var response = client.GetAsync(BaseAddress + "api/calculator/divide/10/0").Result;

                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }
    }
}
