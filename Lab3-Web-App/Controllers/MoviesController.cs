using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab3_Web_App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab3_Web_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private MoviesDbContext context;
        public MoviesController(MoviesDbContext context)
        {
            this.context = context;
        }

        //// GET: api/Products
        // [HttpGet]
        // public IEnumerable<Movie> Get()
        // {
        //return context.Movies.Include(m => m.Comments);
        // }


        /// <summary>
        /// Gets all the movies
        /// </summary>
        /// <param name="from"> Optional, filter by minimum DateAdded </param>
        /// <param name="to"> Optional, filter by maximum DateAdded</param>
        /// <returns>A list of Movies </returns>        
        [HttpGet]
        public IEnumerable<Movie> Get([FromQuery]DateTime? from, [FromQuery]DateTime? to)
        {
            IQueryable<Movie> result = context.Movies.Include(m => m.Comments);
            if (from == null && to == null)
            {
                return result;
            }
            if (from != null)
            {
                result = result.Where(m => m.DateAdded >= from);
            }
            if (to != null)
            {
                result = result.Where(m => m.DateAdded <= to);
            }
            List<Movie> SortedList = result.OrderBy(o => o.YearOfRelease).ToList();
            SortedList.Reverse();
            return SortedList;
        }

        // GET: api/Movies/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var existing = context.Movies.FirstOrDefault(movie => movie.Id == id);
            if (existing == null)
            {
                return NotFound();
            }

            return Ok(existing);
        }


        /// <summary>
        /// Add a movie.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /movies
        ///     {{
        ///          "id": 3,
        ///           "title": "The winer",
        ///          "duration": 60,
        ///         "description": "Best of all",
        ///         "genre": "Thriller",
        ///         "yearOfRelease": 2005,
        ///         "director": "Tarantino",
        ///         "dateAdded": "2006-01-02T00:00:00",
        ///         "rating": 9,
        ///         "watched": true,
        ///         "comments": [
        ///         {
        ///             "id": 1,
        ///             "text": "Very good movie ",
        ///             "important": true
        ///         },
        ///         {
        ///             "id": 2,
        ///             "text": "must watch again ",
        ///             "important": true
        ///          }
        ///         ]
        ///        }
        ///</remarks>
        /// <param name="movie">The movie to add.</param>
        [HttpPost]
        public void Post([FromBody] Movie movie)
        {
            //if (!ModelState.IsValid)
            //{

            //}
            context.Movies.Add(movie);
            context.SaveChanges();
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Movie movie)
        {
            var existing = context.Movies.AsNoTracking().FirstOrDefault(f => f.Id == id);
            if (existing == null)
            {
                context.Movies.Add(movie);
                context.SaveChanges();
                return Ok(movie);
            }
            movie.Id = id;
            context.Movies.Update(movie);
            context.SaveChanges();
            return Ok(movie);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = context.Movies.FirstOrDefault(movie => movie.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            context.Movies.Remove(existing);
            context.SaveChanges();
            return Ok();
        }
    }

}
