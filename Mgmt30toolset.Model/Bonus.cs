using System.Collections.Generic;

namespace Mgmt30toolset.Model
{
    public class Bonus : ModelObject
    {
        public int Value { get; set; }
        public string Description { get; set; }
        public virtual User Sender { get; set; }
        public virtual User Receiver { get; set; }
        public virtual ICollection<BonusTag> Tags { get; set; }
    }
}
