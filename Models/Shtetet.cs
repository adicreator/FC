using System;
using System.Collections.Generic;

namespace TheTjerrs.Models
{
    public partial class Shtetet
    {
        public Shtetet()
        {
            AnketatEpolls = new HashSet<AnketatEpoll>();
            AnketatSses = new HashSet<AnketatSs>();
            Qytetets = new HashSet<Qytetet>();
        }

        public int ShtetiId { get; set; }
        public string? EmriShtetit { get; set; }
        public int? NumriBanorve { get; set; }

        public virtual ICollection<AnketatEpoll> AnketatEpolls { get; set; }
        public virtual ICollection<AnketatSs> AnketatSses { get; set; }
        public virtual ICollection<Qytetet> Qytetets { get; set; }
    }
}
