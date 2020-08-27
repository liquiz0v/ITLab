namespace ITLab.Cabinet.Logic.DTOModels
{
    public class DetailedLessonDTO
    {
        public int LessonId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OverallCount { get; set; }
        public int CompletedCount { get; set; }
        public string PhotoLink { get; set; }
        public string VideoLink { get; set; }
        public string PresentationLink { get; set; }
    }
}