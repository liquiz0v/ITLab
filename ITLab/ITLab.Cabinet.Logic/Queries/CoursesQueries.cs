using Dapper;
using ITLab.Cabinet.Database.Models;
using ITLab.Cabinet.Logic.DTOModels;
using ITLab.Cabinet.Logic.Helpers.Sql;
using ITLab.Cabinet.Logic.Queries.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ITLab.Cabinet.Logic.Queries
{
    public class CoursesQueries : ICoursesQueries
    {
        private readonly string _connectionString;
        public CoursesQueries(IConnectionStringHelper helper)
        {
            _connectionString = helper.ConnectionString;
        }

        public List<CourseDTO> GetCourseWithSchedule()
        {
            var sqlquery = $@"SELECT DISTINCT TOP(3)
                                  Courses.CourseId
                                , Courses.Name
                                , Courses.Description
                                , Courses.HeadPhotoId
                                , Photos.PhotoLink
                            FROM Courses
                            JOIN Photos on Photos.PhotoId = Courses.HeadPhotoId
                            ;";

            var courses = new List<CourseDTO>();

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                courses = db.Query<CourseDTO>(sqlquery).ToList();
            }

            foreach (var course in courses)
            {
                var schedules = GetSchedule(course.CourseId);

                foreach (var schedule in schedules)
                {
                    course.Schedule.Add(schedule);
                }
            }

            return courses;
        }

        public List<CourseScheduleDTO> GetSchedule(int courseId)
        {
            var sqlquery = $@"SELECT DISTINCT
                                  DayOfWeek = datepart(dw ,Lessons.LessonDateFrom)
                                , Lessons.LessonDateFrom
                                , Lessons.LessonDateTo
                            FROM Courses
                            JOIN Lessons on Lessons.CourseId = Courses.CourseId
                            WHERE Courses.CourseId = {courseId};";

            var lessons = new List<CourseScheduleDTO>();

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                lessons = db.Query<CourseScheduleDTO>(sqlquery).ToList();
            }

            return lessons;
        }

        public List<Course> GetStudentCourses(int studentId)
        {
            var sqlstring = @$"SELECT [dbo].[Courses].[CourseId]
                                      ,[dbo].[Courses].[Name]
                                  FROM [dbo].[Courses]
                                  JOIN [dbo].[StudentsCourses] on [StudentsCourses].[CourseId] = [Courses].[CourseId]
                                  JOIN [dbo].[Students] on [Students].[StudentId] = [StudentsCourses].[StudentId]
                                  WHERE [Students].[StudentId] = {studentId}";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Course>(sqlstring).ToList();
            }
        }

        public StudentStatisticsDTO GetStudentStatistics(int studentId, int courseId)
        {
            var sqlQuery = $@"SELECT DISTINCT 
                                           StudentStat.StudentId
	                                      ,StudentStat.StudentPositionInRating
	                                      ,StudentStat.AverageMark
	                                      ,StudentCompletedTasks.CompletedTasksCount
	                                      ,COUNT(StudentOverallTasks.MarksCount) OVER(
                                           ORDER BY StudentOverallTasks.StudentId) AS OverallTasksCount
	                                      ,StudentsVisitedLessons.AccomplishedLessons
	                                      ,StudentsVisitedLessons.VisitedLessons
                                    FROM Students
                                    JOIN
                                    (
                                        SELECT DISTINCT 
                                               AvgMarks.StudentId, 
                                               AvgMarks.AverageMark, 
                                               ROW_NUMBER() OVER(
                                               ORDER BY AverageMark DESC) AS StudentPositionInRating
                                        FROM
                                        (
                                            SELECT DISTINCT 
                                                   CourseRating.StudentId, 
                                                   CAST(AVG(CourseRating.Mark) OVER(
                                                   ORDER BY CourseRating.StudentId) AS REAL) AS AverageMark
                                            FROM
                                            (
                                                SELECT DISTINCT 
                                                       StudentMarks.StudentId, 
                                                       (CASE
                                                            WHEN StudentMarks.Mark IS NULL
                                                            THEN 0
                                                            ELSE StudentMarks.Mark
                                                        END) AS Mark
                                                FROM [ITLab_Cabinet].[dbo].[StudentMarks]
                                                     JOIN HomeTasks ON HomeTasks.Id = StudentMarks.HomeTaskId
                                                     JOIN Lessons ON HomeTasks.LessonId = Lessons.LessonId
                                                     JOIN Courses ON Courses.CourseId = Lessons.CourseId
                                                WHERE Courses.CourseId = @CourseId
                                            ) AS CourseRating
                                        ) AS AvgMarks
                                        JOIN StudentsCourses ON StudentsCourses.StudentId = AvgMarks.StudentId
                                        WHERE AvgMarks.StudentId IN
                                        (
                                            SELECT Students.StudentId
                                            FROM Students
                                        )
                                              AND StudentsCourses.CourseId = @CourseId
                                    ) AS StudentStat ON StudentStat.StudentId = Students.StudentId
                                    JOIN
                                    (
                                        SELECT DISTINCT 
                                               StudentMarks.StudentId, 
                                               COUNT(StudentMarks.Mark) OVER(PARTITION BY StudentMarks.StudentId) AS CompletedTasksCount
                                        FROM [ITLab_Cabinet].[dbo].[StudentMarks]
                                             JOIN HomeTasks ON HomeTasks.Id = StudentMarks.HomeTaskId
                                             JOIN Lessons ON HomeTasks.LessonId = Lessons.LessonId
                                             JOIN Courses ON Courses.CourseId = Lessons.CourseId
                                        WHERE StudentMarks.StudentId = @StudentId
                                              AND Courses.CourseId = @CourseId
                                    ) AS StudentCompletedTasks ON StudentCompletedTasks.StudentId = Students.StudentId
                                    JOIN
                                    (
                                        SELECT StudentMarks.StudentId, 
                                               COUNT(StudentMarks.Mark) OVER(PARTITION BY StudentMarks.StudentId) AS MarksCount
                                        FROM [ITLab_Cabinet].[dbo].[StudentMarks]
                                             JOIN HomeTasks ON HomeTasks.Id = StudentMarks.HomeTaskId
                                             JOIN Lessons ON HomeTasks.LessonId = Lessons.LessonId
                                             JOIN Courses ON Courses.CourseId = Lessons.CourseId
                                        WHERE StudentMarks.StudentId = @StudentId
                                              AND Courses.CourseId = @CourseId
                                    ) AS StudentOverallTasks ON StudentOverallTasks.StudentId = Students.StudentId
                                    LEFT JOIN
                                    (
                                        SELECT SUM(CASE
                                                       WHEN LessonsVisits.Visited = 1
                                                       THEN 1
                                                       ELSE 0
                                                   END) AS VisitedLessons, 
                                               COUNT(LessonsVisits.LessonId) AS AccomplishedLessons, 
                                               LessonsVisits.StudentId
                                        FROM Lessons
                                             JOIN LessonsVisits ON LessonsVisits.LessonId = Lessons.LessonId
                                        WHERE Lessons.CourseId = @CourseId
                                              AND Lessons.LessonDateFrom <= GETDATE()
                                        GROUP BY LessonsVisits.StudentId
                                    ) StudentsVisitedLessons ON StudentsVisitedLessons.StudentId = Students.StudentId
                                    WHERE Students.StudentId = @StudentId;";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<StudentStatisticsDTO>(sqlQuery, new {studentId, courseId}).FirstOrDefault();
            }
        }

        public List<LessonDTO> GetCourseLessons(int courseId)
        {
            var query = $@"SELECT Lessons.LessonId
                                ,Lessons.Name
                                ,Lessons.Description
                                ,Lessons.LessonDateFrom
                                ,Lessons.LessonDateTo
                            FROM Courses
                            JOIN Lessons ON Lessons.CourseId = Courses.CourseId
                            WHERE Courses.CourseId = @courseId";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<LessonDTO>(query, new { courseId }).ToList();
            }
        }
    }
}
