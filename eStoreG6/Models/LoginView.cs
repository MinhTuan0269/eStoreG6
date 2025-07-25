using System.ComponentModel.DataAnnotations;

namespace eStoreG6.Models
{
    public class LoginView
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
