using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FletNix.Models
{
    public interface IWatchHistoryRepository
    {
        Task<bool> AddWatchHistory(int movieId, FletNixUser user);
        Task<IEnumerable<Watchhistory>> getWatchHistoryByCustomer(string userEmail);
    }
}
