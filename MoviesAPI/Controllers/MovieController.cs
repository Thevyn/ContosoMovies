using assignment.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace assignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {

        private readonly MovieService _movieService;


        public MovieController(MovieDbContext movieDbContext)
        {
            _movieService = new MovieService(movieDbContext);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesBySearch(string searchString)
        {
            var _movies = await _movieService.GetMovies();
            if(searchString != null && searchString != "")
            {
               _movies = _movies.Where(s => s.Name.ToLower().Contains(searchString.ToLower()) || s.Director.ToLower().Contains(searchString.ToLower()) || s.ReleaseDate.CompareTo(Convert.ToDateTime(searchString)) == 0);
            }
          
                return Ok(_movies);
            
        }

        [HttpGet(template: "getMovieByGenre")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovieByGenre(string genre)
        {
            var _movies = await _movieService.GetMovies();
            if (!string.IsNullOrWhiteSpace(genre))
            {
                return Ok(_movies.Where(m => m.Genre == genre));
            }
            else
            {
                return Ok(_movies);
            }
        }

        [HttpGet(template:"edit-movie")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            return await _movieService.GetMovie(id);
        }


        [HttpPost("createMovie", Name = "Create a Movie")]
        [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
        public async Task<ActionResult<bool>> Create([FromBody] Movie movie)
        {
            var success = await _movieService.Create(movie);
            return Ok(success);
        }

        [HttpPut(template: "updateMovie")]
        public async Task<ActionResult<bool>> EditMovie([FromBody] Movie movie)
        {
            bool success = await _movieService.UpdateMovie(movie);

            return Ok(success);
        }

        [HttpDelete(template: "deleteById{id}", Name = "Delete movie by id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteMedicine(int id)
        {
            var deleted = await _movieService.DeleteMovie(id);
            if (!deleted)
            {
                return BadRequest();
            }

            return Ok();
        }


    }
}
