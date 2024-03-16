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
    public class MatchHistoryOperations : IMatchHistoryOperations
    {
        private readonly GameDbContext _gameDbContext;
        private readonly IUserOperations _userOperations;

        public MatchHistoryOperations(GameDbContext gameDbContext, IUserOperations userOperations)
        {
            _gameDbContext = gameDbContext;
            _userOperations = userOperations;
        }

        public async Task CreateMatchHistory(CreateMatchHistoryDTO createMatchHistoryDTO)
        {
            var oneUser = _userOperations.GetUser(createMatchHistoryDTO.oneUserPIN);

            var anotherUser = _userOperations.GetUser(createMatchHistoryDTO.anotherUserPIN);

            MatchHistory matchHistory = new MatchHistory() { DateTime = DateTime.Now, Name= createMatchHistoryDTO.Name, Result= createMatchHistoryDTO.Result };

            UserMatchHistory userMatchHistoryForoneUser = new UserMatchHistory() { UserID = oneUser.Id, MatchHistoryID = matchHistory.ID };

            UserMatchHistory userMatchHistoryForanotherUser = new UserMatchHistory() { UserID = anotherUser.Id, MatchHistoryID = matchHistory.ID };

            await _gameDbContext.UserMatchHistories.AddAsync(userMatchHistoryForoneUser);

            await _gameDbContext.UserMatchHistories.AddAsync(userMatchHistoryForanotherUser);

            await _gameDbContext.MatchHistories.AddAsync(matchHistory);

            await _gameDbContext.SaveChangesAsync();

        }

        public async Task<List<MatchHistory>> GetListOfMatchHistory(int selectedUserId)
        {
          
            var selectedUserMatchHistory=_gameDbContext.UserMatchHistories
                .Where(um=>um.UserID==selectedUserId)
                .Select(um=>um.MatchHistory)
                .ToList();

            if (selectedUserMatchHistory!=null)
            {
                return selectedUserMatchHistory;
            }
            throw new Exception("GetListOfMatchHistory Error");

        }



        public async Task<MatchHistory> GetMatchHistory(int idMatchHistory)
        {
            var user= await _gameDbContext.MatchHistories.SingleOrDefaultAsync(m=>m.ID==idMatchHistory);
            return user;
        }
    }
}
