using System.ComponentModel.DataAnnotations;

namespace SecurityApp.Models.ViewsModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
