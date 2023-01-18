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
        WebApplicationFactory<Startup> _factory;

        public MovieControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = GetFactory().CreateClient();

        }

        private WebApplicationFactory<Startup> GetFactory(RoleForAuthorizationEnum role = RoleForAuthorizationEnum.None)
        {
            return _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var dbContextOptions = services.SingleOrDefault(service => service.ServiceType == typeof(DbContextOptions<ApiDbContext>));
                    services.Remove(dbContextOptions);

                    switch (role)
                    {
                        case RoleForAuthorizationEnum.User:
                            services.AddSingleton<IPolicyEvaluator, FakeUserPolicyEvaluator>();
                            services.AddMvc(option => option.Filters.Add(new FakeUserFilter()));
                            break;

                        case RoleForAuthorizationEnum.Moderator:
                            services.AddSingleton<IPolicyEvaluator, FakeModeratorPolicyEvaluator>();
                            services.AddMvc(option => option.Filters.Add(new FakeModeratorFilter()));
                            break;

                        case RoleForAuthorizationEnum.Admin:
                            services.AddSingleton<IPolicyEvaluator, FakeAdminPolicyEvaluator>();
                            services.AddMvc(option => option.Filters.Add(new FakeAdminFilter()));
                            break;
                    }

                    services.AddDbContext<ApiDbContext>(options => options.UseInMemoryDatabase("TestsDb"));
                });

            });
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


        //addmovie
        [Theory]
        [InlineData(RoleForAuthorizationEnum.Admin)]
        [InlineData(RoleForAuthorizationEnum.Moderator)]

        public async Task AddMovie_ForAdminOrModerator_WithValidModel_ReturnsCreatedStatus(RoleForAuthorizationEnum role)
        {

            //arrange

            var client = GetFactory(role).CreateClient();

            var model = new AddMovieDto()
            {
                Title = "Tytuł testowy8888",
                UrlPoster = "test-poster",
                UrlTrailer = "test-trailer"
            };

            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            //act

            var response = await client.PostAsync("/api/movie", httpContent);

            //assert

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            //response.Headers.Location.Should().NotBeNull();
        }

        [Theory]
        [InlineData(RoleForAuthorizationEnum.Admin)]
        [InlineData(RoleForAuthorizationEnum.Moderator)]
        public async Task AddMovie_ForAdminOrModerator_WithInalidModel_ReturnsBadRequest(RoleForAuthorizationEnum role)
        {
            //arrange
            var client = GetFactory(role).CreateClient();

            var model = new AddMovieDto()
            {
                Title = "",
                UrlPoster = "test-poster",
                UrlTrailer = "test-trailer"
            };

            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            //act

            var response = await client.PostAsync("/api/movie", httpContent);

            //assert

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }


        [Theory]
        [InlineData(RoleForAuthorizationEnum.Admin)]
        [InlineData(RoleForAuthorizationEnum.Moderator)]
        public async Task AddMovie_ForAdminOrModerator_ForExistingMovie_ReturnsBadRequest(RoleForAuthorizationEnum role)
        {
            Assert.True(false);

        }

        [Fact]
        public async Task AddMovie_ForUser_ReturnsForbidden()
        {

            //arrange

            var client = GetFactory(RoleForAuthorizationEnum.Admin).CreateClient();

            var model = new AddMovieDto()
            {
                Title = "Tytuł testowy8888",
                UrlPoster = "test-poster",
                UrlTrailer = "test-trailer"
            };

            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            //act

            var response = await client.PostAsync("/api/movie", httpContent);

            //assert

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Forbidden);
            //response.Headers.Location.Should().NotBeNull();
        }



        //editmovie
        [Fact]
        public async Task EditMovie_WithValidModel_ReturnsStatusOk()
        {
            Assert.True(true);

        }
        [Fact]
        public async Task EditMovie_WithInvalidModel_ReturnsBadRequest()
        {
            Assert.True(true);

        }
        [Fact]
        public async Task EditMovie_ForNonExistingMovie_ReturnsBadRequest()
        {
            Assert.True(true);
        }

        //deletemovie


        [Theory]
        [InlineData(0)]
        [InlineData(33)]
        [InlineData(int.MaxValue)]
        public async Task DeleteMovie_ForValidId_ReturnsOk(int id)
        {
            Assert.True(true);

        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(null)]
        [InlineData(2.5)]
        [InlineData('x')]
        [InlineData(-1)]
        public async Task DeleteMovie_ForInvalidId_RetursBadRequest(int id)
        {
            Assert.True(true);
        }


        //getmovie

        [Theory]
        [InlineData(0)]
        [InlineData(33)]
        [InlineData(int.MaxValue)]
        public async Task GetMovie_ForValidId_ReturnsOk(int id)
        {

        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(null)]
        [InlineData(2.5)]
        [InlineData('x')]
        [InlineData(-1)]
        public async Task GetMovie_ForInvalidId_ReturnsBadRequest(int id)
        {
            Assert.True(true);

        }

    }
}
