using System;
using System.ComponentModel.DataAnnotations;

namespace ITLab.Cabinet.Database.Models
{
    public class Presentations
    {
        [Key]
        public int PresentationsId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime TimeStamp { get; set; }
        public string PresentationLink { get; set; }
    }
}