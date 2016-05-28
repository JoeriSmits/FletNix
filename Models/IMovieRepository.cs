using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FletNix.Models
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetMovies(int from, int amount);
        bool RemoveMovieById(int movieId, int from);
        IEnumerable<Movie> GetMostPopulairMovies();
        IEnumerable<Movie> GetMovieByTitle(string title, int from);
        IEnumerable<Movie> GetMovieInfoById(int movieId);
        IEnumerable<Movie> GetMovieById(int movieId);
        bool userWatchedMovie(int movieId, string userEmail);
    }
}
