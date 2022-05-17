using System;
using System.Collections.Generic;

namespace TheTjerrs.Models
{
    public partial class Qytetet
    {
        public Qytetet()
        {
            AnketatEpolls = new HashSet<AnketatEpoll>();
            AnketatSses = new HashSet<AnketatSs>();
            Vendvotimis = new HashSet<Vendvotimi>();
            Zonas = new HashSet<Zona>();
        }

        public int QytetiId { get; set; }
        public string? EmriQytetit { get; set; }
        public int? NumriBanorve { get; set; }
        public int? ShtetiId { get; set; }

        public virtual Shtetet? Shteti { get; set; }
        public virtual ICollection<AnketatEpoll> AnketatEpolls { get; set; }
        public virtual ICollection<AnketatSs> AnketatSses { get; set; }
        public virtual ICollection<Vendvotimi> Vendvotimis { get; set; }
        public virtual ICollection<Zona> Zonas { get; set; }
    }
}
