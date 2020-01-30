using System;
using System.ComponentModel.DataAnnotations;

namespace ITLab.Models_cabinet
{
    public class Video
    {
        [Key]
        public int VideoId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime TimeStamp { get; set; }
        public string VideoLink { get; set; }
    }
}