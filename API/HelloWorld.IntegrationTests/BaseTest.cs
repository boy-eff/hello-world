using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using HelloWorld.Infrastructure.Data;
using HelloWorld.Shared.DTO;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Xunit;

namespace HelloWorld.IntegrationTests
{
    public class BaseTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        protected readonly HttpClient _client;

        public BaseTest()
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        private async Task Register(string url, RegisterDto registerDto)
        {

            var response = await _client.PostAsJsonAsync(url, registerDto);

            if (!(response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.Conflict))
            {
                throw new HttpRequestException(response.StatusCode.ToString());
            }

        }

        private async Task LoginAndSaveTokenAsync(string url, RegisterDto registerDto)
        {
            var response = await _client.PostAsJsonAsync(url, registerDto);

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", 
                (await response.Content.ReadAsAsync<UserAccessTokenDto>()).Token);

            response.EnsureSuccessStatusCode();
        }

        protected async Task AuthenticateAsync()
        {
            var dto = new RegisterDto() {UserName = "username", Password = "password"};

            await Register("api/account/register", dto);

            await LoginAndSaveTokenAsync("api/account/login", dto);

        }
    }
}