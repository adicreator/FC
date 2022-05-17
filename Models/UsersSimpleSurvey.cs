using System;
using System.Collections.Generic;

namespace TheTjerrs.Models
{
    public partial class UsersSimpleSurvey
    {
        public int? UsersId { get; set; }
        public int? SsurveyId { get; set; }

        public virtual SimpleSurvey? Ssurvey { get; set; }
        public virtual User? Users { get; set; }
    }
}
