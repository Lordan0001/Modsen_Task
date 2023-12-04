using Library.Application.Interfaces;
using Library.Domain;
using Library.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Library.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly MainDbContext _mainDbContext;
        private readonly IConfiguration _configuration;

        public UserRepository(MainDbContext mainDbContext, IConfiguration configuration)
        {
            _mainDbContext = mainDbContext;
            _configuration = configuration;
        }

       

        public List<User> GetAllUsers()
        {
            return _mainDbContext.Users.ToList();
        }

        public Tokens Login(User user)
        {

           var userExist =  _mainDbContext.Users.FirstOrDefault(b => b.UserEmail == user.UserEmail);

            if(userExist == null)
            {
                return null;
            }

            //Generate JSON Web Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
             new Claim(ClaimTypes.Email, user.UserEmail)
              }),
                Expires = DateTime.UtcNow.AddMinutes(40),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };
        }
    

        public User Registration(User user)
        {
           _mainDbContext.Users.Add(user);
           _mainDbContext.SaveChanges();
           return user;
        }
    }
}
