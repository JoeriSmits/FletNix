using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FletNix.Models;

namespace FletNix.ViewModels
{
    public class AwardViewModel
    {
        [Required]
        public string award { get; set; }
        [Required]
        public string result { get; set; }
        [Required]
        public string number_of_awards { get; set; }

        public IEnumerable<Movie> movies { get; set; }
    }
}
