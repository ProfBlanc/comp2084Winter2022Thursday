using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace comp2084Winter2022Thursday.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Username required!")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@".{5, 20}", ErrorMessage = "Custom Regular Expression")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}