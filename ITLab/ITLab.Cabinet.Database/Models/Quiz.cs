using System.ComponentModel.DataAnnotations;

namespace ITLab.Cabinet.Database.Models
{
    public class Quiz
    {
        [Key]
        public int QuizId { get; set; }
        public string Name { get; set; }
        public string QuizLink { get; set; }
    }
}