using asp_forum.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_forum.API.ViewModels
{
    public class CommentViewModel
    {
        public CommentViewModel(Comment comment)
        {
            Name = comment.Name;
            Text = comment.Text;
            PostDate = comment.PostDate.ToString("dddd, dd MMMM yyyy HH:mm:ss");
        }

        public string Name { get; }

        public string Text { get; }

        public string PostDate { get; }
    }
}
