using System;
using System.Collections.Generic;

namespace ITLab.Models
{
    public partial class News
    {
        public News()
        {
            Comments = new HashSet<Comments>(); //hashset , коллекция элементов которые отличаются
            Photos = new HashSet<Photos>();
            Videos = new HashSet<Videos>();
            TimeDate = DateTime.UtcNow; //auto time
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public DateTime TimeDate { get; set; }
        public string HeadPhoto { get; set; }
        public int ViewsCount { get; set; }

        public virtual ICollection<Comments> Comments { get; set; } //virtual - те, методы и свойства к-е мы делаем доступными для переопределения
        public virtual ICollection<Photos> Photos { get; set; }
        public virtual ICollection<Videos> Videos { get; set; }
    }
}
