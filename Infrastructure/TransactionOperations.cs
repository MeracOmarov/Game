using Abtraction;
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
    public class TransactionOperations : ITransactionOperations
    {
        private readonly GameDbContext _gameDbContext;

        public TransactionOperations(GameDbContext gameContext)
        {
            _gameDbContext = gameContext;
        }

        public async Task SendTo(int fromUserID, int toUserID, double balance)
        {
            var fromUser = await _gameDbContext.Users.SingleOrDefaultAsync(u => u.ID == fromUserID);
            var toUser = await _gameDbContext.Users.SingleOrDefaultAsync(u => u.ID == toUserID);
            if (fromUser!=null && toUser!=null)
            {
                fromUser.Balance = fromUser.Balance - balance;
                toUser.Balance = toUser.Balance + balance;
                await _gameDbContext.SaveChangesAsync();
            }
            throw new Exception("SendTo Error (TransactionOperations)");
        }

      
    }
}
