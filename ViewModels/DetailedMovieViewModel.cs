using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FletNix.Models;

namespace FletNix.ViewModels
{
    public class DetailedMovieViewModel
    {
        public IEnumerable<Movie> detailedInformation { get; set; } 
        public bool userWatchedMovie { get; set; }
        public IEnumerable<CustomerFeedback> ratings { get; set; } 
    }
}
