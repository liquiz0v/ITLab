using System;
using System.Collections.Generic;

namespace ITLab.Models
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Question { get; set; }
        public int? FeedbackStatus { get; set; }

        public virtual FeedbackStatuses FeedbackStatusNavigation { get; set; }
    }
}
