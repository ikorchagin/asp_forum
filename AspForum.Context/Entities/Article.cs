using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

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

        public DateTime PostDate { get; set; } = DateTime.Now;

        public IEnumerable<Comment> Comments { get; set; }

        public virtual Rubric Rubric { get; set; }
        public int? RubricId { get; set; }

        public virtual User User { get; set; }
        public int UserId { get; set; }
    }
}