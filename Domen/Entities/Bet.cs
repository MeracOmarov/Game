namespace Domen.Entities
{
    public class Bet
    {
        public int ID { get; set; }
        public int IDofMatchHistory { get; set; }
        public string OneUserBet { get; set; }
        public string AnotherUserBet { get; set; }
        public string Winner {  get; set; }
        public MatchHistory MatchHistory { get; set; }
    }
}
