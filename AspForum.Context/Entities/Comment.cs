using System;
using System.ComponentModel.DataAnnotations;

namespace AspForum.Context.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Article Article { get; set; }

        [Required]
        public int ArticleId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Text { get; set; }
        
        [Required]
        public DateTime PostDate { get; set; } = DateTime.Now;
    }
}