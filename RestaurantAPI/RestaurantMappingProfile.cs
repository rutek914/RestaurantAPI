using AutoMapper;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;

namespace RestaurantAPI
{
    public class RestaurantMappingProfile : Profile
    {
        public RestaurantMappingProfile()
        {
            // Restaurant -> RestaurantDto
            // city pochodzenia restaurantDTO mapuj z source.Address.City
            CreateMap<Restaurant, RestaurantDto>()
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street))
                .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode));

            CreateMap<Dish, DishDto>();

            // CreateRestaurantDto -> Restaurant
            CreateMap<CreateRestaurantDto, Restaurant>()
                .ForMember(r => r.Address, c => c.MapFrom(dto => new Address()
                {
                    City = dto.City,
                    PostalCode = dto.PostalCode,
                    Street = dto.Street
                }));
        }
    }
}
