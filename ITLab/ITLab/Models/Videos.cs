using System;
using System.Collections.Generic;

namespace ITLab.Models
{
    public partial class Videos
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public int? NewsId { get; set; }

        public virtual News News { get; set; }
    }
}
