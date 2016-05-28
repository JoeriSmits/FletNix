using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FletNix.Models
{
    public interface IWatchHistoryRepository
    {
        bool AddWatchHistory(int movieId, FletNixUser user);
        IEnumerable<Watchhistory> getWatchHistoryByCustomer(string userEmail);
    }
}
