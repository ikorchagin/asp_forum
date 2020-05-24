using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspForum.Context.Entities;
using AspForum.Context;
using AspForum.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AspForum.Data.Repositories
{
    public interface IUsersRepo : IDisposable
    {
        UserModel Authorize(string email, string password);

        string GetToken(string email, string password);

        string RegisterUser(string email, string password);

        void DeleteUser(int userId);

        UserModel GetProfile(int userId);

    }

    public class UsersRepo : IUsersRepo
    {
        private readonly ForumContext _context;
        private readonly IConfiguration _config;

        public UsersRepo(IConfiguration config, ForumContext context)
        {
            _context = context;
            _config = config;
        }

        public string GetToken(string email, string password)
        {
            var user = GetModel(email, password);
            
            if (user == null)
            {
                return null;
            }

            return GenerateJSONWebToken(user);
        }

        private UserModel GetModel(string email, string password)
        {
            var user = _context.Users?.Where(x => x.Email == email && x.Password == password)?
                .FirstOrDefault();

            if (user.Id <= 0)
            {
                return null;
            }

            return new UserModel(user);
        }

        public void DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.DisposeAsync();
        }

        public UserModel GetProfile(int userId)
        {
            var user = _context.Users.Find(userId);

            if (user.Id <= 0)
            {
                return null;
            }

            return new UserModel(user);
        }

        public string RegisterUser(string email, string password)
        {
            throw new NotImplementedException();
        }

        private string GenerateJSONWebToken(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);

            return encodetoken;
        }

        public UserModel Authorize(string email, string password)
        {
            return GetModel(email, password);
        }
    }
}