using Domen.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abtraction
{
    public  interface ITransactionOperations
    {
        Task SendTo(int fromUserID, int toUserID, double balance);

    }
}
