using System.ComponentModel.DataAnnotations;
namespace University_CafeteriaTASK6.Models
{
    public class Regester
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
       
    }
}
