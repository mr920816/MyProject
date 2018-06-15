using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Core_Web.Models
{
    public class Company
    {
        // 复合主键
        [Required]
        [MaxLength(100)]
        public string  Code { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
