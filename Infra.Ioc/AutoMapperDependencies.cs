using Application.ViewModels;
using AutoMapper;
using Domain.Models;

namespace Infra.Ioc
{
    public class AutoMapperDependencies : Profile
    {
        public AutoMapperDependencies()
        {
            CreateMap<ProductCategoryViewModel, Product>( ).ReverseMap( );
        }
    }
}
