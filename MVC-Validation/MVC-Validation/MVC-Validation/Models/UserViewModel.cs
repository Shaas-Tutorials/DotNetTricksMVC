using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using MVC_Validation.CustomValidation;
namespace MVC_Validation.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage="Please Enter Username")]
        [RegularExpression(".+@.+\\..+", ErrorMessage = "Please Enter a correct email")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please Enter FullName")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage="Confirm Password doesn't match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please Enter ContactNo")]
        public string ContactNo { get; set; }

        public string Address { get; set; }

        [ValidateCheckBox(ErrorMessage = "Please Accept Terms")]
        public bool IsTerms { get; set; }
    }
}