using System.ComponentModel.DataAnnotations;

namespace ProfileMatching.Models.DTOs
{
    public class UpdateUserDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("^(?=.*[A-Z])(?=.*[!@#$%^&*(),.?\":{}|<>])(?=.*[a-z]).{8,}$", ErrorMessage = "Password must be complex")]
        public string Password { get; set; }
        [Required]
        public string Username { get; set; }
        public string? Skills { get; set; }
        public List<Document>? Documents { get; set; }
    }
}
