using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SecurityApp.Models.ViewsModels
{
    public class ResetPasswordViewModel
    {
 
        public string? code { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and cofirmation password doesn't match.")]
        public string? ConfirmPassword { get; set; }
    }
}
