using MovieAPI.Services.DALModels;
using System.Collections.Generic;

namespace MovieAPI.Services
{
    public interface IMovieContext : IGetMovies, IGetGenres, IGetRandomMovies, IGetRandomGenre
    {
    }

    public interface IGetMovies
    {
        IEnumerable<Movie> GetMovies();
    }
    public interface IGetGenres
    {
        IEnumerable<Movie> GetGenres();
    }
    public interface IGetRandomMovies
    {
        Movie GetRandomMovie(string Title);
    }
    public interface IGetRandomGenre
    {
        Movie GetRandomGenre(string Genre);
    }







}
