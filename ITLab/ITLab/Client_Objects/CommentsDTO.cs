using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITLab.Models;

namespace ITLab.Landing.MVC.Client_Objects
{
    public class CommentsDTO
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public DateTime TimeDate { get; set; }
        public int? CommentatorId { get; set; }
        public string FullName { get; set; }
        public int? NewsId { get; set; }

        public virtual Users Commentator { get; set; }
        public virtual News News { get; set; }
    }
}
