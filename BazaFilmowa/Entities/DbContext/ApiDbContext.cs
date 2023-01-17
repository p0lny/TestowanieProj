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



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetSqlConnectionString().ToString());
        }

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

        private SqlConnectionStringBuilder GetSqlConnectionString()
        {
            // Equivalent connection string:
            // "User Id=<DB_USER>;Password=<DB_PASS>;Server=<INSTANCE_HOST>;Database=<DB_NAME>;"
            var connectionString = new SqlConnectionStringBuilder()
            {
                // Note: Saving credentials in environment variables is convenient, but not
                // secure - consider a more secure solution such as
                // Cloud Secret Manager (https://cloud.google.com/secret-manager) to help
                // keep secrets safe.
                DataSource = "34.118.117.72", // e.g. '127.0.0.1'
                // Set Host to 'cloudsql' when deploying to App Engine Flexible environment
                UserID = "api",         // e.g. 'my-db-user'
                Password = "aaabbbccc",       // e.g. 'my-db-password'
                InitialCatalog = "BazaFilmowaDb", // e.g. 'my-database'

                // The Cloud SQL proxy provides encryption between the proxy and instance
                Encrypt = false,
            };
            connectionString.Pooling = true;
            // Specify additional properties here.
            return connectionString;
        }
    }
}
