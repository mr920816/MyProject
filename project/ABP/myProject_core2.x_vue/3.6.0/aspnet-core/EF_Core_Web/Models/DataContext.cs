using EF_Core_Web.Models.cengJi;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace EF_Core_Web.Models
{
    //   [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class DataContext : DbContext
    {


        public DataContext(DbContextOptions<DataContext> options)
                : base(options)
        {
            //this.Database.EnsureCreated();
        }




        // 注册依赖注入
        // 服务（例如：Context）在应用程序启动期间通过依赖注入进行注册
        // 需要这些服务的组建（例如：MVC控制器）然后通过构造函数参数或属性提供这些服务

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseMySQL("server=localhost;port=3306;database=my_test;user=root;password=123456;");

            //}

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API
            modelBuilder.Ignore<Flag>(); // 排除类型
            modelBuilder.Entity<Grade>() // 排除属性
                .Ignore(b => b.Other2);
            //modelBuilder.Entity<Department>() //主键
            //    .HasKey(c => c.Id);
            //modelBuilder.Entity<Company>() //复合主键
            // .HasKey(c => new { c.Code, c.Name });




            modelBuilder.Entity<Person>()
                .Property<string>("flag"); //新增字段
                                           // 继承
                                           //modelBuilder.Entity<Student>().HasBaseType<Person>();


            // modelBuilder.Entity<Teacher>()
            // .Property(p => p.JobName)
            //.HasDefaultValue("老师"); // 默认值


            //  值转换
            modelBuilder.Entity<Teacher>()
                .Property(e => e.Mount)
               .HasConversion(v => v.ToString(), v => (EquineBeast)Enum.Parse(typeof(EquineBeast), v));

            // 数据设定 Data  Seeding
            modelBuilder.Entity<School>().HasData(
                new School { Id = 1, Name = "小学", Code = "小学" },
                 new School { Id = 2, Name = "中学", Code = "中学" });

            modelBuilder.Entity<Course>().HasData(
               new Course { Id = 1, Name = "语文" },
                new Course { Id = 2, Name = "数学" },
                  new Course { Id = 3, Name = "英语" }
                );

            modelBuilder.Entity<Grade>().HasData(
                new Grade { Id = 1, Name = "一年级", Code = "一年级", SId = 1 },
                 new Grade { Id = 2, Name = "二年级", Code = "二年级", SId = 1 },
                 new Grade { Id = 3, Name = "初一", Code = "初一", SId = 2 },
                 new Grade { Id = 4, Name = "初二", Code = "初二", SId = 2 });


            modelBuilder.Entity<Student>().HasData(
                 new Student { Id = 1, Name = "小明", Address = "花果山", GradeId = 1 },
                 new Student { Id = 2, Name = "张三", Address = "上海", GradeId = 1 },
                 new Student { Id = 3, Name = "李四", Address = "上海", GradeId = 1 },
                  new Student { Id = 4, Name = "王二", Address = "上海", GradeId = 2 });

            modelBuilder.Entity<StudentParent>().HasData(
               new StudentParent { Id = 5, Name = "小明他爹", stuId = 1 },
               new StudentParent { Id = 7, Name = "张三他妈", stuId = 2 },
               new StudentParent { Id = 8, Name = "李四他爹", stuId = 3 });

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { Id = 1, Name = "老师A", GradeId = 1, EnglishName = "zhangsan", Mount = EquineBeast.Donkey },
                new Teacher { Id = 2, Name = "老师B", GradeId = 1, EnglishName = "wanger" },
                new Teacher { Id = 3, Name = "老师C", GradeId = 2, Mount = EquineBeast.Horse });


            modelBuilder.Entity<Score>().HasData(
             new Score { Id = 1, scoreSize = 50, CourseId = 1, StuId = 1 },
               new Score { Id = 2, scoreSize = 60, CourseId = 2, StuId = 1 },
                 new Score { Id = 3, scoreSize = 70, CourseId = 3, StuId = 1 },
                   new Score { Id = 4, scoreSize = 80, CourseId = 1, StuId = 2 },
               new Score { Id = 5, scoreSize = 90, CourseId = 3, StuId = 2 }
              );



            // 计算列
            //modelBuilder.Entity<Teacher>()
            //        .Property(p => p.DisplayName)
            //        .HasComputedColumnSql(" CONCAT(`Name`,`EnglishName`)");

            //序列
            //modelBuilder.HasSequence<int>("OrderNumbers", schema: "my_test")
            //   .StartsAt(100).HasMin(100).HasMax(10000)
            //.IncrementsBy(5);

            //modelBuilder.Entity<Teacher>()
            //    .Property(o => o.Age)
            //    .HasDefaultValueSql("NEXT VALUE FOR my_test.OrderNumbers");

            // 全局过滤器

            // modelBuilder.Entity<School>().Property<string>("TenantId").HasField("_tenantId");
            //  modelBuilder.Entity<School>().HasQueryFilter(p => EF.Property<int>(p, "Id") == 1);

        }





        public DbSet<A> A { get; set; }
        public DbSet<B> B { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<StudentParent> StudentParent { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }

        public DbSet<Grade> Grade { get; set; }
        public DbSet<School> School { get; set; }
        public DbSet<Course> Course { get; set; }

        // 包括类型和排除类型
        //约定        
        // 包括模型中的类型意味着EF具有关于该类型的元数据，并且将尝试从数据库读取/写入实例
        // 一，在您的上下文中包含在您的上下文中的DBSet 属性中的类型包含在类型中，Person
        // 二，OnModelCreating() 方法
        // 三，通过递归探索发现的导航属性类型 ，Department dept 
        //数据注释
        // 使用数据注释从模型排除类型 [NotMapped]
        // Fluent API 可用于从模型中排除类型

        // 包含属性排除属性

        //密钥（主） Keys(primary)
        //约定
        //按照约定，属性名为Id 或<type name>Id 将配置为实体的键
        //例如：string Id ,CarId
        //数据注释
        //数据注释可用于配置要作为键的实体的单个属性 [Key]
        //Flunt API .HasKey(c => c.Id)
        //复合主键 .HasKey{c=>c.id,c.code}

        //生成的值 Generated Values
        // 值生成模式
        // 1.没有值生成
        // 2.在生成的值添加
        // 3.生成的值在添加或更新
        // 约定
        // 按照约定,将设置类型short、int、long、guid 的复合主键以在ADD上生成值。所有其他属性都将设置为无值生成。
        // 数据注释
        // 没有值生成（数据注释）
        // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        // 在生成的值添加（数据注释）
        // [DatabaseGenerated(DatabaseGeneratedOptoin.Identity)]
        // 在生成的值将添加或更新（数据注释）
        // [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        // Fluent API 可用于更改给定属性的值生成模式
        // 没有值生成
        // .Property(p=> p.id).ValueGeneratedNever();
        //生成的值添加 .ValueGeneratedOnAdd();
        //生成的值添加或更新 .ValueGeneratedOnAddOrUpdate();

        // 必须和可选属性 Required and Optional Properties
        // [Required]  .Property(p=> p.id).IsRequired();

        // 最长长度 Maximum Length

        // 并发令牌 Concurrency Tokens (没做过测试)


        //   阴影属性
        //      指NET 实体类中未定义的属性，但针对EF 核心模型中该实体类型定义的。这些属性的值和状态仅在变化跟踪中
        //      保持。它们常用于外键属性。

        //   关系
        //  关系定义了两个实体将互相关联起来
        //   术语的定义：主体实体；依赖的实体；外键；主体的密钥；导航属性；集合导航属性；引用导航属性；反向导航属性。
        //    HasOne或HasMany 标识你正在开始配置的实体类型上的导航属性。然后链接到调用withone 或withMany 来标识反向导航。Hasone/withone 用于引用导航属性，hasmany/withmany用于集合导航属性


        // 继承 Inheritance 
        // EF 模型中的继承用于控制数据库中如何表示实体类中的继承
        // 约定：可以通过：符号来实现，
        // Fluent API: modelBuilder.Entity<Student>().HasBaseType<Person>();

        // 支持字段 Backing Fields
        // 支持字段允许EF 读取和/或写入一个字段，而不是一个属性。
        // 当在类中的封装被用来限制使用和/或增强应用程序代码访问数据的语义时，这可能时有用的，但是应该在不使用这些限制/增强的情况下从数据库读取或写入该值

        // 值转换

        // 数据播种
        // 允许提供初始数据填充数据库

        // 实体类型构造函数





        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //   {
        //      base.OnConfiguring(optionsBuilder);
        //     optionsBuilder.UseMySQL("server=localhost;port=3306;database=my_test;user=root;password=123456;");//配置连接字符串
        //}


    }
}
