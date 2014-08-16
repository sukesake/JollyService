using System;
using System.Net;
using System.Net.Http;
using FluentAssertions;
using Microsoft.Owin.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace OwinTest.Tests
{
    [TestClass, TestFixture]
    public class Given_a_valid_request_to_health
    {
        private const string BaseAddress = "http://localhost:9000/";

        [TestMethod, Test]
        public void it_works()
        {
            using (WebApp.Start<Startup>(url: BaseAddress))
            {
                // Create HttpCient and make a request to api/values 
                HttpClient client = new HttpClient();

                var response = client.GetAsync(BaseAddress + "api/health").Result;

                response.StatusCode.Should().Be(HttpStatusCode.OK);
            } 
        }
    }
}