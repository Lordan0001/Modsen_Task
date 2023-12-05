using Library.Domain.Models;
using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Application.Dto;

namespace Library.Application.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllUsers();
        Task<UserDTO> Registration(UserDTO userDTO);
        Task<String> Login(UserDTO userDTO);
    }
}
