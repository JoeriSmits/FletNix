using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FletNix.Models
{
    public class GenreRepository : IGenreRepository
    {
        private FletNixContext _context;

        public GenreRepository(FletNixContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _context.Genre.ToList();
        }

        public async void DeleteGenreByMovieId(int movieId)
        {
            _context.Movie_Genre.RemoveRange(_context.Movie_Genre.Where(t => t.movie_id == movieId));
            await _context.SaveChangesAsync();
        }
    }
}
