using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace TandemIntegrationTest
{
    public class UserAPIIntegrationTest : IClassFixture<WebApplicationFactory<TandemAssesment.Startup>>
    {
        private HttpClient Client { get; }

        public UserAPIIntegrationTest(WebApplicationFactory<TandemAssesment.Startup> fixture)
        {
            Client = fixture.CreateClient();
        }

        [Fact]
        public async Task Get_Should_Fail_Retrieval()
        {
            var response = await Client.GetAsync("/api/user/idontexist@not.com");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        [Fact]
        public async Task Save_And_Retrieval()
        {
            // Arrange
            var request = new
            {
                Url = "/api/user",
                Body = new
                {
                    FirstName = "First",
                    MiddleName = "Middle",
                    LastName = "Last",
                    PhoneNumber = "1234567080",
                    EmailAddress = "Test@test.com",
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();
            var search = await Client.GetAsync("/api/user/Test@test.com");

            // Assert
            response.EnsureSuccessStatusCode();
            search.StatusCode.Should().Be(HttpStatusCode.OK);


        }
        
    }
}