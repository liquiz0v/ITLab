using System;
using System.Collections.Generic;

namespace ITLab.Models
{
    public partial class News
    {
        public News()
        {
            Comments = new HashSet<Comments>();
            Photos = new HashSet<Photos>();
            Videos = new HashSet<Videos>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public DateTime? TimeDate { get; set; }
        public string HeadPhoto { get; set; }
        public int? ViewsCount { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Photos> Photos { get; set; }
        public virtual ICollection<Videos> Videos { get; set; }
    }
}
