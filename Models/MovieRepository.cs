using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace FletNix.Models
{
    public class MovieRepository : IMovieRepository
    {
        private FletNixContext _context;

        public MovieRepository(FletNixContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Movie>> GetMovies(int from, int amount)
        {
            IQueryable<Movie> query = _context.Movie.AsNoTracking();
            return await query.Skip(from).Take(amount).ToListAsync();
        }

        public async Task<bool> RemoveMovieById(int movieId)
        {
            try
            {
                _context.Movie.RemoveRange(_context.Movie.Where(x => x.movie_id == movieId));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Movie> GetMostPopulairMovies()
        {
            IQueryable<Movie> query = _context.Movie.AsNoTracking();
            return query.Join(
                _context.Watchhistory
                    .GroupBy(w => w.movie_id)
                    .Select(m => new { amount = m.Count(), mID = m.Key })
                    .OrderByDescending(a => a.amount)
                    .Take(6)
                    .Select(a => new { movieid = a.mID }),
                m => m.movie_id, w => w.movieid, (m, w) => m)
                .ToList();
        }

        public async Task<IEnumerable<Movie>> GetMovieByTitle(string title, int from)
        {
            ConnectionMultiplexer connection = ConnectionMultiplexer.Connect("fletnix-joeri.redis.cache.windows.net,abortConnect=false,ssl=true,password=ckAqRLLYXfjVBFZXI63ZQ8pQkBzKBLibbNp1JO0PV9M=");
            IDatabase cache = connection.GetDatabase();

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                TypeNameHandling = TypeNameHandling.All
            };

            var key = title + from;
            string value = cache.StringGet(key);
            if (value == null)
            {
                IQueryable<Movie> query = _context.Movie.AsNoTracking();
                value =
                    JsonConvert.SerializeObject(
                        await query.Where(m => m.title.Contains(title)).Skip(from).Take(10).ToListAsync(), settings);
                cache.StringSet(key, value);

                return await query.Where(m => m.title.Contains(title)).Skip(from).Take(10).ToListAsync();
            }
            else
            {
                return JsonConvert.DeserializeObject<IEnumerable<Movie>>(cache.StringGet(key), settings);
            }
        }

        public async Task<IEnumerable<Movie>> GetMovieInfoById(int movieId)
        {
            IQueryable<Movie> query = _context.Movie.AsNoTracking();
            return await query.Where(m => m.movie_id == movieId)
                .Include(m => m.Movie_Director).ThenInclude(d => d.person)
                .Include(m => m.Movie_Genre).ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetAllMovieInfoById(int movieId)
        {
            IQueryable<Movie> query = _context.Movie.Where(t => t.movie_id == movieId).AsNoTracking();
            return await query.Include(t => t.Movie_Cast).Include(t => t.Movie_Director).Include(t => t.Movie_Genre).ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetMovieById(int movieId)
        {
            IQueryable<Movie> query = _context.Movie.AsNoTracking();
            return await query.Where(m => m.movie_id == movieId).ToListAsync();
        }

        public async Task<bool> userWatchedMovie(int movieId, string userEmail)
        {
            IQueryable<Watchhistory> query = _context.Watchhistory.AsNoTracking();
            return await query.AnyAsync	(w => (w.movie_id == movieId)
                    && (w.customer_mail_address == userEmail));
        }

        public async Task AddMovie(Movie movie)
        {
            _context.Add(movie);
            await _context.SaveChangesAsync();
        } 
    }
}
