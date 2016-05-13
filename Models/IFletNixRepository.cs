using System.Collections.Generic;

namespace FletNix.Models
{
    public interface IFletNixRepository
    {
        IEnumerable<Genre> GetAllGenres();
    }
}
