using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HelloWorld.Shared.DTO;
using Xunit;
using FluentAssertions;
using System.Net;

namespace HelloWorld.IntegrationTests
{
    public class CollectionsControllerTests : BaseTest
    {
        private string _baseUrlWithSlash = "api/collections/";

        protected async Task CreateCollectionAsync(string url, CollectionCreateDto dto)
        {
            var response = await _client.PostAsJsonAsync(url, dto);
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetCollections_ShouldReturnListOfCollections()
        {
            await AuthenticateAsync();

            var response = await _client.GetAsync(_baseUrlWithSlash);
            
            response.Should().BeSuccessful();
            (await response.Content.ReadAsAsync<List<CollectionDto>>()).Should().NotBeNull();

        }

        [Fact]
        public async Task GetCollectionById_ShouldReturnCollection()
        {
            await AuthenticateAsync();

            await CreateCollectionAsync(_baseUrlWithSlash,
                new CollectionCreateDto() { Name = "collection", ThemeId = 1 });

            var response = await _client.GetAsync(_baseUrlWithSlash + "1");

            response.Should().HaveStatusCode(HttpStatusCode.OK);
            (await response.Content.ReadAsAsync<CollectionDto>()).Should().NotBeNull();
        }
    }
}