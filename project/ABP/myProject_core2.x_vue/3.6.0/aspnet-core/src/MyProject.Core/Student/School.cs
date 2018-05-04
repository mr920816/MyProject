using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Student
{
    public class School : MyProjectEntityBase<int>
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Remark { get; set; }

        public string Other { get; set; }
    }
}
