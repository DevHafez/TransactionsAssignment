using System.ComponentModel.DataAnnotations;

namespace TransactionsAssignment.Domain.Auth
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
