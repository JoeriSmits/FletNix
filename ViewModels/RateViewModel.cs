using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FletNix.Models;

namespace FletNix.ViewModels
{
    public class RateViewModel
    {
        public IEnumerable<Watchhistory> WatchHistories { get; set; }
        public IEnumerable<CustomerFeedback> CustomerFeedback { get; set; } 
    }
}
