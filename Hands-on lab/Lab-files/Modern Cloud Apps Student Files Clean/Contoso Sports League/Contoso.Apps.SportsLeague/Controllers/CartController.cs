using AutoMapper;
using Contoso.Apps.SportsLeague.Data.Logic;
using Contoso.Apps.SportsLeague.Data.Models;
using Contoso.Apps.SportsLeague.Web.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;

namespace Contoso.Apps.SportsLeague.Web.Controllers
{
    public class CartController : Controller
    {
        public CartController()
        {
            db = new ProductContext();
        }

        private readonly ProductContext db;

        // GET: Cart
        public ActionResult Index()
        {
            var cartId = new Helpers.CartHelpers().GetCartId();
            var vm = new CartModel();
            using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions(cartId))
            {
                var shoppingCartItems = usersShoppingCart.GetCartItems();
                var cartItemsVM = Mapper.Map<List<CartItemModel>>(shoppingCartItems);
                vm.CartItems = cartItemsVM;
                vm.ItemsTotal = usersShoppingCart.GetCount();
                vm.OrderTotal = usersShoppingCart.GetTotal();
            }
            //var shoppingCartItems = db.ShoppingCartItems.Include(c => c.Product);
            return View(vm);
        }

        public RedirectResult AddToCart(int productId)
        {
            var cartId = new Helpers.CartHelpers().GetCartId();
            using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions(cartId))
            {
                usersShoppingCart.AddToCart(productId);
            }
            return Redirect("Index");
        }

        // GET: Cart/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartItem cartItem = db.ShoppingCartItems.Find(id);
            if (cartItem == null)
            {
                return HttpNotFound();
            }
            return View(cartItem);
        }

        // GET: Cart/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "ProductID", "ProductName");
            return View();
        }

        // POST: Cart/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemId,CartId,Quantity,DateCreated,ProductId")] CartItem cartItem)
        {
            if (ModelState.IsValid)
            {
                db.ShoppingCartItems.Add(cartItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "ProductID", "ProductName", cartItem.ProductId);
            return View(cartItem);
        }

        // GET: Cart/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartItem cartItem = db.ShoppingCartItems.Find(id);
            if (cartItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductID", "ProductName", cartItem.ProductId);
            return View(cartItem);
        }

        // POST: Cart/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemId,CartId,Quantity,DateCreated,ProductId")] CartItem cartItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cartItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductID", "ProductName", cartItem.ProductId);
            return View(cartItem);
        }

        // GET: Cart/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartItem cartItem = db.ShoppingCartItems.Find(id);
            if (cartItem == null)
            {
                return HttpNotFound();
            }
            return View(cartItem);
        }

        // POST: Cart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CartItem cartItem = db.ShoppingCartItems.Find(id);
            db.ShoppingCartItems.Remove(cartItem);
            db.SaveChanges();
            return RedirectToAction("Index");
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
