using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FletNix.Models;

namespace FletNix.ViewModels
{
    public class NewMovieModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Publication_year { get; set; }
        public int Previous_part { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Url { get; set; }
        public int Minimum_age { get; set; }
        public string[] SubmitGenres { get; set; } 
        public IEnumerable<Genre> genres { get; set; }
        public string[] Directors { get; set; }
        public IEnumerable<Person> ListOfPeople { get; set; }
        public string[] Cast { get; set; }
        public IEnumerable<Movie> movie { get; set; } 
    }
}
