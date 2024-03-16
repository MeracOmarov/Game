using Abtraction;
using Domen.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class MoneyTransaction:IMoneyTransaction
    {
        private readonly ITransactionOperations _transactionOperations;

        public MoneyTransaction(ITransactionOperations transactionOperations)
        {
            _transactionOperations = transactionOperations;
        }

        public async Task StartMoneyTransaction( SendToDTO sendToDTO)
        {
            await _transactionOperations.SendTo(sendToDTO.FromUserID,sendToDTO.ToUserID,sendToDTO.Balance);
        }

  
    }
}
