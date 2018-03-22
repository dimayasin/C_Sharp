using System.ComponentModel.DataAnnotations;
using System;
using weddingplanner.Models;

namespace WeddingPlanner.Models
{
    public class LoginViewModel : BaseEntity
    {
        [Required]
        [EmailAddress]
        [RegularExpression(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\s*$",
            ErrorMessage = "Please input a valid email address.")]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

}