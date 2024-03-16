using System.ComponentModel.DataAnnotations;

namespace Domen.Entities
{
    public class Transaction
    {
        public int ID { get; set; }
        public User SendingUser { get; set; }
        public User AcceptingUser { get; set; }
        public double AmountOfTransaction { get; set; }
    }
}
