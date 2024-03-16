using Domen.DTOs;
using Domen.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abtraction
{
    public interface IUserOperations
    {
        Task CreateUser(CreateUserDTO createUserDTO);
        Task<User> GetUser(string pin);
    }
}
