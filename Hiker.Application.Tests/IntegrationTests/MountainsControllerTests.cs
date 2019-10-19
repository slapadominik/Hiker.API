using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Threading.Tasks;
using FluentAssertions;
using Hiker.API.DTO.Resource.Briefs;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Hiker.Application.Tests.IntegrationTests
{
    [TestFixture]
    public class MountainsControllerTests
    {
        private APIWebApplicationFactory _factory;
        private HttpClient _client;

        [OneTimeSetUp]
        public void GivenARequestToTheController()
        {
            _factory = new APIWebApplicationFactory();
            _client = _factory.CreateClient();
        }

        [Test]
        public async Task GetAllBrief_ShouldReturnAllMountainBriefsFromDatabase()
        {
            //Act
            var result = await _client.GetAsync("/api/mountains");
            
            //Assert
            var mountains = await result.Content.ReadAsAsync<List<MountainTrailBriefResource>>();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Content.Headers.ContentType.MediaType.Should().Be("application/json");
            mountains.Should().NotBeNull();
        }
    }
}