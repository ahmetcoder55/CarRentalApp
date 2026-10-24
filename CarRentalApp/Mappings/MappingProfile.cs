using AutoMapper;
using CarRentalApp.Dtos;
using CarRentalApp.Models;

namespace CarRentalApp.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<Car, CreateCarDto>().ReverseMap();
        }
    }
}
