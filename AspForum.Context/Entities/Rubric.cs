using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspForum.Context.Entities
{
    public class Rubric
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Text { get; set; }

        public List<Article> Articles { get; set; } = new List<Article>();
    }
}