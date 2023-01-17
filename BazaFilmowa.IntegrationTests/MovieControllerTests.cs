using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using BazaFilmowa.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace BazaFilmowa.IntegrationTests
{
    public class MovieControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private HttpClient _client;

        public MovieControllerTests(WebApplicationFactory<Startup> factory)
        {
            _client = factory
                .WithWebHostBuilder(builder=>
                {
                    builder.ConfigureServices(services =>
                    {
                        var dbContextOptions = services.SingleOrDefault(service => service.ServiceType == typeof(DbContextOptions<ApiDbContext>));                      
                        services.Remove(dbContextOptions);

                        services.AddDbContext<ApiDbContext>(options=> options.UseInMemoryDatabase("TestsDb"));
                    });
                })
                .CreateClient();
        }


        [Theory]
        [InlineData("pageSize=10&pageNumber=1")]
        [InlineData("pageSize=25&pageNumber=2")]
        [InlineData("pageSize=50&pageNumber=3")]
        public async Task GetMovies_WithQueryParams_ReturnsStatusOk(string queryParams)
        {
            //arrange
            var client = _client;

            //act
            var response = await client.GetAsync("/api/movie?" + queryParams);

            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("pageSize=10&pageNumber=1.5")]
        [InlineData("pageSize=10")]
        [InlineData("pageNumber=1")]
        [InlineData("pageSize=23&pageNumber=2")]
        [InlineData("pageSize=10&pageNumber=-2")]
        [InlineData("pageSize=10&pageNumber=null")]
        [InlineData("pageSize=10&pageNumber=")]
        [InlineData("")]
        [InlineData(null)]
        public async Task GetMovies_WithInvalidQueryParams_ReturnsBadRequest(string queryParams)
        {
            //arrange
            var client = _client;

            //act
            var response = await client.GetAsync("/api/movie?" + queryParams);

            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }
    }
}
