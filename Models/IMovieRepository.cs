using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FletNix.Models
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMovies(int from, int amount);
        Task<bool> RemoveMovieById(int movieId);
        IEnumerable<Movie> GetMostPopulairMovies();
        Task<IEnumerable<Movie>> GetMovieByTitle(string title, int from);
        Task<IEnumerable<Movie>> GetMovieInfoById(int movieId);
        Task<IEnumerable<Movie>> GetMovieById(int movieId);
        Task<bool> userWatchedMovie(int movieId, string userEmail);
        Task AddMovie(Movie movie);
        Task<IEnumerable<Movie>> GetAllMovieInfoById(int movieId);
    }
}
