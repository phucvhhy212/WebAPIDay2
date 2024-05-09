using AutoMapper;
using Infrastructure;
using WebAPI.Models;

namespace WebAPI
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Person, PersonRequestModel>().ReverseMap();
        }
    }
}
