using System.Collections.Generic;
using System.Linq;

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

        // public SaveGenre(Genre object)
        // {
        //     _context.Database.BeginTransaction();
        //     _context.Genre.Update(object);
        //     _context.SaveChanges();
        //     _context.Database.CommitTransaction();
        // }
    }
}
