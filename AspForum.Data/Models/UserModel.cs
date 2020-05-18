using System.Collections.Generic;
using System.Linq;
using AspForum.Context;
using AspForum.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspForum.Data.Models
{
    public class UserModel
    {
        public UserModel(User user)
        {
            if (user == null)
            {
                return;
            }
            Id = user.Id;
            Email = user.Email;
            Password = user.Password;
            Name = user.Name;
            Articles = user.Articles?.Select(article => new ArticleModel(article));
        }

        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public IEnumerable<ArticleModel> Articles { get; set; }
    }
}