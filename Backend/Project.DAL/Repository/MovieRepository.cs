using Microsoft.EntityFrameworkCore;
using Project.DAL.Database;
using Project.DAL.Domain_Models;
using Project.DAL.Repository_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context){
            _context = context;
        }
        public void AddMovieToUserList(Guid MovieId, Guid UserId)
        {
            _context.UserMovies.Add(new UserMovie { MovieId = MovieId, UserId = UserId });
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesList()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetFeaturedMoviesList()
        {
            return await _context.Movies.Where(m => m.IsFeatured == true).ToListAsync();
        }

        public async Task<Movie> GetMovieById(Guid id)
        {
            return await _context.Movies.Where(m => m.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Movie>> GetNewMoviesList()
        {
            return await _context.Movies.Where(m => m.AvailableDate.Month + 1 < DateTime.Now.Month).ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetUpcomingMoviesList()
        {
            return await _context.Movies.Where(m => m.YOR.Month > DateTime.Now.Month).ToListAsync();
        }

        public async Task<UserMovie> GetUserMovie(Guid Id)
        {
            return await _context.UserMovies.FindAsync(Id);
        }

        public async Task<IEnumerable<Movie>> GetUserMovieList(string email)
        {
            return await _context.Movies.Where(m => m.UserMovie.Any(u => u.Users.EmailId == email)).ToListAsync();
        }

        public void MovieCreatedByAdmin(Movie movie)
        {
            _context.Movies.Add(movie);
        }

        public async void RemoveMovieFromList(Guid Id)
        {
            var data  =  await _context.UserMovies.FindAsync(Id);
            _context.UserMovies.Remove(data);
        }

    }
}