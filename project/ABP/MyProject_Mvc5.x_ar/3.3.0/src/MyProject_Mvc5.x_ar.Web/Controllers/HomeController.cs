using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace MyProject_Mvc5.x_ar.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : x_arControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}