using AspForum.Data.Models;

namespace AspForum.API.ViewModels
{
    public class GetUserViewModel
    {
        public GetUserViewModel(UserModel user, string token)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            Token = token;
        }
        public int Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Token { get; set; }
    }

    public class GetProfileViewModel
    {
        public GetProfileViewModel(UserModel user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
        }
        public int Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }
    }

    public class SetUserViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }
        
    }
}