using Application.ViewModels;
using AutoMapper;
using Domain.Models;

namespace MVC
{
    public class AutoMapperDependencies : Profile
    {
        public AutoMapperDependencies()
        {
            CreateMap<ProductCategoryViewModel, Product>( ).ReverseMap( );
        }
    }
}
