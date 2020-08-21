using Dapper;
using ITLab.Cabinet.Logic.DTOModels;
using ITLab.Cabinet.Logic.Helpers.Sql;
using ITLab.Cabinet.Logic.Queries.Interfaces;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ITLab.Cabinet.Logic.Queries
{
    public class LessonsQueries : ILessonsQueries
    {
        private readonly string _connectionString;
        public LessonsQueries(IConnectionStringHelper helper)
        {
            _connectionString = helper.ConnectionString;
        }

        public async Task<IEnumerable<DetailedLessonDTO>> GetLessonByLessonId(int lessonId, int studentId)
        {
            var sqlquery = $@"SELECT DISTINCT 
                                   Lessons.LessonId, 
                                   Lessons.Name, 
                                   Lessons.Description, 
                                   OverallTasksCount.OverallCount, 
                                   CompletedTasksCount.CompletedCount, 
                                   Photos.PhotoLink, 
                                   Videos.VideoLink, 
                                   Presentations.PresentationLink
                            FROM Lessons
                                 LEFT JOIN Photos ON Photos.LessonId = Lessons.LessonId
                                 LEFT JOIN Videos ON Videos.LessonId = Lessons.LessonId
                                 LEFT JOIN Presentations ON Presentations.LessonId = Lessons.LessonId
                                 JOIN
                            (
                                SELECT HomeTasks.Id, 
                                       HomeTasks.LessonId
                                FROM HomeTasks
                            ) AS Tasks ON Tasks.LessonId = Lessons.LessonId
                                 JOIN
                            (
                                SELECT DISTINCT 
                                       StudentMarks.StudentId, 
                                       Lessons.LessonId, 
                                       COUNT(CheckForNulls.Mark) OVER(
                                       ORDER BY StudentMarks.StudentId) AS OverallCount
                                FROM [ITLab_Cabinet].[dbo].[StudentMarks]
                                     JOIN HomeTasks ON HomeTasks.Id = StudentMarks.HomeTaskId
                                     JOIN Lessons ON HomeTasks.LessonId = Lessons.LessonId
                                     JOIN
                                (
                                    SELECT(CASE
                                               WHEN StudentMarks.Mark IS NULL
                                               THEN 0
                                               ELSE StudentMarks.Mark
                                           END) AS Mark, 
                                          StudentMarks.Id
                                    FROM StudentMarks
                                ) AS CheckForNulls ON CheckForNulls.Id = StudentMarks.Id
                                WHERE Lessons.LessonId = @lessonId
                                      AND StudentMarks.StudentId = @studentId
                            ) AS OverallTasksCount ON OverallTasksCount.LessonId = Lessons.LessonId
                                 JOIN
                            (
                                SELECT DISTINCT 
                                       StudentMarks.StudentId, 
                                       Lessons.LessonId, 
                                       COUNT(Mark) OVER(
                                       ORDER BY StudentMarks.StudentId) AS CompletedCount
                                FROM [ITLab_Cabinet].[dbo].[StudentMarks]
                                     JOIN HomeTasks ON HomeTasks.Id = StudentMarks.HomeTaskId
                                     JOIN Lessons ON HomeTasks.LessonId = Lessons.LessonId
                                WHERE Lessons.LessonId = @lessonId
                                      AND StudentMarks.StudentId = @studentId
                            ) AS CompletedTasksCount ON CompletedTasksCount.LessonId = Lessons.LessonId;";
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return await db.QueryAsync<DetailedLessonDTO>(sqlquery, new { studentId, lessonId });
            }
        }

        public async Task<IEnumerable<LessonDTO>> GetLessonsAsync(int courseId, int studentId)
        {
            var sqlquery = $@"SELECT Lessons.[LessonId], 
                               Lessons.[Name], 
                               Lessons.[Description], 
                               Lessons.[CourseId], 
                               Lessons.[LessonDateFrom], 
                               Lessons.[LessonDateTo], 
                               StudentsCourses.StudentId, 
                               CompletedTasksStat.CompletedTasksCount, 
                               CompletedTasksStat.TasksCount

                        FROM [Lessons]

                        JOIN StudentsCourses ON StudentsCourses.CourseId = Lessons.CourseId
                        LEFT JOIN
                        (
                            SELECT SUM(CASE
                                           WHEN StudentMarks.Mark IS NOT NULL
                                           THEN 1
                                           ELSE 0
                                       END) AS CompletedTasksCount, 
                                   COUNT(StudentMarks.Id) AS TasksCount, 
                                   HomeTasks.LessonId, 
                                   StudentMarks.StudentId
                            FROM StudentMarks
                                 JOIN HomeTasks ON HomeTasks.Id = StudentMarks.HomeTaskId
                            WHERE StudentMarks.StudentId = @studentId
                            GROUP BY HomeTasks.LessonId, 
                                     StudentMarks.StudentId
                        ) AS CompletedTasksStat ON CompletedTasksStat.LessonId = Lessons.LessonId

                        WHERE StudentsCourses.StudentId = @studentId
                             AND Lessons.CourseId = @courseId";

            
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return  await db.QueryAsync<LessonDTO>(sqlquery, new { studentId, courseId });
            }
        }
    }
}
