using AutoMapper;
using WebAPIDemo1.Models;
using WebAPIDemo1.Dtos;

namespace WebAPIDemo1.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LaptopCreateDto, Laptop>();
            //CreateMap<LaptopCreateDto, Laptop>().ReverseMap();
        }
    }
}
