using System.ComponentModel.DataAnnotations;

namespace AlphaShop.Models
{
    public class RegisterModel
    {
        [Required]
        public string? LogUsername { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? ConfirmPassword { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public DateTime? Birthday { get; set; }
        [Required]
        public bool? Gender { get; set; }
        public string? AccessId { get; set; } = "1";
    }
}
