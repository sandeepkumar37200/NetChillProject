using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project.DAL.Domain_Models;
using Project.DAL.UOW;

public class MovieService : IMovieService
{
    private readonly IUnitOfWork _uow;

    public MovieService(IUnitOfWork uow){
        _uow = uow;
    }
    public async Task<bool> AddMovieToUserList(Guid MovieId, Guid UserId)
    {
        _uow.movieRepository.AddMovieToUserList(MovieId, UserId);
      return await   _uow.SaveAsync();
    }

    public async Task<IEnumerable<Movie>> GetAllMoviesList()
    {
        return await _uow.movieRepository.GetAllMoviesList();
    }

    public async Task<IEnumerable<Movie>> GetFeaturedMoviesList()
    {
        return await _uow.movieRepository.GetFeaturedMoviesList();
    }

    public async Task<Movie> GetMovieById(Guid id)
    {
        return await _uow.movieRepository.GetMovieById(id);
    }

    public async Task<IEnumerable<Movie>> GetNewMoviesList()
    {
        return await _uow.movieRepository.GetNewMoviesList();
    }

    public async Task<IEnumerable<Movie>> GetUpcomingMoviesList()
    {
        return await _uow.movieRepository.GetUpcomingMoviesList();
    }

    public async Task<UserMovie> GetUserMovie(Guid Id)
    {
        return await  _uow.movieRepository.GetUserMovie(Id);
    }

    public async Task<IEnumerable<Movie>> GetUserMovieList(string email)
    {
        return await _uow.movieRepository.GetUserMovieList(email);
    }

    public async Task<bool> MovieCreatedByAdmin(Movie movie)
    {
        _uow.movieRepository.MovieCreatedByAdmin(movie);
        return await _uow.SaveAsync();
    }

    public async Task<bool> RemoveMovieFromList(Guid MovieId)
    {
        _uow.movieRepository.RemoveMovieFromList(MovieId);
        return await _uow.SaveAsync();
    }
}