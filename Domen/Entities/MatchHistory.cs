using System.ComponentModel.DataAnnotations;

namespace Domen.Entities
{
    public class MatchHistory
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; } = new DateTime();
        public List<Bet> Bets { get; set; }
        public string Result { get; set; }
        public ICollection<UserMatchHistory> UserMatchHistory { get; set; }

    }
}
