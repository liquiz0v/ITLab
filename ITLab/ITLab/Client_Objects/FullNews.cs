using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITLab.Models;

namespace ITLab.Client_Objects
{
    public class FullNews
    {
       
        public int Id { get; set; }
        public string Title { get; set; }
        public string FullDescription { get; set; }
        public DateTime TimeDate { get; set; }

        public int CommentsCount { get; set; }
        public int ViewsCount { get; set; }

        public virtual List<Photos> Photos { get; set; }
        public virtual List<Videos> Videos { get; set; }
        public virtual List<Comments> Comments { get; set; }

        public virtual List<ShortNews> ShortNews { get; set; }
    }
    
}
