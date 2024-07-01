using System;
using AutoMapper;
using Project.API.Dtos;
using Project.DAL.Domain_Models;

namespace Project.API.Profiles
{
	public class MovieProfile : Profile
	{
		public MovieProfile()
		{
			CreateMap<MovieReqDto, Movie>().ReverseMap();
			CreateMap<Movie, MovieResDto>().ReverseMap();
			CreateMap<Movie, MovieDetailsResDto>().ReverseMap();
		}
	}
}

