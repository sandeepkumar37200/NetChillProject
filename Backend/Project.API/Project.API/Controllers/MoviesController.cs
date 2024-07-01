using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.API.Dtos;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Project.DAL.Domain_Models;
using Project.API.Errors;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project.API.Controllers
{
    
    public class MoviesController : BaseController
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MoviesController(IMovieService movieService, IWebHostEnvironment webHostEnvironment,IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }
        // GET: api/<MoviesController>
        [HttpGet("FeaturedMoviesList")]
        public async Task<IActionResult> GetFeaturedMoviesList()
        { 
            return Ok(_mapper.Map<IEnumerable<MovieResDto> >(await _movieService.GetFeaturedMoviesList()));
        }

        [HttpPost("AddMovieToUserList")]
        public async Task<IActionResult> AddMovieToUserList(AddMovieDto movieItem)
        {
            return Ok(await _movieService.AddMovieToUserList(Guid.Parse(movieItem.MovieId), Guid.Parse(movieItem.UserId)));
        }

        [HttpGet("NewReleaseMovieList")]
        public async Task<IActionResult> GetNewReleaseMovieList() 
        {
            return Ok(_mapper.Map<IEnumerable<MovieResDto>>(await _movieService.GetNewMoviesList()));
        }

        [HttpGet("UpcomingMoviesList")]
        public async Task<IActionResult> GetUpcomingMoviesList() 
        {
            return Ok(_mapper.Map<IEnumerable<MovieResDto>>(await _movieService.GetUpcomingMoviesList()));
        }

        [HttpGet("AllMovieList")]
        public async Task<IActionResult> GetAllMovieList()
        {
            return Ok(_mapper.Map<IEnumerable<MovieResDto>>(await _movieService.GetAllMoviesList()));
        }

        [Authorize]
        [HttpGet("UserMovieList/{email}")]
        public async Task<IActionResult> GetUserMovieList(string email)
        {
            return Ok(_mapper.Map<IEnumerable<MovieResDto>>(await _movieService.GetUserMovieList(email)));
        }

        [EnableCors()]
        [HttpGet("GetMovieById/{id}")]
        public async Task<IActionResult> GetMovieById(string id)
        {
            var movie = await _movieService.GetMovieById(Guid.Parse(id));
            if (movie == null) return BadRequest(new ApiError(400, "movie not exist"));
            return Ok(_mapper.Map<MovieDetailsResDto>(movie));
        }

    }
}
