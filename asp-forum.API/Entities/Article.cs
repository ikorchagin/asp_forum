using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace asp_forum.API.Entities
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

        public int? RubricId { get; set; }

        [ForeignKey("RubricId")]
        public virtual Rubric Rubric { get; set; }


        public List<Comment> Comments { get; set; } = new List<Comment>();

    }
}
