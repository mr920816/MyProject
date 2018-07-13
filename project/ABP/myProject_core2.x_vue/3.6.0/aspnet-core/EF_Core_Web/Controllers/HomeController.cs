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
using EF_Core_Web.Models.cengJi;

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




                //_context.Teacher.Add(new Teacher { Name = "熊大",EnglishName="wukong"});
                //_context.Teacher.Add(new Teacher { Name = "熊二", EnglishName = "wukong" });
                //_context.Teacher.Add(new Teacher { Name = "李四" });

                //var newper = _context.Teacher.Where(p => p.Id > 0).Select(p => new { p.Name, p.DisplayName });
                //var newper = _context.Teacher.Where(p => p.Id > 0);

                // 查询数据

                //基本查询
                // 加载所有数据
                //var stu1 = _context.Student.ToList();
                // 加载一个实体
                // var stu2 = _context.Student.Single(b => b.GradeId == 1);


                // 加载相关数据
                // 提前加载意味着相关数据作为初始查询的一部分从数据库中加载
                // 显式加载意味着在稍后的时间显式从数据库加载相关数据
                // 延迟加载意味着当访问导航属性时，从数据库中透明的加载相关数据

                // 提前加载,预加载 Eager Loading
                // var stu3 = _context.School.Include(c => (c.Grades as Grade).Students );
                // var stu4 = _context.School.Include("Grade").ToList();
                // 多层次
                //var stu3 = _context.Student
                //  .Include(c =>c.Grade);// .ThenInclude 

                //显式加载                
                //var grade = _context.Grade.Single(p => p.Id == 1);
                //_context.Entry(grade).Collection(b => b.Students).Load();

                //var q1 = _context.Entry(grade).Collection(b => b.Students).Query().Count();
                //var q2 = _context.Entry(grade).Collection(b => b.Students)
                //    .Query().Where(p=>p.Hobby.Contains("打球")); // 过滤实体加载到内存中

                //延迟加载
                // UseLazyLoadingProxies() 
                // ef core 将为任何可覆盖的导航属性启用延迟加载，它必须 Virtual位于可继承的类上
                // .........../

                //跟踪不跟踪
                //  跟踪查询  context.SaveChanges();
                //  无跟踪查询 AsNoTracking() .NoTracking
                //  跟踪行为控制实体框架核心是否将在其变更跟踪器中保留关于实体实例的信息
                //  如果跟踪实体,则在 SaveChange() 中, 实体中检测到的任何更改将被持久的保存到数据库中
                //  实体框架核心还将修复从跟踪查询和先前加载到 DbContext 实例中的实体获得的实体之间的导航属性






                // 原始Sql查询
                //var stu5 = _context.School.FromSql("select * from School ");

                // 异步查询
                // 异步查询避免在数据库中执行查询时阻塞线程。这可以避免冻结客户端应用程序UI。
                // 异步操作还可以增加Web应用程序的吞吐量,其中在数据库操作完成时,可以释放线程来服务其他请求。
                // EF Core 不支持在同一上下文实例上运行多个并行操作。在开始下一步操作之前,你应该始终等待操作完成
                //          这通常是通过 await 在每个异步操作中使用关键字来完成

                // 全局查询过滤器         
                // 软删除，多租户

                //var grade = _context.School;

                // 基本保存

                // 断开连接的实体
                // DbContext 实例将自动跟踪从数据库返回的实体。调用 SaveChanges 时，将检测到对这些实体所做的更改并根据需要更新数据库
                // 有时会使用一个上下文实例查询实体，然后使用其他实例对其进行保存。这通常在“断开连接”的情况下发生
                // EF Core 只能跟踪具有给定主键值的任何实体的一个实例。避免使其成为问题的最佳方法是为每个工作单元使用短生存期的上下文
                // ，以便上下文一开始是空的、向其附加实体、保存这些实体，然后释放并丢弃上下文

                // 标识新实体
                // 客户端标识新实体

                //var entity = new School
                //{

                //    Code = "常德路小学",
                //    Name = "常德路小学",
                //    Grades = new List<Grade>
                //    {
                //        new Grade{ Code="一年级",Name="常德路小学"},
                //        new Grade{ Code="二年级",Name="常德路小学"}
                //    }
                //};
                ////ContextSchool.InsertGraph(_context, entity);
                //ContextSchool.updateGraph(_context, entity);



                // _context.School.Add(  new School() {Name="长寿路小学",Code= "长寿路小学" } );

                //var entity= _context.School.Where(n => n.Code == "长寿路小学").FirstOrDefault();
                // _context.School.Remove(entity);

                //var entity = new School
                //{
                //    Code = "常熟路小学",
                //    Name = "常熟路小学",
                //    Grades = new List<Grade>
                //    {
                //        new Grade{Code="一年级",Name="一年级"},
                //        new Grade{ Code="二年级",Name="二年级"}
                //    }
                //};
                //_context.School.Add(entity);



                //var entity = _context.School.Where(n => n.Code == "长寿路小学").FirstOrDefault();
                //entity.Other = "长寿路幼小2";

                //    var entity = new A
                //    {

                //        aCode = "aa",
                //        aName = "aa",
                //        b = new List<B>
                //        {
                //            new B{ bCode="bb",bName="bb"},
                //            new B{ bCode="cc",bName="cc"}
                //        }
                //    };
                //    _context.A.Add(entity);
                //    _context.SaveChanges();






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

                // Lambda 表达式 
                // 将表达式分配给委托类型
                Func<int, int, int> square = (x, y) => x * y;
                // ViewData["Message"] = square(5, 6);

                // Lambda表达式作为方法参数传递
                // ViewData["Message"] = ShowValue((x, y) => x + y);

                Func<int, int, bool> test2 = (x, y) => x == y;
                // ViewData["Message"] = test2(2,3);

                TestDelegate test3 = n => { string s = n + " world "; s += " 你好！"; return s; };
                // ViewData["Message"] = test3("hello");

                // Lambda 表达式和元组
                var numbers = (1, 2, 3, 4);
                Func<(int, int, int, int), (int, int, int, int)> test4 = (n) => (n.Item1, n.Item2, n.Item3, n.Item4);
                var doubledNumbers = test4(numbers);
                //ViewData["Message"] = "值1：" + numbers + "    值2：" + doubledNumbers;

                // 含标准查询运算符的 Lambda



                





            }

            catch (DbUpdateConcurrencyException ex)
            {

            }
            return View();
        }



        private static async Task<int> showSquares(int number)
        {
            return await Task.Factory.StartNew(x => (int)x * (int)x, number);
        }


        delegate string TestDelegate(string s);
        public string ShowValue(Func<int, int, int> op)
        {
            string msg = "";

            msg += op(5, 6);

            return msg;
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
