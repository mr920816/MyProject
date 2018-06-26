using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Core_Web.Models
{
    public class Department
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        // 排除类型
        public Flag flag { get; set; }

        // 排除属性
        [NotMapped]
        public string Other1 { get; set; }

        // 排除属性
        
        public string Other2 { get; set; }
    }

    //[NotMapped]
    public class Flag
    {

        public string target { get; set; }
    }

}
