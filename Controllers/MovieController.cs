using Microsoft.AspNetCore.Mvc;
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
        private readonly IMovieContext _movieContext;

        public MovieController(IMovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            return Ok(_movieContext.GetMovies());
        }

        [HttpGet]
        public IActionResult GetMovieGenres()
        {
            return Ok(_movieContext.GetGenres());
        }


    }
}
