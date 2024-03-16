using Abtraction;
using Domen.DTOs;
using Domen.Entities;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UserOperations : IUserOperations
    {
        private readonly GameDbContext _gameDbContext;

        public UserOperations(GameDbContext gameContext)
        {
            _gameDbContext = gameContext;
        }

        public async Task CreateUser(CreateUserDTO createUserDTO)
        {
            User userCheck = await _gameDbContext.Users.SingleOrDefaultAsync(u => u.PIN == createUserDTO.PIN);
            if (userCheck == null)
            {
                User user = new User() { Name = createUserDTO.Name, PIN = createUserDTO.PIN };
                await _gameDbContext.Users.AddAsync(user);
                await _gameDbContext.SaveChangesAsync();
            }
            //throw new Exception("ERROR: User already exists");
        }


        public async Task<User> GetUser(string pin)
        {
            User user =await _gameDbContext.Users.SingleOrDefaultAsync(u=>u.PIN==pin);
            return user;
        }
    }
}
