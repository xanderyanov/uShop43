using Microsoft.AspNetCore.Mvc;

namespace uShop.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View(Data.ExistingTovars);
        }
    }
}
