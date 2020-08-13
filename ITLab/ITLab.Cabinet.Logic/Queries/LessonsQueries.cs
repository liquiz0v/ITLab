using Dapper;
using ITLab.Cabinet.Logic.DTOModels;
using ITLab.Cabinet.Logic.Helpers.Sql;
using ITLab.Cabinet.Logic.Queries.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLab.Cabinet.Logic.Queries
{
    public class LessonsQueries : ILessonsQueries
    {
        public string _connectionString;
        public LessonsQueries(IConnectionStringHelper helper)
        {
            _connectionString = helper.ConnectionString;
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
