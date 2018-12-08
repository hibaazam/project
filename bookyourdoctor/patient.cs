//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace bookyourdoctor
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    public partial class patient
    {
        [Required]
        [Display(Name = "Name")]
        [RegularExpression(@"^[a-zA-Z ]*$",
              ErrorMessage = "Invalid characters in Name")]
        public string name { get; set; }


        [Required]
        [Display(Name = "Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string email { get; set; }

        [Required]
        [Display(Name = "Contact Number")]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Contact number is not valid. It should 11 digit")]
        public string contact_number { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6,
           ErrorMessage = "passwords must be a minimum of 6 characters")]
        [Required(ErrorMessage = "Password is Required")]
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [System.ComponentModel.DataAnnotations.Compare("password")]
        [Required(ErrorMessage = "Confirm Password is Required")]
        public string Confirm_password { get; set; }
    }
}
