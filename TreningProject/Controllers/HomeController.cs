using Microsoft.AspNetCore.Mvc;

namespace TreningProject.Controllers
{
    /// <summary>
    /// ���������� ��� �������������� � ������� ���������
    /// </summary>
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
