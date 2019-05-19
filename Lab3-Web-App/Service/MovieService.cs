using Lab3_Web_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3_Web_App.Service
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAll(DateTime? from = null, DateTime? to = null);
        Movie Create(Movie movie);
        Movie Update(int id, Movie movie);
        Movie Delete(int id);
    }

    public class MovieService : IMovieService
    {
        private MoviesDbContext context;
        public MovieService(MoviesDbContext context)
        {
            this.context = context;
        }

        public Movie Create(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Movie Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetAll(DateTime? from = null, DateTime? to = null)
        {
            throw new NotImplementedException();
        }

        public Movie Update(int id, Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
