using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string Username { get; set; }
        
        [Required] 
        // can add more options to validate []
        public string Password { get; set; }
    }
}