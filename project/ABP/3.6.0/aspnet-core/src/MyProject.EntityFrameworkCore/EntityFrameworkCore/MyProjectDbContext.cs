using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MyProject.Authorization.Roles;
using MyProject.Authorization.Users;
using MyProject.MultiTenancy;


namespace MyProject.EntityFrameworkCore
{
    public class MyProjectDbContext : AbpZeroDbContext<Tenant, Role, User, MyProjectDbContext>
    {
        /* Define a DbSet for each entity of the application */
        /* Add-Migration InitialCreate    Update-Database –Verbos */




        public virtual  DbSet<Student.Student> Student { get; set; }
         public virtual DbSet<Student.School> School { get; set; }

         public MyProjectDbContext(DbContextOptions<MyProjectDbContext> options)
             : base(options)
         {
         }
     }
 }
