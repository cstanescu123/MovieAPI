using Microsoft.EntityFrameworkCore;
using MovieAPI.Services.DALModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieAPI.Services
{
    public class MovieContext : DbContext
    {
        public DbSet<MovieTable> NewMovies { get; set; }

        public IEnumerable<MovieTable> GetMovies()
        {
            return NewMovies;
        }

        public IEnumerable<MovieTable> GetMoviesInGenre(string genre)
        {
            var movies = new List<MovieTable>(NewMovies);
            var newMovieList = movies.FindAll(movie => genre.ToLower() == movie.Genre.ToLower());
            return newMovieList;
        }


        public MovieTable GetRandomMovie()
        {
            var movies = new List<MovieTable>(NewMovies);
            var random = new Random();
            int index = random.Next(0, movies.Count);
            return movies[index];
        }


        public MovieTable GetRandomMovieInGenre(string genre)
        {
            var movies = new List<MovieTable>(NewMovies);
            var newMovieList = movies.FindAll(movie => genre.ToLower() == movie.Genre.ToLower());
            var random = new Random();
            int index = random.Next(0, newMovieList.Count);
            return newMovieList[index];
        }

        public MovieTable AddMovie(MovieTable movie)
        {
            var movieEntity = NewMovies.Add(movie).Entity;
            SaveChanges();
            return movieEntity;
        }

        public IEnumerable<MovieTable> GetRandomMovieList(int number)
        {
            var randomMovieList = new List<MovieTable>();
            for (int i = 0; i < number; i++)
            {
                randomMovieList.Add(GetRandomMovie());
            }
            return randomMovieList;
        }

        public IEnumerable<string> GetGenreList()
        {
            var genreList = new List<MovieTable>();
            return genreList.Select(movie => movie.Genre);
        }

        public IEnumerable<MovieTable> GetMovieByTitleKeyword(string word)
        {
            return NewMovies.Where(movie => movie.Title.Contains(word));
        }

        public MovieTable GetMovie(int id)
        {
            var movie = NewMovies.Find(id);
            return movie;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=localhost;Initial Catalog=MovieDb;Integrated Security=True");
        }
    }
}
