using System.Security.Claims;
using AspForum.API.ViewModels;
using AspForum.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AspForum.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepo _repo;
        private readonly IConfiguration _conf;

        public UsersController(IUsersRepo repo, IConfiguration conf)
        {
            _repo = repo;
            _conf = conf;
        }

        [HttpGet("{id}")]
        public ActionResult<GetUserViewModel> GetProfile(int id)
        {
            var user = _repo.GetProfile(id);
            return Ok(new GetProfileViewModel(user));
        }

        [HttpPost("login")]
        public ActionResult<GetUserViewModel> GetTest(SetUserViewModel user)
        {
            var token = _repo.GetToken(user.Email, user.Password);
            var userModel = _repo.Authorize(user.Email, user.Password);

            if (token == null)
            {
                return Unauthorized();
            }

            return new GetUserViewModel(userModel, token);
        }

        [Authorize]
        [HttpGet("secret")]
        public ActionResult<string> SecretPage()
        {
            if (User.Identity.IsAuthenticated) 
            {
                return Ok($"U got authorized {User.FindFirst(ClaimTypes.)}");
            }

            return Unauthorized();
        }

    }
}