using Microsoft.AspNetCore.Mvc;

namespace TreningProject.Controllers
{
    /// <summary>
    ///  онтроллер дл€ взаимодействи€ с главной страницей
    /// </summary>
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
