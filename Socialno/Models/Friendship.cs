using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Socialno.Models
{
    public class Friendship
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FriendshipId { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        
        [Required]
        public string FriendId { get; set; }

        [ForeignKey("FriendId")]
        public virtual User Friend { get; set; }

        [Required]
        public bool IsAccepted { get; set; }
       
    }
}
