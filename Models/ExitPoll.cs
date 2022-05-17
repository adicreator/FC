using System;
using System.Collections.Generic;

namespace TheTjerrs.Models
{
    public partial class ExitPoll
    {
        public ExitPoll()
        {
            Partites = new HashSet<Partite>();
            RezultatiEps = new HashSet<RezultatiEp>();
        }

        public int EpollId { get; set; }
        public string? EmriEp { get; set; }

        public virtual ICollection<Partite> Partites { get; set; }
        public virtual ICollection<RezultatiEp> RezultatiEps { get; set; }
    }
}
