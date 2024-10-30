using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CoursesProject.Models
{
    public class RegisterModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [ValidateNever]
        public string ReturnUrl { get; set; }
    }
}
