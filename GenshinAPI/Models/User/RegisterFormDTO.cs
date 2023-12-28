using System.ComponentModel.DataAnnotations;

namespace GenshinAPI.Models.User
{
    public class RegisterFormDTO
    {
        [Required(ErrorMessage = "Username Manquant"), MinLength(2)]
        public string Username { get; set; }

        [EmailAddress]
        [MaxLength(50)]
        [Required(ErrorMessage = "Email Manquant")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Manquant")]
        [MinLength(4),MaxLength(20)]
        [DataType(DataType.Password)]
        public string MotDePasse { get; set; }
    }
}
