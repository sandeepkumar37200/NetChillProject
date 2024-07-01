using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project.DAL.Domain_Models;

public interface IMovieService {
        Task<bool> AddMovieToUserList(Guid MovieId ,Guid UserId); // ?
        Task<bool> RemoveMovieFromList(Guid MovieId); // ? 
        Task<bool> MovieCreatedByAdmin(Movie movie); // ? add this movie to database 
        Task<UserMovie> GetUserMovie(Guid Id); // ?
        Task<IEnumerable<Movie>> GetUserMovieList(string email);
        Task<IEnumerable<Movie>> GetAllMoviesList();
        Task<IEnumerable<Movie>> GetUpcomingMoviesList();
        Task<IEnumerable<Movie>> GetNewMoviesList();
        Task<IEnumerable<Movie>> GetFeaturedMoviesList();
        Task<Movie> GetMovieById(Guid id);
}