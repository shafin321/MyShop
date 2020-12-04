using MyShop.Core.Contracts;
using MyShop.Core.Model;
using MyShop.Data.InMemory;
using MyShop.DataAccess.Sql;
using MyShop.Services;
using System;

using Unity;

namespace MyShop.WebUI
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {

            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();

            //container.RegisterType<IRepository<Product>, InMemoryRepository<Product>>();
            //container.RegisterType<IRepository<ProductCategory>, InMemoryRepository<ProductCategory>>();

            container.RegisterType<IRepository<Product>, SqlRepository<Product>>();
            container.RegisterType<IRepository<ProductCategory>, SqlRepository<ProductCategory>>();
            container.RegisterType<IRepository<Basket>, SqlRepository<Basket>>();
            container.RegisterType<IRepository<BasketItem>, SqlRepository<BasketItem>>();
            container.RegisterType<IRepository<Customer>, SqlRepository<Customer>>();
            container.RegisterType<IBasketService, BasketService>();
            container.RegisterType<IRepository<Order>, SqlRepository<Order>>();
            container.RegisterType<IOrderService, OrderService>();
        }
    }
}

