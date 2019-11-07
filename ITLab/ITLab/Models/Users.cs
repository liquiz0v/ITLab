using System;
using System.Collections.Generic;

namespace ITLab.Models
{
    public partial class Users
    {
        public Users()
        {
            Comments = new HashSet<Comments>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }
    }
}
