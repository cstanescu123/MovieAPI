using MovieAPI.Services.DALModels;
using System.Collections.Generic;

namespace MovieAPI.Services
{
    public interface IMovieContext : IGetMovies, IGetMoviesInGenre, IGetRandomMovieGenre, IAddMovie, IGetRandomMovieList, IGetGenreList, IGetMovieKeyWord, IGetMovie
    {
    }

    public interface IGetMovies
    {
        IEnumerable<MovieTable> GetMovies();
    }

    public interface IGetMovie
    {
        MovieTable GetMovie(int id);
    }

    public interface IGetMoviesInGenre
    {
        IEnumerable<MovieTable> GetMoviesInGenre(string genre);
    }
    public interface IRandomGetMovie
    {
        MovieTable GetRandomMovie();
    }

    public interface IGetRandomMovieGenre
    {
        MovieTable GetRandomMovieInGenre(string genre);
    }

    public interface IAddMovie
    {
        MovieTable AddMovie(MovieTable movie);
    }

    public interface IGetRandomMovieList
    {
        IEnumerable<MovieTable> GetRandomMovieList(int number);
    }

    public interface IGetGenreList
    {
        IEnumerable<string> GetGenreList();
    }

    public interface IGetMovieKeyWord
    {
        IEnumerable<MovieTable> GetMovieByTitleKeyword(string word);
    }

}
