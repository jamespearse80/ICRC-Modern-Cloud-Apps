using Contoso.Apps.SportsLeague.Web.Models;
using System.Web.Mvc;


namespace Contoso.Apps.SportsLeague.Controllers
{
    public class HomeController : Controller {
        public ActionResult Index() {
            //var orderId = 1;
            //var order = new Order();
            //using (var orderActions = new OrderActions(orderId))
            //{
            //    order = orderActions.GetOrder();
            //}

            var vm = new HomeModel();

            return View(vm);
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}