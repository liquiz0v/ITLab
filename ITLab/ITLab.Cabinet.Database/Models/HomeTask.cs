using System.ComponentModel.DataAnnotations;

namespace ITLab.Cabinet.Database.Models
{
    public class HomeTask
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Quiz Quiz { get; set; }
    }
}