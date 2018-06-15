using Microsoft.EntityFrameworkCore;

namespace EF_Core_Web.Models
{
    //   [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
                : base(options)
        {

        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API
            modelBuilder.Ignore<Flag>(); // 排除类型
            modelBuilder.Entity<Department>() // 排除属性
                .Ignore(b => b.Other2);
            //modelBuilder.Entity<Department>() //主键
            //    .HasKey(c => c.Id);
            modelBuilder.Entity<Company>() //复合主键
             .HasKey(c => new { c.Code, c.Name });

            modelBuilder.Entity<Person>()
                .Property(p => p.LastUpdated)
                .HasDefaultValueSql(" NOW()");
        }



        public DbSet<Person> Person { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Company> Company { get; set; }

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












        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //   {
        //      base.OnConfiguring(optionsBuilder);
        //     optionsBuilder.UseMySQL("server=localhost;port=3306;database=my_test;user=root;password=123456;");//配置连接字符串
        //}


    }
}
