using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using MyProject_Mvc5.x_ar.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace MyProject_Mvc5.x_ar.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<x_ar.EntityFramework.x_arDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "x_ar";
        }

        protected override void Seed(x_ar.EntityFramework.x_arDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}
