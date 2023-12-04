using Library.Domain.Models;
using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Interfaces
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User Registration(User user);
        Tokens Login(User user);
    }
}
