using System;
using System.Collections.Generic;

namespace TheTjerrs.Models
{
    public partial class SimpleSurvey
    {
        public SimpleSurvey()
        {
            RezultatiSses = new HashSet<RezultatiSs>();
        }

        public int SsurveyId { get; set; }
        public string? EmriSs { get; set; }

        public virtual ICollection<RezultatiSs> RezultatiSses { get; set; }
    }
}
