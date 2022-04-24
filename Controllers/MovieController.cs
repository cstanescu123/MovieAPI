using Microsoft.AspNetCore.Mvc;
using MovieAPI.Models;
using MovieAPI.Services;
using MovieAPI.Services.DALModels;
using System;
using System.Collections.Generic;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class MovieController : ControllerBase
    {
        private readonly MovieContext _movieContext;

        public MovieController(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            return Ok(_movieContext.GetMovies());
        }


        [HttpGet]
        [Route("Specific-Genre-List")]
        public IActionResult GetMovieRandomGenre([FromQuery] string? genre)
        {
            if (genre != null)
            {
                return Ok(_movieContext.GetMoviesInGenre(genre));
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("Random-Movie")]
        public IActionResult GetRandomMovie()
        {
            return Ok(_movieContext.GetRandomMovie());
        }

        [HttpGet]
        [Route("RandomMovie-RandomGenre")]
        public IActionResult GetRandomMovieInGere([FromQuery] string? genre)
        {
            return Ok(_movieContext.GetRandomMovieInGenre(genre));
        }

        [HttpGet]
        [Route("Genre-List")]
        public IActionResult GetCategoryList()
        {
            return Ok(_movieContext.GetGenreList());

        }

        [HttpGet]
        [Route("Random-Movie-List")]
        public IActionResult GetRandomMovieList([FromQuery] int number)
        {
            return Ok(_movieContext.GetRandomMovieList(number));
        }

        [HttpGet]
        [Route("Keyword Search")]
        public IActionResult GetMovieByKeyWord([FromQuery] string? keyWord)
        {
            return Ok(_movieContext.GetMovieByTitleKeyword(keyWord));

        }

        [HttpGet]
        [Route("{ID}")]
        public IActionResult GetMovie([FromRoute] int ID)
        {
            var movie = _movieContext.GetMovie(ID);

            if (movie != null)
            {
                return Ok(movie);
            }
            return NotFound($"No movie matching the provided student id: {ID}");
        }

        [HttpPost]
        [Route("Add Movie")]
        public IActionResult AddMovie([FromBody] PostMovieRequest postMovieRequest)
        {
            var movie = new MovieTable();
            movie.Title = postMovieRequest.Title;
            movie.Year = postMovieRequest.Year;
            movie.Genre = postMovieRequest.Genre;
            movie.Actor = postMovieRequest.LeadActor;
            movie.Director = postMovieRequest.HeadDirector;

            var dbMovie = _movieContext.AddMovie(movie);
            return Created($"htts://localhost:5001/{dbMovie.ID}", dbMovie);
        }


    }
}
