using Library.Application.Dto;
using Library.Application.Interfaces;
using Library.Domain;
using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
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

        public async Task<List<User>> GetAllUsers()
        {
            return await _mainDbContext.Users.ToListAsync();
        }

        public async Task<User> Registration(UserDTO userDTO)
        {

            var alredyExistingEmail = await _mainDbContext.Users.FirstOrDefaultAsync(u => u.Email == userDTO.Email);
            if (alredyExistingEmail != null)
            {
                throw new KeyNotFoundException("User with this email already exist!");

            }
            CreatePasswordHash(userDTO.Password, out byte[] passwordHash, out byte[] passwordSalt);
            User user = new User();
            user.Email = userDTO.Email;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _mainDbContext.Users.Add(user);
            await _mainDbContext.SaveChangesAsync();
            return user;


        }
        
        public async Task<String> Login(UserDTO userDTO)
        {
            var existingUser = await _mainDbContext.Users.FirstOrDefaultAsync(u => u.Email == userDTO.Email);

            if (existingUser == null)
            {
                throw new KeyNotFoundException("Check email or password");

            }
            if (!VerifyPasswordHash(userDTO.Password, existingUser.PasswordHash, existingUser.PasswordSalt))
            {
                throw new KeyNotFoundException();
            }

            string token = CreateToken(existingUser);

            var response = new
            {
                Token = token,
                User = existingUser
            };

            return token;
        }
        //по хорошему это логику в сервис
        private string CreateToken(User user)
        {

            List<Claim> claims = new List<Claim>
            {
   
                new Claim(ClaimTypes.Email, user.Email),

            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("JWT:Key").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }
        private bool VerifyPasswordHash(string reqPassword, byte[] storedPasswordHash, byte[] storedPasswordSalt)
        {
            using (var hmac = new HMACSHA512(storedPasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(reqPassword));
                return computedHash.SequenceEqual(storedPasswordHash);
            }

        }

    }
}