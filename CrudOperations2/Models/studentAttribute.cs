using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudOperations2.Models
{
    [MetadataType(typeof(studentAttribute))]
    public partial class student
    {

    }

    public class studentAttribute
    {
        public int idstudent { get; set; }
        //public string Name { get; set; }
        //public string Std { get; set; }
        //public string Phone { get; set; }
        //public string Gender { get; set; }
        //public string Percentage { get; set; }
        //public string hobby { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        [Required]
        public string Std { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [MaxLength(3)]
        [MinLength(1)]
        [RegularExpression("^[0-9]*$", ErrorMessage = " must be numeric")]
        public string Percentage { get; set; }

        [Required]
        public string hobby { get; set; }

        [Required]
        public string userImage { get; set; }

    }
}