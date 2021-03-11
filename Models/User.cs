using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Enursery3ccf.Models
{
    public class User
    {
        
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please enter first name"), MaxLength(20)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name"), MaxLength(20)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string secret_question { get; set; }

    }
}