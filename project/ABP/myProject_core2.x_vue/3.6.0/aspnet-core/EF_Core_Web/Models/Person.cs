using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Core_Web.Models
{




    public class Person
    {
        // 在生成的值添加
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

     


        [Required]
        //[ConcurrencyCheck]
        public string Name { get; set; }
        //public int Age { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        // 没有值生成
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Remark { get; set; }

        // 在生成的值将添加或更新
        // [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastUpdated { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //public DateTime Created { get; set; }



        //[NotMapped]
        //public Department dept { get; set; }


        //[Required]
       

    }
}
