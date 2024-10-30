using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace E_commerce.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="please enter Email")]
        [EmailAddress(ErrorMessage ="please enter valid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage ="please enter password")]
        public string Password { get; set; }
        [ValidateNever]
        public string ReturnUrl { get; set; }
    }
}
