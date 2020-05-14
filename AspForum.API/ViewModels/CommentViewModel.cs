using AspForum.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspForum.API.ViewModels
{
    public class CommentViewModel
    {
        public CommentViewModel(Comment comment)
        {
            Id = comment.Id;
            Name = comment.Name;
            Text = comment.Text;
            PostDate = comment.PostDate.ToString("yyyy-MM-dd");
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public string PostDate { get; set; }
    }
}
