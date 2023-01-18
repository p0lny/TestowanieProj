using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BazaFilmowa.Entities
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
            // konstruktor potrzebny dla utworzenia inmemorydb dla testów
        }
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<RegistrationToken> RegistrationTokens { get; set; }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieDetails> MovieDetails { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<UserMovieRating> UserMovieRatings { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<MovieToBeWatched> MovieToBeWatched { get; set; }
        public DbSet<MovieWatched> MovieWatched { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<MovieDetails>()
                 .Property(e => e.Id)
                 .ValueGeneratedOnAdd();

            modelBuilder.Entity<Movie>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();



            modelBuilder.Entity<Rating>()
                .HasKey(e => e.MovieId);

            modelBuilder.Entity<UserMovieRating>()
                .HasKey(e => new
                {
                    e.MovieId,
                    e.UserId
                });

            modelBuilder.Entity<MovieGenre>()
                .HasKey(e => new
                {
                    e.MovieId,
                    e.GenreId
                });

            modelBuilder.Entity<MovieToBeWatched>()
                .HasKey(e => new
                {
                    e.MovieId,
                    e.UserId
                });

            modelBuilder.Entity<MovieWatched>()
                 .HasKey(e => new
                 {
                     e.MovieId,
                     e.UserId
                 });


        }

        public static SqlConnectionStringBuilder GetSqlConnectionString()
        {

            var connectionString = new SqlConnectionStringBuilder()
            {

                DataSource = "34.118.117.72",
                UserID = "api",
                Password = "aaabbbccc",
                InitialCatalog = "BazaFilmowaDb",

                Encrypt = false,
            };
            connectionString.Pooling = true;
            return connectionString;
        }
    }
}
