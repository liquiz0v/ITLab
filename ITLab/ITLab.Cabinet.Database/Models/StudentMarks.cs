using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Caching.Memory;

namespace ITLab.Cabinet.Database.Models
{
    public class StudentMarks
    {
        [Key]
        public int Id { get; set; }
        public Student Student { get; set; }
        public HomeTask HomeTask { get; set; }
        public int? Mark { get; set; }
    }
}