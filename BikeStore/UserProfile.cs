using AutoMapper;
using Core.Entities;
using BikeStore.Models;

namespace BikeStore.Classes
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Brand, BrandViewModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<Store, StoreViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Staff, StaffViewModel>().ReverseMap();
            CreateMap<Stock, StockViewModel>().ReverseMap();
            CreateMap<Order, OrderViewModel>().ReverseMap();
            CreateMap<OrderItem, OrderItemViewModel>().ReverseMap();

        }
    }
}
