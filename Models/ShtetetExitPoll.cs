using System;
using System.Collections.Generic;

namespace TheTjerrs.Models
{
    public partial class ShtetetExitPoll
    {
        public int? ShtetiId { get; set; }
        public int? EpollId { get; set; }

        public virtual ExitPoll? Epoll { get; set; }
        public virtual Shtetet? Shteti { get; set; }
    }
}
