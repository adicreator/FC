using System;
using System.Collections.Generic;

namespace TheTjerrs.Models
{
    public partial class PytetjePergjigjieAnketum
    {
        public string? AnketaSsId { get; set; }
        public string? PyetjaId { get; set; }
        public string? PergjigjiaId { get; set; }

        public virtual AnketatSs? AnketaSs { get; set; }
        public virtual Pergjigjium? Pergjigjia { get; set; }
        public virtual Pyetja? Pyetja { get; set; }
    }
}
