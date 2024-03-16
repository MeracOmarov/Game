using Abtraction;
using Domen.Entities;
using Infrastructure.Database;

namespace Infrastructure
{
    public class BetOperations : IBetOperations
    {
        private readonly GameDbContext _gameDbContext;

        public BetOperations(GameDbContext gameDbContext)
        {
            _gameDbContext = gameDbContext;
        }

        public async Task CreateBet(int idofMatchHistory, string oneUserBet, string anotherUserBet, string winner)
        {
            Bet bet = new Bet() {IDofMatchHistory=idofMatchHistory,OneUserBet=oneUserBet, AnotherUserBet=anotherUserBet, Winner=winner };
            await _gameDbContext.Bets.AddAsync(bet);
            await _gameDbContext.SaveChangesAsync();
        }

        public async Task<List<Bet>> GetBets(int idMatchHistory)
        {
            var bets=_gameDbContext.Bets.Where(b=>b.IDofMatchHistory==idMatchHistory).ToList();
            if (bets!=null)
            {
                return bets;
            }
            throw new Exception("GetBets Error");
        }
    }
}
