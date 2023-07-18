using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TestProduct.Models
{
    public class UserModel
    {
        [Key]
        [JsonIgnore]
        public int UserId { get; set; }
        [Required(ErrorMessage ="The first name is required.")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="The Last name is required.")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        [Required]
        [Compare("Password",ErrorMessage ="The Password and confirm password must match.")]
        public string ConfirmPassword { get; set; }
        public bool IsActive { get; set; }

        public UserModel()
        {
        }
    }
    
}
