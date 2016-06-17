using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FletNix.Models
{
    public interface IMovieAwardRepository
    {
        void AddMovieAward(MovieAwards movieAward);
    }
}
