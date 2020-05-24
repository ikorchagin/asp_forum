using AspForum.Data.Models;

namespace AspForum.API.ViewModels
{
    public class GetRubricViewModel
    {
        public GetRubricViewModel(RubricModel rubric)
        {
            Id = rubric.Id;
            Name = rubric.Name;
        }
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class SetRubricViewModel
    {
        public string Name { get; set; }
    }
}