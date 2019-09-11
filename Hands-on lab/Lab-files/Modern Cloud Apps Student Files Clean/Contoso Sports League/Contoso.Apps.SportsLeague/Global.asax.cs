using AutoMapper;
using Contoso.Apps.SportsLeague.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Contoso.Apps.SportsLeague.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Initialize the product database.
            Database.SetInitializer(new ProductDatabaseInitializer());

            // Automapper configuration.
            // Products:
            Mapper.CreateMap<Data.Models.Product, Models.ProductModel>();
            Mapper.CreateMap<IList<Data.Models.Product>, IList<Models.ProductModel>>();
            // Product list (subset of full product data):
            Mapper.CreateMap<Data.Models.Product, Models.ProductListModel>();
            Mapper.CreateMap<IList<Data.Models.Product>, IList<Models.ProductListModel>>();
            // Cart Items:
            Mapper.CreateMap<Data.Models.CartItem, Models.CartItemModel>();
            Mapper.CreateMap<IList<Data.Models.CartItem>, IList<Models.CartItemModel>>();
            // Categories:
            Mapper.CreateMap<Data.Models.Category, Models.CategoryModel>();
            Mapper.CreateMap<IList<Data.Models.Category>, IList<Models.CategoryModel>>();
            // Orders:
            Mapper.CreateMap<Data.Models.Order, Models.OrderModel>();
            Mapper.CreateMap<IList<Data.Models.Order>, IList<Models.OrderModel>>();
            Mapper.CreateMap<Models.OrderModel, Data.Models.Order>();
        }
    }
}
