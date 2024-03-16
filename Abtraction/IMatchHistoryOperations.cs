using Domen.DTOs;
using Domen.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abtraction
{
    public  interface IMatchHistoryOperations
    {
        Task CreateMatchHistory(CreateMatchHistoryDTO createMatchHistoryDTO);
        Task<MatchHistory> GetMatchHistory(int idMatchHistory);
        Task<List<MatchHistory>> GetListOfMatchHistory(int selectedUserId);
    }
}
