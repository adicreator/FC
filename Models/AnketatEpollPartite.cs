using System;
using System.Collections.Generic;

namespace TheTjerrs.Models
{
    public partial class AnketatEpollPartite
    {
        public int? PartiId { get; set; }
        public string? AnketaEpId { get; set; }

        public virtual AnketatEpoll? AnketaEp { get; set; }
        public virtual Partite? Parti { get; set; }
    }
}
