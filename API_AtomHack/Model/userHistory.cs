namespace API_AtomHack.Model
{
    public class userHistory
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int Case { get; set; }
        public int ColonyId { get; set; }
        public int SystemId { get; set; }
        public int messageId { get; set; }
        public DateTime DateTime { get; set; }

    }
}
