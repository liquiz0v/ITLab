using System;
using System.ComponentModel.DataAnnotations;

namespace ITLab.Models_cabinet
{
    public class Photo
    {
        [Key]
        public int PhotoId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime TimeStamp { get; set; }
        public string PhotoLink { get; set; }
    }
}