using System;
using System.Collections.Generic;

namespace ITLab.Models
{
    public partial class Comments
    {
        public Comments()
        {
            TimeDate = DateTime.UtcNow;
        }
        public int Id { get; set; }
        public string CommentText { get; set; }
        public DateTime TimeDate { get; set; }
        public int? CommentatorId { get; set; }
        public int? NewsId { get; set; }

        public virtual Users Commentator { get; set; }
        public virtual News News { get; set; }
    }
}
