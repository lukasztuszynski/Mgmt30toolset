namespace Mgmt30toolset.Models
{
    public class Kudo: ModelObject
    {
        public string Content { get; set; }
        public virtual User Receiver { get; set; }
        public virtual User Sender { get; set; }
        public virtual KudoCategory Category { get; set; }
    }
}
