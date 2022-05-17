using System;
using System.Collections.Generic;

namespace TheTjerrs.Models
{
    public partial class Vendvotimi
    {
        public Vendvotimi()
        {
            AnketatEpolls = new HashSet<AnketatEpoll>();
        }

        public int NumriVendvotimit { get; set; }
        public string? EmriShkolles { get; set; }
        public int? QytetiId { get; set; }

        public virtual Qytetet? Qyteti { get; set; }
        public virtual ICollection<AnketatEpoll> AnketatEpolls { get; set; }
    }
}
