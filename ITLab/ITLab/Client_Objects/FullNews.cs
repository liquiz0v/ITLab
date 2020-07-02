using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITLab.Models;
using ITLab.Landing.MVC.Client_Objects;

namespace ITLab.Client_Objects
{
    public class FullNewsDTO
    {

        public FullNewsDTO()
        {
            Photos = new List<Photos>();
            Videos = new List<Videos>();
            Comments = new List<CommentsDTO>();
            ShortNews = new List<ShortNews>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string FullDescription { get; set; }
        public DateTime TimeDate { get; set; }

        public int CommentsCount { get; set; }
        public int ViewsCount { get; set; }

        public virtual List<Photos>? Photos { get; set; }
        public virtual List<Videos>? Videos { get; set; }
        public virtual List<CommentsDTO>? Comments { get; set; }

        public virtual List<ShortNews>? ShortNews { get; set; }
    }
    
}
