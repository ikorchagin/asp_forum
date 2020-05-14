using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspForum.Context.Entities
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime PostDate { get; set; } = DateTime.Now;

        public List<Comment> Comments { get; set; }

        public int RubricId { get; set; }
        public Rubric Rubric { get; set; }

    }
}
