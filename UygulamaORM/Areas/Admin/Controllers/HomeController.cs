using Microsoft.AspNetCore.Mvc;

namespace UygulamaORM.Areas.Admin.Controllers
{
    [Area("Admin")]  //Birden fazla controller varsa ben bu sayfanın admin içerisindeki controller olduğunu belirtmek için bu şekilde yazdım
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
