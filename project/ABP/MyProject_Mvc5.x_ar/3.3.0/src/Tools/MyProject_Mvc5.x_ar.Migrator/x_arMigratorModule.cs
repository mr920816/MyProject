using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using MyProject_Mvc5.x_ar.EntityFramework;

namespace MyProject_Mvc5.x_ar.Migrator
{
    [DependsOn(typeof(x_arDataModule))]
    public class x_arMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<x_arDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}