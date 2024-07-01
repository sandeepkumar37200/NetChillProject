using Project.DAL.Domain_Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repository_Interface
{
    public interface IMovieRepository
    {
        void AddMovieToUserList(Guid MovieId ,Guid UserId); // 
        void RemoveMovieFromList(Guid MovieId); //
        void MovieCreatedByAdmin(Movie movie); // 
        Task<UserMovie> GetUserMovie(Guid Id); // 
        Task<IEnumerable<Movie>> GetUserMovieList(string email);
        Task<IEnumerable<Movie>> GetAllMoviesList();
        Task<IEnumerable<Movie>> GetUpcomingMoviesList();
        Task<IEnumerable<Movie>> GetNewMoviesList();
        Task<IEnumerable<Movie>> GetFeaturedMoviesList();
        Task<Movie> GetMovieById(Guid id);
    }
}
