using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EF_Core_Web.Models;

namespace EF_Core_Web.Controllers
{
    public class HomeController : Controller
    {
        // https://www.cnblogs.com/linezero/p/efcorecodefirst.html
        // 控制器需要DataContext 作为构造函数的参数
        // ASP.NET Core 依赖注入将通过构造函数注入DataContext到控制器

        private DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            try
            {
      


                _context.Person.Add(new Person { Name = "王无"});
                _context.Person.Add(new Person { Name = "Jane Doe", LastUpdated = new DateTime(2000, 1, 1) });
                _context.SaveChanges();
                 
            }

            catch (Exception ex)
            {

            }


            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
