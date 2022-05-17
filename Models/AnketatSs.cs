using System;
using System.Collections.Generic;

namespace TheTjerrs.Models
{
    public partial class AnketatSs
    {
        public string AnketaSsId { get; set; } = null!;
        public int? ShtetiId { get; set; }
        public int? QytetiId { get; set; }
        public int? ZonaId { get; set; }
        public string? Mosha { get; set; }
        public string? Gjinia { get; set; }

        public virtual Qytetet? Qyteti { get; set; }
        public virtual Shtetet? Shteti { get; set; }
        public virtual Zona? Zona { get; set; }
    }
}
