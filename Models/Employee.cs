using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;



namespace OneToOneRelation.Models
{
    public class Employee
    {

        [Required]
        public int Id { get; set; }


        [Required(ErrorMessage = "The Name is required")]
        [StringLength(50, ErrorMessage = "The name cannot exceed 50 characters")]
        public string Name { get; set; }


        //  [Required(ErrorMessage = "Destination is required")]
        public string Destination { get; set; } = "Chennai";


        [Required(ErrorMessage = "The hired date is required")]
        public DateTime HireDate { get; set; }


        public char DelStatus { get; set; } = 'A';

        

        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department dept { get; set; }

        public List<Skill> Skills { get; set; }
    }
}
