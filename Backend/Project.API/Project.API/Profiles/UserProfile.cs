using AutoMapper;
using Project.API.Dtos;
using Project.DAL;

namespace Project.API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterReqDto, User>();
            CreateMap<User, UserResDto>();
        }
    }
}
