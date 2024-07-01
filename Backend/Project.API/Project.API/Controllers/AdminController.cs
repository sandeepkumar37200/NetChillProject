using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Services.Interfaces;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections.Generic;
using Project.API.Dtos;
using Project.API.Errors;
using Microsoft.AspNetCore.Http;
using System.IO;
using Project.DAL.Domain_Models;

namespace Project.API.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;
        private readonly IMovieService _movieService;

        public AdminController(IAccountService accountService , IMapper mapper , IMovieService movieService)
        {
            _mapper = mapper;
            _accountService = accountService;
            _movieService = movieService;
        }


        [HttpGet("usersList")]
        public async Task<IActionResult> GetUsersList()
        {
            return Ok(_mapper.Map<IEnumerable<UserResDto>>(await _accountService.getUsersList()));
        }

        [HttpPut("EditUsersSubscription/{id}")]
        public async Task<IActionResult> EditUsersSubscription(string id)
        {
            if (await _accountService.RevokeSubscription(Guid.Parse(id)))
                return Ok();
            return BadRequest(new ApiError() { ErrorCode=400 , ErrorMessage = "something wrong happened"});
        }


        // POST api/<MoviesController>
        [HttpPost("AddNewMovie"), DisableRequestSizeLimit]
        public async Task<IActionResult> AddNewMovie([FromForm] MovieReqDto movie)
        {
            try
            {

                var newMovie = new Movie()
                {
                    Category = movie.Category,
                    ContentPath = movie.ContentPathFile,
                    MoviesPoster = movie.MoviesPosterFile,
                    IsFeatured = movie.IsFeatured,
                    AvailableDate = movie.AvailabilityDate,
                    Description = movie.Description,
                    Name = movie.Name,
                    YOR = movie.ReleaseYear,
                };

                if (await _movieService.MovieCreatedByAdmin(newMovie))
                {
                    return Ok();
                }
                return BadRequest(new ApiError() { ErrorCode = 404, ErrorMessage = "something wrong happened" });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiError() { ErrorCode = 404, ErrorMessage = "something wrong happened" });
            }
        }

       
    } 
}

