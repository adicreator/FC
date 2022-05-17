using System;
using System.Collections.Generic;

namespace TheTjerrs.Models
{
    public partial class Zona
    {
        public Zona()
        {
            AnketatEpolls = new HashSet<AnketatEpoll>();
            AnketatSses = new HashSet<AnketatSs>();
        }

        public int ZonaId { get; set; }
        public string? EmriZones { get; set; }
        public string? LlojiZones { get; set; }
        public int? QytetiId { get; set; }

        public virtual Qytetet? Qyteti { get; set; }
        public virtual ICollection<AnketatEpoll> AnketatEpolls { get; set; }
        public virtual ICollection<AnketatSs> AnketatSses { get; set; }
    }
}
