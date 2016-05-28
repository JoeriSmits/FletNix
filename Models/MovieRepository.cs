using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FletNix.Models
{
    public class MovieRepository : IMovieRepository
    {
        private FletNixContext _context;

        public MovieRepository(FletNixContext context)
        {
            _context = context;
        }
        public IEnumerable<Movie> GetMovies(int from, int amount)
        {
            return _context.Movie.Skip(from).Take(amount).ToList();
        }

        public bool RemoveMovieById(int movieId, int from)
        {
            try
            {
                _context.Watchhistory.RemoveRange(_context.Watchhistory.Where(x => x.movie_id == movieId));
                _context.Movie.RemoveRange(_context.Movie.Where(x => x.movie_id == movieId));
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Movie> GetMostPopulairMovies()
        {
            IQueryable<Movie> query = _context.Movie.AsNoTracking();
            return _context.Movie.Join(
                _context.Watchhistory
                    .GroupBy(w => w.movie_id)
                    .Select(m => new { amount = m.Count(), mID = m.Key })
                    .OrderByDescending(a => a.amount)
                    .Take(6)
                    .Select(a => new { movieid = a.mID }),
                m => m.movie_id, w => w.movieid, (m, w) => m)
                .ToList();
        }

        public IEnumerable<Movie> GetMovieByTitle(string title, int from)
        {
            IQueryable<Movie> query = _context.Movie.AsNoTracking();

            return _context.Movie.Where(m => m.title.Contains(title)).Skip(from).Take(10).ToList();
        }

        public IEnumerable<Movie> GetMovieInfoById(int movieId)
        {
            return _context.Movie.Where(m => m.movie_id == movieId)
                .Include(m => m.Movie_Director).ThenInclude(d => d.person)
                .Include(m => m.Movie_Genre);
        }

        public IEnumerable<Movie> GetMovieById(int movieId)
        {
            return _context.Movie.Where(m => m.movie_id == movieId);
        }

        public bool userWatchedMovie(int movieId, string userEmail)
        {
            return _context.Watchhistory.Count(w => (w.movie_id == movieId)
                    && (w.customer_mail_address == userEmail)) > 0;
        }
    }
}
