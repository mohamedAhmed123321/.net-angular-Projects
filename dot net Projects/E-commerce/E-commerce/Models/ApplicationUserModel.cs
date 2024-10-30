using System.ComponentModel.DataAnnotations;

namespace E_commerce.Models
{
    public class ApplicationUserModel
    {
        public string? UserId { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="enter valid email")]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
