using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entitymvccrud.Models
{
    public class Employee
    {
    
        public int Id { get; set; }
       [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter email address")]
        [Display(Name = "Email Address")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter phone number")]
        [Display(Name = "Phone Number")]
       // [Phone]
        public int  Mobile_no { get; set; }
        [Required(ErrorMessage = "Please enter your Address")]

        public string Address { get; set; }
        [DataType(DataType.Date)]
        public DateTime EmployeeDate { get; set; }

        public bool Status { get; set; }
        
        public string Gender { get; set; }

    }
}
