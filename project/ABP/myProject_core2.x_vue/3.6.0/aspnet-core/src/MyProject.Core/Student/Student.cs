using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Student
{
    public class Student : Entity
    {
        public virtual string Name { get; set; }

        public virtual string Address { get; set; }

        public virtual string Phone { get; set; }

        public virtual int Sex { get; set; }

        public virtual int Area { get; set; }
    }
}
