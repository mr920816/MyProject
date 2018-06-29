using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Core_Web.Models
{
    public class Student : Person
    {
        public string Hobby { get; set; }

        private string _other;
        public string Other { get => _other; set => _other = value; }

        public int GradeId { get; set; }

        [ForeignKey("GradeId")]
        public Grade Grade { get; set; }

     

       



        public ICollection<Score> Score { get; set; }




    }
   
}
