using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BazaFilmowa.IntegrationTests
{
    public class MovieControllerTests
    {
        [Fact]
        public void GetMovies_WithQueryParams_ReturnsStatusOk()
        {
            //arrange
            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();
            //act
            client.GetAsync("/api/movie/");
            //assert
        }
    }
}
