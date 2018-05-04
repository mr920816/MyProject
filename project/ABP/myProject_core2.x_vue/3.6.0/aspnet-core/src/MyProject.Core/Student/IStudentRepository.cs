using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Student
{
    public interface IStudentRepository : IRepository<Student>
    {
        // IRepository接口
        // 针对 Student实体的仓储接口声明 IRepository<Student>
        // 如果实体 Id 数据类型不是 int , 你可以继承 IRepository<TEntity,TPrimaryKey> 接口
        // ： IRepository<TEntity,TPrimaryKey>

       // 定义仓储接口
        List<Student> GetAllWithStudent(int? id, string name);
    }
}
