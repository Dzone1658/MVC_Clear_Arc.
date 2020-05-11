using System.Collections.Generic;
using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class ProductService : Profile, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            CreateMap<ProductCategoryViewModel, Product > ( ).ReverseMap( );
            _productRepository = productRepository;
        }

        public List<Product> GetProductCategory()
        {
            var list = _productRepository.GetProductCategory( );
            //if ( list != null && list.Count > 0 )
            //    return AutoMapper.Mapper.Map<List<Product>, List<ProductCategoryViewModel>/*, List<Product>*/>( list );
            //else
            //    return List<ProductCategoryViewModel>( );

            return list;
        }
    }
}
