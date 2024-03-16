namespace Domen.Entities
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PIN { get; set; }
        public double Balance { get; set; }= 0;
        public ICollection<UserMatchHistory> UserMatchHistory { get; set; }
    }
}
