using ProductManagement.Repository.Implement;
using ProductManagement.Repository.Interface;
using ProductManagement.UnitOfWorks;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace ProductManagement
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}