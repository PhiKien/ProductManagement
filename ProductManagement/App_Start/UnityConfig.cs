using AutoMapper;
using ProductManagement.AutoMappers;
using ProductManagement.Models;
using ProductManagement.Repository.Implement;
using ProductManagement.Repository.Interface;
using ProductManagement.UnitOfWorks;
using ProductManagement.ViewModels;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace ProductManagement
{
    public static class UnityConfig
    {
        
         //static IMapper mapper;
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            var config = new MapperConfiguration(cfg =>
            {
                //Create all maps here
                cfg.CreateMap<Product, ProductViewModel>();
                cfg.CreateMap<Category, CategoryViewModel>();
                cfg.CreateMap<ProductViewModel, Product>().ConstructUsing(p => new Product(p.ID, p.Name, p.Description, p.NumberInStock, p.CategoryID));
                cfg.CreateMap<CategoryViewModel, Category>().ConstructUsing(c => new Category(c.ID, c.Name));
                //...
            });
            IMapper mapper = config.CreateMapper();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterInstance(mapper);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}