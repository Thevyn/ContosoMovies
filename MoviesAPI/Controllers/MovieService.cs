using assignment.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment
{
    public class MovieService
    {
        private readonly MovieDbContext _dbContext;

        public MovieService(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return await _dbContext.Movies.ToListAsync();
        }

        public async Task<bool> Create(Movie movie)
        {

            var exits = _dbContext.Movies.Where(m => m.Name == movie.Name).FirstOrDefault();
            if(exits is null)
            {
                _dbContext.Add(movie);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false; 
            }
        }

        public async Task<Movie> GetMovie(int id)
        {
            Movie movie = await _dbContext.Movies.Where(m => m.Id == id).FirstOrDefaultAsync();

            return movie;
        }

        public async Task<bool> UpdateMovie(Movie updatedMovie)
        {
            var movie = await GetMovie(updatedMovie.Id);
            if (movie is null)
            {
                return false;
            }

            movie.Name = updatedMovie.Name;
            movie.Director = updatedMovie.Director;
            movie.ReleaseDate = updatedMovie.ReleaseDate;
            movie.Cast = updatedMovie.Cast;
            movie.Genre = updatedMovie.Genre;
            movie.Description = updatedMovie.Description;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMovie(int id)
        {
            var movie = await GetMovie(id);
            if (movie is null)
            {
                return false;
            }

            _dbContext.Movies.Remove(movie);
            await _dbContext.SaveChangesAsync();
            return true;

        }
    }


}