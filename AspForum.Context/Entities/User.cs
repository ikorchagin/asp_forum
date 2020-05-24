using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AspForum.Context.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public virtual IEnumerable<Article> Articles { get; set; }

        public object Select()
        {
            throw new NotImplementedException();
        }
    }
}