using AutoMapper;
using Contoso.Apps.Common.Extensions;
using Contoso.Apps.SportsLeague.Data.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Contoso.Apps.SportsLeague.Web.Controllers
{
    public class StoreController : Controller
    {
        public StoreController()
        {
            db = new ProductContext();
        }

        private readonly ProductContext db;

        // GET: Store
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category);
            var productsVm = Mapper.Map<List<Models.ProductListModel>>(products);

            // Retrieve category listing:
            var categories = db.Categories.ToList();
            var categoriesVm = Mapper.Map<List<Models.CategoryModel>>(categories);

            var vm = new Models.StoreIndexModel
            {
                Products = productsVm,
                Categories = categoriesVm
            };

            return View(vm);
        }

        // GET: Store/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            var productVm = Mapper.Map<Models.ProductModel>(product);

            // Find related products, based on the category:
            var relatedProducts = db.Products.Where(p => p.CategoryID == product.CategoryID && p.ProductID != product.ProductID).ToList();
            var relatedProductsVm = Mapper.Map<List<Models.ProductListModel>>(relatedProducts);

            // Retrieve category listing:
            var categories = db.Categories.ToList();
            var categoriesVm = Mapper.Map<List<Models.CategoryModel>>(categories);

            // Retrieve "new products" as a list of three random products not equal to the displayed one:
            var newProducts = db.Products.Where(p => p.ProductID != product.ProductID).ToList().Shuffle().Take(3);

            var newProductsVm = Mapper.Map<List<Models.ProductListModel>>(newProducts);

            var vm = new Models.StoreDetailsModel
            {
                Product = productVm,
                RelatedProducts = relatedProductsVm,
                NewProducts = newProductsVm,
                Categories = categoriesVm
            };

            return View(vm);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
