namespace ITLab.Cabinet.Logic.DTOModels
{
    public class StudentStatisticsDTO
    {
        public int StudentId { get; set; }
        public int StudentPositionInRating { get; set; }
        public int AverageMark { get; set; }
        public int CompletedTasksCount { get; set; }
        public int OverallTasksCount { get; set; }
        public int CompletedLessons { get; set; }
        public int  VisitedLessons { get; set; }
    }
}