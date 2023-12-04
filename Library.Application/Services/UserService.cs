using Library.Application.Interfaces;
using Library.Domain;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<User>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return users;
        }

        public async Task<Tokens> Login(User user)
        {
            var tokens = await _userRepository.Login(user);
            return tokens;
        }

        public async Task<User> Registration(User user)
        {
           var registration = await _userRepository.Registration(user);
            return registration;
        }
    }
}
