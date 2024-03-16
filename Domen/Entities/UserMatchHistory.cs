namespace Domen.Entities
{
    public class UserMatchHistory
    {
        public int UserID { get; set; }
        public int MatchHistoryID { get; set; }
        public User User { get; set; }
        public MatchHistory MatchHistory { get; set; }
    }
}
