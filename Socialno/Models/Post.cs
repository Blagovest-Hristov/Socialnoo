using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Socialno.Models
{
    public class Post
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Content { get; set; }

        [StringLength(200)]
        public string? ImageURL { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        public int Likes { get; set; }


        public virtual ICollection<Comment> Comments { get; set; }
    }
}