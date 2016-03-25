using System.ComponentModel.DataAnnotations;

namespace Ddhp.v2016.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
