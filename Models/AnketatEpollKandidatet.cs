using System;
using System.Collections.Generic;

namespace TheTjerrs.Models
{
    public partial class AnketatEpollKandidatet
    {
        public int? NumriKandidatit { get; set; }
        public string? AnketaEpId { get; set; }

        public virtual AnketatEpoll? AnketaEp { get; set; }
        public virtual Kandidatet? NumriKandidatitNavigation { get; set; }
    }
}
