using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using MyProject_Mvc5.x_ar.EntityFramework;

namespace MyProject_Mvc5.x_ar
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(x_arCoreModule))]
    public class x_arDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<x_arDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
