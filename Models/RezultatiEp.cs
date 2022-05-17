using System;
using System.Collections.Generic;

namespace TheTjerrs.Models
{
    public partial class RezultatiEp
    {
        public int RezId { get; set; }
        public double? RezultatiParti { get; set; }
        public double? RezultatiKandidate { get; set; }
        public int? EpollId { get; set; }

        public virtual ExitPoll? Epoll { get; set; }
    }
}
