using Microsoft.EntityFrameworkCore;
using MovieAPI.Services.DALModels;
using System.Collections.Generic;

namespace MovieAPI.Services
{
    public class MovieContext : DbContext, IMovieContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Movie> Genres { get; set; }


        public IEnumerable<Movie> GetGenres()
        {
            return Genres;
        }

        public IEnumerable<Movie> GetMovies()
        {
            return Movies;
        }

        public Movie GetRandomGenre(string Genre)
        {
            throw new System.NotImplementedException();
        }

        public Movie GetRandomMovie(string Title)
        {
            throw new System.NotImplementedException();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=localhost;Initial Catalog=MovieDb;Integrated Security=True");
        }
    }
}
