using AutoMapper;
using MySystem.API.Dtos;
using MySystem.Domain.Entitys;

namespace MySystem.API.Helpers
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<User, UserInsertDto>().ReverseMap();
        }

    }
}
