using Domen.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abtraction
{
    public  interface IBetOperations
    {
        Task CreateBet(int idofMatchHistory, string oneUserBet, string anotherUserBet, string winner);
        Task<List<Bet>> GetBets(int idMatchHistory);
       
    }
}
