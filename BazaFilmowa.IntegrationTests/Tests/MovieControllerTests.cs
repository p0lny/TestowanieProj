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
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Authorization;
using BazaFilmowa.Services;
using System.Net.Http.Headers;

namespace BazaFilmowa.IntegrationTests
{
    public class MovieControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        WebApplicationFactory<Startup> _factory;


        public MovieControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var dbContextOptions = services.SingleOrDefault(service => service.ServiceType == typeof(DbContextOptions<ApiDbContext>));
                    services.Remove(dbContextOptions);

                    services.AddDbContext<ApiDbContext>(options => options.UseInMemoryDatabase("TestDb"));
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
            var client = _factory.CreateClient();
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
            var client = _factory.CreateClient();

            //act
            var response = await client.GetAsync("/api/movie?" + queryParams);

            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }


        //addmovie
        [Theory]
        [InlineData("Admin")]
        [InlineData("Moderator")]

        public async Task AddMovie_ForAdminOrModerator_WithValidModel_ReturnsStatusCreated(string role)
        {
            //arrange

            var client = _factory.CreateClient();

            var model = new AddMovieDto()
            {
                Title = Guid.NewGuid().ToString(),
                UrlPoster = "test-poster",
                UrlTrailer = "test-trailer"
            };

            var scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();
            var tokenService = scope.ServiceProvider.GetService<IJwtTokenProviderService>();


            var user = FakeUserProvider.GeUserForRole(role);
            var token = tokenService.GetJwtForUser(user);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            //act

            var response = await client.PostAsync("/api/movie", httpContent);

            //assert

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
            response.Headers.Location.Should().NotBeNull();
        }

        [Theory]
        [InlineData("Admin")]
        [InlineData("Moderator")]

        public async Task AddMovie_ForAdminOrModerator_WithInalidModel_ReturnsBadRequest(string role)
        {
            //arrange

            var client = _factory.CreateClient();

            var model = new AddMovieDto()
            {
                Title = "",
                UrlPoster = "test-poster",
                UrlTrailer = "test-trailer"
            };

            var scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();
            var tokenService = scope.ServiceProvider.GetService<IJwtTokenProviderService>();


            var user = FakeUserProvider.GeUserForRole(role);
            var token = tokenService.GetJwtForUser(user);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            //act

            var response = await client.PostAsync("/api/movie", httpContent);

            //assert

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }


        [Theory]
        [InlineData("Admin")]
        [InlineData("Moderator")]
        public async Task AddMovie_ForAdminOrModerator_ForExistingMovieTitle_ReturnsBadRequest(string role)
        {
            //arrange
            var client = _factory.CreateClient();
            var title = "tytuł testowy";

            var movie = new Movie()
            {
                Title = title
            };

            var movieDto = new MovieDto()
            {
                Title = title,
                UrlPoster = "xxx",
                UrlTrailer = "xxx"
            };

            var scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<ApiDbContext>();
            var tokenService = scope.ServiceProvider.GetService<IJwtTokenProviderService>();


            var user = FakeUserProvider.GeUserForRole(role);
            var token = tokenService.GetJwtForUser(user);

            dbContext.Movies.Add(movie);
            dbContext.SaveChanges();

            var json = JsonConvert.SerializeObject(movieDto);
            var httpContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            //act
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.PostAsync("/api/movie", httpContent);

            //assert

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task AddMovie_ForUser_ReturnsForbidden()
        {
            //arrange

            var client = _factory.CreateClient();

            var model = new AddMovieDto()
            {
                Title = "Tytuł testowy8888",
                UrlPoster = "test-poster",
                UrlTrailer = "test-trailer"
            };

            var scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();
            var tokenService = scope.ServiceProvider.GetService<IJwtTokenProviderService>();


            var user = FakeUserProvider.GeUserForRole("User");
            var token = tokenService.GetJwtForUser(user);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            //act

            var response = await client.PostAsync("/api/movie", httpContent);

            //assert

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Forbidden);
        }


        [Fact]
        public async Task AddMovie_ForNoUser_ReturnsUnauthorized()
        {
            //arrange

            var client = _factory.CreateClient();

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

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Unauthorized);
        }

        ////editmovie
        //[Theory]
        //[InlineData(RoleForAuthorizationEnum.Admin)]
        //[InlineData(RoleForAuthorizationEnum.Moderator)]
        //public async Task EditMovie_WithValidModel_ReturnsStatusOk(RoleForAuthorizationEnum role)
        //{
        //    Assert.True(true);

        //}
        //[Theory]
        //[InlineData(RoleForAuthorizationEnum.Admin)]
        //[InlineData(RoleForAuthorizationEnum.Moderator)]
        //public async Task EditMovie_WithInvalidModel_ReturnsBadRequest(RoleForAuthorizationEnum role)
        //{
        //    Assert.True(true);

        //}
        //[Theory]
        //[InlineData(RoleForAuthorizationEnum.Admin)]
        //[InlineData(RoleForAuthorizationEnum.Moderator)]
        //public async Task EditMovie_ForNonExistingMovie_ReturnsBadRequest(RoleForAuthorizationEnum role)
        //{
        //    Assert.True(true);
        //}



        ////deletemovie


        //[Theory]
        //[InlineData(0)]
        //[InlineData(33)]
        //[InlineData(int.MaxValue)]
        //public async Task DeleteMovie_ForValidId_ReturnsOk(int id)
        //{
        //    Assert.True(true);

        //}

        //[Theory]
        //[InlineData(int.MinValue)]
        //[InlineData(null)]
        //[InlineData(2.5)]
        //[InlineData('x')]
        //[InlineData(-1)]
        //public async Task DeleteMovie_ForInvalidId_RetursBadRequest(int id)
        //{
        //    Assert.True(true);
        //}


        ////getmovie

        //[Theory]
        //[InlineData(0)]
        //[InlineData(33)]
        //[InlineData(int.MaxValue)]
        //public async Task GetMovie_ForValidId_ReturnsOk(int id)
        //{

        //}

        //[Theory]
        //[InlineData(int.MinValue)]
        //[InlineData(null)]
        //[InlineData(2.5)]
        //[InlineData('x')]
        //[InlineData(-1)]
        //public async Task GetMovie_ForInvalidId_ReturnsBadRequest(int id)
        //{
        //    Assert.True(true);

        //}
    }
}
