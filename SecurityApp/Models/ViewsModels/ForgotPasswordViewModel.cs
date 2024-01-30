using System.ComponentModel.DataAnnotations;

namespace SecurityApp.Models.ViewsModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
      
    }
}
