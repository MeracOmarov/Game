using Abtraction;
using Domen.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public  class UserMatchHistory:IUserMatchHistory
    {
        public readonly IMatchHistoryOperations _matchHistoryOperations;
        public readonly IBetOperations _betOperations;

        public UserMatchHistory(IMatchHistoryOperations matchHistoryOperations, IBetOperations betOperations)
        {
            _matchHistoryOperations = matchHistoryOperations;
            _betOperations = betOperations;
        }

        public async Task<List<string>> FetchUserMatchHistory(int selectedUserId)
        {
            List<string > responses = new List<string>();
            List<Bet> bets= new List<Bet>();
            var matchHistory = await _matchHistoryOperations.GetListOfMatchHistory(selectedUserId);
            foreach (var match in matchHistory)
            {
               responses.Add(match.ID + match.Name);
               bets=await _betOperations.GetBets(match.ID);
               foreach (var bet in bets)
               {
                    responses.Add(bet.ID + bet.OneUserBet + bet.AnotherUserBet + bet.Winner);
               }

            }
            return responses;
        }
    }
}
