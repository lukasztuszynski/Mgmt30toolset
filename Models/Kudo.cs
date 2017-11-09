namespace Mgmt30toolset.Models
{
    public class Kudo: ModelObject
    {
        public string Content { get; set; }
        public User Receiver { get; set; }
        public User Sender { get; set; }
        public KudoCategory Category { get; set; }
    }
}
