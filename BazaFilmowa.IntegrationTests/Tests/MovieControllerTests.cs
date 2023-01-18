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
using BazaFilmowa.Models;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Authorization.Policy;

namespace BazaFilmowa.IntegrationTests
{
    public class MovieControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private HttpClient _client;
        private DbContext _dbContext;

        public MovieControllerTests(WebApplicationFactory<Startup> factory)
        {
            _client = factory
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var dbContextOptions = services.SingleOrDefault(service => service.ServiceType == typeof(DbContextOptions<ApiDbContext>));
                        services.Remove(dbContextOptions);

                        services.AddSingleton<IPolicyEvaluator, FakePolicyEvaluator>();
                        services.AddMvc(option => option.Filters.Add(new FakeUserFilter()));


                        services.AddDbContext<ApiDbContext>(options => options.UseInMemoryDatabase("TestsDb"));
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

            //act
            var response = await _client.GetAsync("/api/movie?" + queryParams);

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

            //act
            var response = await _client.GetAsync("/api/movie?" + queryParams);

            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }


        [Fact]

        public async Task AddMovie_WithValidModel_ReturnsCreatedStatus()
        {


            //arrange

            var model = new AddMovieDto()
            {
                Title = "Tytuł testowy8888",
                UrlPoster = "test-poster",
                UrlTrailer = "test-trailer"
            };

            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            //act

            var response = await _client.PostAsync("/api/movie", httpContent);

            //assert

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            //response.Headers.Location.Should().NotBeNull();
        }

        [Fact]
        public async Task AddMovie_WithInalidModel_ReturnsBadRequests()
        {
            //arrange

            var model = new AddMovieDto()
            {
                Title = "",
                UrlPoster = "test-poster",
                UrlTrailer = "test-trailer"
            };

            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            //act

            var response = await _client.PostAsync("/api/movie", httpContent);

            //assert

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }


    }
}
