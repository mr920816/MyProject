using System.Data.Common;
using Abp.Zero.EntityFramework;
using MyProject_Mvc5.x_ar.Authorization.Roles;
using MyProject_Mvc5.x_ar.Authorization.Users;
using MyProject_Mvc5.x_ar.MultiTenancy;

namespace MyProject_Mvc5.x_ar.EntityFramework
{
    public class x_arDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public x_arDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in x_arDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of x_arDbContext since ABP automatically handles it.
         */
        public x_arDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public x_arDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public x_arDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}
