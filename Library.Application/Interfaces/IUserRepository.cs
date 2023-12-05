using Library.Application.Dto;
using Library.Domain;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> Registration(UserDTO userDTO);
        Task<String> Login(UserDTO userDTO);

    }
}
