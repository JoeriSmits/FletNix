using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace FletNix.Models
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetAllGenres();
        void DeleteGenreByMovieId(int movieId);
    }
}
