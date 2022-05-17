using System;
using System.Collections.Generic;

namespace TheTjerrs.Models
{
    public partial class Partite
    {
        public Partite()
        {
            Kandidatets = new HashSet<Kandidatet>();
        }

        public int PartiId { get; set; }
        public string? EmriPartise { get; set; }
        public int? EpollId { get; set; }

        public virtual ExitPoll? Epoll { get; set; }
        public virtual ICollection<Kandidatet> Kandidatets { get; set; }
    }
}
