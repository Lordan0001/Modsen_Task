using AutoMapper;
using Library.Application.Dto;
using Library.Application.Interfaces;
using Library.Domain;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<List<UserDTO>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return _mapper.Map<List<UserDTO>>(users);
        }
        public async Task<UserDTO> Registration(UserDTO userDTO)
        {
           
            if (string.IsNullOrWhiteSpace(userDTO.Email) || string.IsNullOrWhiteSpace(userDTO.Password))
            {
                throw new ValidationException("Email and Password are required.");
            }
            var userLogin = await _userRepository.Registration(userDTO);
            return _mapper.Map<UserDTO>(userLogin);
        }
        public async Task<String> Login(UserDTO userDTO)
        {
            
            if (string.IsNullOrWhiteSpace(userDTO.Email) || string.IsNullOrWhiteSpace(userDTO.Password))
            {
                throw new ValidationException("Email and Password are required.");
            }
            var userLogin = await _userRepository.Login(userDTO);
            return userLogin;
        }

    }
}
