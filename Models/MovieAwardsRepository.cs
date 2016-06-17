using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FletNix.Models
{
    public class MovieAwardsRepository : IMovieAwardRepository	
    {
        private FletNixContext _context;

        public MovieAwardsRepository(FletNixContext context)
        {
            _context = context;
        }

        public void AddMovieAward(MovieAwards movieAward)
        {
            _context.MovieAwards.Add(movieAward);
            _context.SaveChanges();
        }
    }
}
