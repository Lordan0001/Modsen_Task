using Library.Domain;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User Registration(User user);
        Tokens Login(User user);

    }
}
