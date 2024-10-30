using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace E_commerce.Models
{
    public class RigesterModel
    {
        [Required(ErrorMessage ="please enter Email")]
        [EmailAddress(ErrorMessage ="please enter valid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage ="please enter password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "please enter First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "please enter Last Name")]
        public string LastName { get; set; }
        [ValidateNever]
        public string ReturnUrl { get; set; }
    }
}
