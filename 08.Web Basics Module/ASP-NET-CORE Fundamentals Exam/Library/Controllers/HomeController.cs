namespace Library.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}