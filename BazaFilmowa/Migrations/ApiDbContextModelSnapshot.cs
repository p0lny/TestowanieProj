﻿// <auto-generated />
using System;
using BazaFilmowa.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BazaFilmowa.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BazaFilmowa.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommentText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Moderated")
                        .HasColumnType("bit");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PostedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("SpoilerAlert")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("BazaFilmowa.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("BazaFilmowa.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlPoster")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlTrailer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("BazaFilmowa.Entities.MovieDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("AgeRestriction")
                        .HasColumnType("smallint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PremiereDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductionLocation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MovieId")
                        .IsUnique();

                    b.ToTable("MovieDetails");
                });

            modelBuilder.Entity("BazaFilmowa.Entities.MovieGenre", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("MovieGenres");
                });

            modelBuilder.Entity("BazaFilmowa.Entities.MovieToBeWatched", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("MovieToBeWatched");
                });

            modelBuilder.Entity("BazaFilmowa.Entities.MovieWatched", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("MovieWatched");
                });

            modelBuilder.Entity("BazaFilmowa.Entities.Rating", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AverageRating")
                        .HasColumnType("float");

                    b.Property<int>("MovieId1")
                        .HasColumnType("int");

                    b.Property<int>("VotesNumber")
                        .HasColumnType("int");

                    b.HasKey("MovieId");

                    b.HasIndex("MovieId1");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("BazaFilmowa.Entities.RegistrationToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("RegistrationTokens");
                });

            modelBuilder.Entity("BazaFilmowa.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BazaFilmowa.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActivated")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BazaFilmowa.Entities.UserMovieRating", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "UserId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserMovieRatings");
                });

            modelBuilder.Entity("BazaFilmowa.Entities.Comment", b =>
                {
                    b.HasOne("BazaFilmowa.Entities.Movie", "Movie")
                        .WithMany("Comments")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BazaFilmowa.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BazaFilmowa.Entities.MovieDetails", b =>
                {
                    b.HasOne("BazaFilmowa.Entities.Movie", "Movie")
                        .WithOne("MovieDetails")
                        .HasForeignKey("BazaFilmowa.Entities.MovieDetails", "MovieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("BazaFilmowa.Entities.MovieGenre", b =>
                {
                    b.HasOne("BazaFilmowa.Entities.Genre", "Genre")
                        .WithMany("MovieGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BazaFilmowa.Entities.Movie", "Movie")
                        .WithMany("MovieGenres")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("BazaFilmowa.Entities.MovieToBeWatched", b =>
                {
                    b.HasOne("BazaFilmowa.Entities.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BazaFilmowa.Entities.User", "User")
                        .WithMany("MoviesToBeWatched")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BazaFilmowa.Entities.MovieWatched", b =>
                {
                    b.HasOne("BazaFilmowa.Entities.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BazaFilmowa.Entities.User", "User")
                        .WithMany("MoviesWatched")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BazaFilmowa.Entities.Rating", b =>
                {
                    b.HasOne("BazaFilmowa.Entities.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId1")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("BazaFilmowa.Entities.RegistrationToken", b =>
                {
                    b.HasOne("BazaFilmowa.Entities.User", "User")
                        .WithOne("RegistrationToken")
                        .HasForeignKey("BazaFilmowa.Entities.RegistrationToken", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BazaFilmowa.Entities.User", b =>
                {
                    b.HasOne("BazaFilmowa.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BazaFilmowa.Entities.UserMovieRating", b =>
                {
                    b.HasOne("BazaFilmowa.Entities.Movie", "Movie")
                        .WithMany("UserMovieRatings")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BazaFilmowa.Entities.User", "User")
                        .WithOne("UserMovieRating")
                        .HasForeignKey("BazaFilmowa.Entities.UserMovieRating", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BazaFilmowa.Entities.Genre", b =>
                {
                    b.Navigation("MovieGenres");
                });

            modelBuilder.Entity("BazaFilmowa.Entities.Movie", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("MovieDetails");

                    b.Navigation("MovieGenres");

                    b.Navigation("UserMovieRatings");
                });

            modelBuilder.Entity("BazaFilmowa.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("BazaFilmowa.Entities.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("MoviesToBeWatched");

                    b.Navigation("MoviesWatched");

                    b.Navigation("RegistrationToken");

                    b.Navigation("UserMovieRating");
                });
#pragma warning restore 612, 618
        }
    }
}
