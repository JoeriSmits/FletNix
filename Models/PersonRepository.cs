using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace FletNix.Models
{
    public class PersonRepository : IPersonRepository
    {
        private FletNixContext _context;

        public PersonRepository(FletNixContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> getAllPersons()
        {
            return await _context.Person.Take(500).ToListAsync();
        }
    }
}
