using System;
using System.Collections.Generic;

namespace TheTjerrs.Models
{
    public partial class Kandidatet
    {
        public int NumriKandidatit { get; set; }
        public string? Emri { get; set; }
        public string? Mbirmeri { get; set; }
        public int? PartiId { get; set; }

        public virtual Partite? Parti { get; set; }
    }
}
