using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace FletNix.Models
{
    public interface IFletNixRepository
    {
        IEnumerable<Genre> GetAllGenres();
    }
}
