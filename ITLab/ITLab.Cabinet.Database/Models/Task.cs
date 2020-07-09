using System.ComponentModel.DataAnnotations;

namespace ITLab.Cabinet.Database.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Quiz Quiz { get; set; }
    }
}