using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Socialno.Models
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public string? SenderId { get; set; }

        [ForeignKey("SenderId")]
        public virtual User Sender { get; set; }
        
        
        public string? RecipientId { get; set; }

        [ForeignKey("RecipientId")]
        public virtual User Recipient { get; set; }

        [Required]
        public bool IsRead { get; set; }
    
    }
}
