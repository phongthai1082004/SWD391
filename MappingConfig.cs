

using Assignment1.Models;
using Assignment1.Models.DTOs;
using AutoMapper;

namespace Assignment1
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>(); // nếu cần map ngược
        }
    }
}