using System.ComponentModel.DataAnnotations;

namespace ITLab.Models_cabinet
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}