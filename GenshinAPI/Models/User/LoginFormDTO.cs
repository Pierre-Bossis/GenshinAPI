using System.ComponentModel.DataAnnotations;

namespace GenshinAPI.Models.User
{
    public class LoginFormDTO
    {
        [Required]
        [EmailAddress,MaxLength(50)]
        public string Email { get; set; }
        [Required,MinLength(4),MaxLength(20)]
        [DataType(DataType.Password)]
        public string MotDePasse { get; set; }
    }
}
