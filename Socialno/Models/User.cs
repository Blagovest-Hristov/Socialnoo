using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Socialno.Models
{
    public class User:IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(200)]
        public string AvatarUrl { get; set; }

        public ICollection<Post>? Posts { get; set; }
        
        public ICollection<Comment>? Comments { get; set; }
        
        [MaxLength(150)]
        public string Bio { get; set; }
        
        
    }
}
