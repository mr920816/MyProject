using System;
using Abp.Castle.Logging.Log4Net;
using Abp.Web;
using Castle.Facilities.Logging;
using Abp.WebApi.Validation;
using System.Threading;

namespace MyProject_Mvc5.x_ar.Web
{
    public class MvcApplication : AbpWebApplication<x_arWebModule>
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            AbpBootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(
                f => f.UseAbpLog4Net().WithConfig(Server.MapPath("log4net.config"))
            );

            base.Application_Start(sender, e);

            //try
            //{
            //    //new AbpApiValidationFilter(AbpBootstrapper.IocManager, null).ExecuteActionFilterAsync(null, default(CancellationToken), null);

            //}
            //catch (Exception exception)
            //{
            //    Console.WriteLine(exception);
            //    throw;
            //}
        }
    }
}
