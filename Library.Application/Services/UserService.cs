using Library.Application.Repositories;
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
        public List<User> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            return users;
        }

        public Tokens Login(User user)
        {
            var tokens = _userRepository.Login(user);
            return tokens;
        }

        public User Registration(User user)
        {
           var registration = _userRepository.Registration(user);
            return registration;
        }
    }
}
