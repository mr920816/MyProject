using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EF_Core_Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Globalization;
using System.Threading;
using Microsoft.EntityFrameworkCore.Extensions.Internal;

namespace EF_Core_Web.Controllers
{
    public class HomeController : Controller
    {
        // https://www.cnblogs.com/linezero/p/efcorecodefirst.html
        // 控制器需要DataContext 作为构造函数的参数
        // ASP.NET Core 依赖注入将通过构造函数注入DataContext到控制器

        private DataContext _context;
        private DataContext _context1; // 是否可以同时注入多个
        private ILogger _logger;  // , ILogger  logger
        public HomeController(DataContext context, DataContext context1, ILogger<HomeController> logger)
        {
            _context = context;
            _context1 = context1;
            _logger = logger;
        }

        public IActionResult Index()
        {
            // System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("zh-CN", false);
            // 2018-07-01 12:10:00  或者   07-01-2018 11:10:00 am
            try
            {
                // context 新增
                // _context.Person.Add(new Person { Name = "红孩儿", Address = "上海",  deptId = 1 });
                // _context.SuperPerson.Add(new SuperPerson { Name = "悟空", Address = "北京天安门", deptId = 1 });

                //_context.Student.Add(new Student { Name = "悟空", Address = "北京天安门", deptId = 1 });


                // 隐藏属性
                //var per = _context.Person.FirstOrDefault(p=>p.Id==1);               
                //_context.Entry(per).Property("flag").CurrentValue = "故宫";
                //var newper = _context.Person.Where(p => p.Id == 1).Select(p=> new { p.Name,flag= EF.Property<string>(p, "flag") });




                //   _context.Teacher.Add(new Teacher { Name = "悟空",EnglishName="wukong"});
                //_context.Teacher.Add(new Teacher { Name = "李四" });

                //var newper = _context.Teacher.Where(p => p.Id > 0).Select(p => new { p.Name, p.DisplayName });
                var newper = _context.Teacher.Where(p => p.Id > 0);

                int i = newper.Count();
                //_context.Company.Add(new Company { Code = "公司code", Name = "公司name" });
                _context.SaveChanges();
            }

            catch (Exception ex)
            {

            }


            return View();
        }




        public IActionResult About()

        {

            try
            {
                _context.Database.ExecuteSqlCommand(" update person set Name = '连云港冰海' where id=1 ");
                DateTime dd = DateTime.Now;
                ViewData["Message"] = dd;
            }

            catch (DbUpdateConcurrencyException ex)
            {

            }
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
