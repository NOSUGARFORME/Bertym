using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bertym.Areas.Identity.Controllers
{
    public class AccountController : Controller
    {
        // GET: AccountController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logout(string x)
        {
            return RedirectToAction("Home", "Index");
        }
    }
}
