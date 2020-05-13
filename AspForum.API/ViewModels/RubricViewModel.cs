using AspForum.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspForum.API.ViewModels
{
    public class RubricViewModel
    {
        public RubricViewModel(Rubric rubric)
        {
            Id = rubric.Id;
            Name = rubric.Name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
