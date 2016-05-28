using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FletNix.Models;

namespace FletNix.ViewModels
{
    public class OverviewMovieViewModel
    {
        public IEnumerable<Movie> populairMovies { get; set; } 
        public IEnumerable<Movie> searchedMovies { get; set; } 
    }
}
