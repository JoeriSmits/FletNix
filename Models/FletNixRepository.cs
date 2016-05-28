using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace FletNix.Models
{
    public class FletNixRepository : IFletNixRepository
    {
        private FletNixContext _context;

        public FletNixRepository(FletNixContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _context.Genre.OrderBy(t => t.genre_name).ToList();
        }
    }
}
