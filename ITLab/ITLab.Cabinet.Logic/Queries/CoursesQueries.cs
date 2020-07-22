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

        public CourseDTO GetShortCourse(int courseId)
        {
            var sqlquery = $@"select distinct Courses.Name
                                , Courses.Description
                                , Courses.HeadPhotoId
                            from Courses
                            join Lessons on Lessons.CourseId = Courses.CourseId
                            where Courses.CourseId = {courseId};";

            var course = new CourseDTO();

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                course = db.Query<CourseDTO>(sqlquery).FirstOrDefault();
            }

            var lessonTimes = GetCourseLessons(courseId);

            foreach(var lessonTime in lessonTimes)
            {
                course.LessonTimes.Add(lessonTime);
            }

            return course;
        }

        public List<CourceShortLessonTimeDTO> GetCourseLessons(int courseId)
        {
            var sqlquery = $@"select distinct
                                  DayOfWeek = datepart(dw ,Lessons.LessonDateFrom)
                                , Lessons.LessonDateFrom
                                , Lessons.LessonDateTo
                            from Courses
                            join Lessons on Lessons.CourseId = Courses.CourseId
                            where Courses.CourseId = {courseId};";

            var lessons = new List<CourceShortLessonTimeDTO>();

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                lessons = db.Query<CourceShortLessonTimeDTO>(sqlquery).ToList();
            }

            return lessons;
        }
    }
}
