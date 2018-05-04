using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    // 自己创建
   public class MyProjectEntityBase<TPrimaryKey> : Entity<TPrimaryKey>
    {
        // ?? EntityBase<TPrimaryKey> : Entity<TPrimaryKey> 
        // 继承，必须类继承类，集合继承集合吗？ < > 代表什么？范型吗
        //  EntityBase : Entity<TPrimaryKey>  错误的 abstract

        // https://aspnetboilerplate.com/Pages/Documents/EF-Core-MySql-Integration

        //https://www.cnblogs.com/1zhk/p/5329393.html
    }
}
