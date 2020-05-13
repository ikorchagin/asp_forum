using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspForum.Context.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime PostDate { get; set; } = DateTime.Now;

        public Article Article { get; set; }
        public int ArticleId { get; set; }
    }
}
