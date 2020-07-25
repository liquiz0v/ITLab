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
        public string _connectionString;
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

            var courses = new List<Course>();

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                courses = db.Query<Course>(sqlstring).ToList();
            }

            return courses;
        }
    }
}
