using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITLab.Models;

namespace ITLab.Client_Objects
{
    public class ShortNews 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public DateTime TimeDate { get; set; }
        public string HeadPhoto { get; set; }

        public int CommentsCount { get; set; }
        public int ViewsCount { get; set; }

    }
}
