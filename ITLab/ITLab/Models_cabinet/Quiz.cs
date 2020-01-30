using System.ComponentModel.DataAnnotations;

namespace ITLab.Models_cabinet
{
    public class Quiz
    {
        [Key]
        public int QuizId { get; set; }
        public string Name { get; set; }
        public string QuizLink { get; set; }
    }
}