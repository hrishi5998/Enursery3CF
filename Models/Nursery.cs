using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Enursery3ccf.Models
{
    public class Nursery
    {
        [Key]
        public int NurseryId { get; set; }

        [Required(ErrorMessage = "Nursery Username required"), MaxLength(20)]
        public string NUserName { get; set; }

        [Required(ErrorMessage = "Full Nursery Name required"), MaxLength(20)]
        public string NurseryName { get; set; }

        [Required(ErrorMessage = "Please enter city location"), MaxLength(20)]
        public string Location { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Enter total working hours")]
        [Range(1,24,ErrorMessage = "Out of range. Select between 1 to 24")]
        public int TotalWorkHours { get; set; }

        [Required(ErrorMessage = "Please enter contact")]
        public long ContactNo { get; set; }
    }
}