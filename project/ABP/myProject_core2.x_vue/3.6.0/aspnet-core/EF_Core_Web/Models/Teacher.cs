using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Core_Web.Models
{
    [Table("t_teacher", Schema = "my_test")]
    public class Teacher
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int GradeId { get; set; }
        [ForeignKey("GradeId")]
        public Grade Grade { get; set; }


        [Required]

        public string Name { get; set; }

        public string EnglishName { get; set; }

        public string DisplayName { get; set; }

        public int Age { get; set; }

        public string JobName { get; set; }

        public EquineBeast Mount { get; set; }
    }

    public enum EquineBeast
    {
        Donkey = 1,
        Mule = 2,
        Horse = 3,
        Unicorn = 4

    }
}
