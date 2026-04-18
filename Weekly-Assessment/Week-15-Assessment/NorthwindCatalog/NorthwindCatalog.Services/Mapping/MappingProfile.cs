using AutoMapper;
using NorthwindCatalog.Services.DTOs;
using NorthwindCatalog.Services.Models;

namespace NorthwindCatalog.Services.Mapping;

//public class MappingProfile : Profile
//{
//    public MappingProfile()
//    {
//        CreateMap<Category, CategoryDto>()
//            .ForMember(dest => dest.ImageUrl,
//                opt => opt.MapFrom(src => "/images/" + src.CategoryName + ".jpg"));

//        CreateMap<Product, ProductDto>();
//    }
//}
public class MappingProfile : Profile
{
    // Northwind categories are always in this fixed order by CategoryID
    private static readonly Dictionary<int, string> CategoryImages = new()
    {
        { 1, "/images/1.jpeg" },  // Beverages
        { 2, "/images/2.jpeg" },  // Condiments
        { 3, "/images/3.jpeg" },  // Confections
        { 4, "/images/4.jpeg" },  // Dairy Products
        { 5, "/images/5.jpeg" },  // Grains/Cereals
        { 6, "/images/6.jpeg" },  // Meat/Poultry
        { 7, "/images/7.jpeg" },  // Produce
        { 8, "/images/8.jpeg" },  // Seafood
    };

    public MappingProfile()
    {
        CreateMap<Category, CategoryDto>()
            .ForMember(dest => dest.ImageUrl,
                opt => opt.MapFrom(src =>
                    CategoryImages.ContainsKey(src.CategoryId)
                        ? CategoryImages[src.CategoryId]
                        : "/images/1.jpeg")); // fallback

        CreateMap<Product, ProductDto>();
    }
}


