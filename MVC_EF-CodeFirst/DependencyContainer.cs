using System.Web.Mvc;
using Autofac;
using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infra.Data.Repository;
using Infra.Data.Context;
using Autofac.Integration.Mvc;

namespace MVC
{
    public static class DependencyContainer
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder( );
            builder.RegisterControllers( typeof( MvcApplication ).Assembly );
            builder.RegisterType<EfDbContext>( );

            //Application Layer
            builder.RegisterType<ProductService>( ).As<IProductService>( ).InstancePerRequest();
            builder.RegisterType<ProductRepository>( ).As<IProductRepository>( ).InstancePerRequest();

            builder.RegisterType<CategoryService>( ).As<ICategoryService>( ).InstancePerRequest();
            builder.RegisterType<CategoryRepository>( ).As<ICategoryRepository>( ).InstancePerRequest();


            var container = builder.Build( );
            DependencyResolver.SetResolver( new AutofacDependencyResolver( container ) );
        }
    }
}
