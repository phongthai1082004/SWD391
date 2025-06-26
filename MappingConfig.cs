

using Assignment1.Models;
using Assignment1.Models.DTOs.User;
using AutoMapper;

namespace Assignment1
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<UserCreateDTO, User>();
            CreateMap<User, UserCreateDTO>(); // nếu cần map ngược
        }
    }
}