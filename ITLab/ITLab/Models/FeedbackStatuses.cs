using System;
using System.Collections.Generic;

namespace ITLab.Models
{
    public partial class FeedbackStatuses
    {
        public FeedbackStatuses()
        {
            Feedback = new HashSet<Feedback>();
        }

        public int Id { get; set; }
        public string Statuses { get; set; }

        public virtual ICollection<Feedback> Feedback { get; set; }
    }
}
