
using KuasCore.Dao.Base;
using KuasCore.Dao.Mapper;
using KuasCore.Models;
using Spring.Data.Common;
using Spring.Data.Generic;
using System.Collections.Generic;
using System.Data;

namespace KuasCore.Dao.Impl
{
    public class CourseDao : GenericDao<Course>, ICourseDao
    {

        override protected IRowMapper<Course> GetRowMapper()
        {
            return new CourseRowMapper();
        }

        public void AddCourse(Course course)
        {
            string command = @"INSERT INTO Course (CourseID, CourseName, CourseDescription) VALUES (@CourseID, @CourseName, @CourseDescription);";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("CourseID", DbType.String).Value = course.CourseID;
            parameters.Add("CourseName", DbType.String).Value = course.CourseName;
            parameters.Add("CourseDescription", DbType.String).Value = course.CourseDescription;

            ExecuteNonQuery(command, parameters);
        }

        public void UpdateCourse(Course course)
        {
            string command = @"UPDATE Course SET CourseName = @CourseName, CourseDescription = @CourseDescription WHERE CourseID = @CourseID;";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("CourseID", DbType.String).Value = course.CourseID;
            parameters.Add("CourseName", DbType.String).Value = course.CourseName;
            parameters.Add("CourseDescription", DbType.String).Value = course.CourseDescription;

            ExecuteNonQuery(command, parameters);
        }

        public void DeleteCourse(Course course)
        {
            string command = @"DELETE FROM Course WHERE CourseID = @CourseID";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("CourseID", DbType.String).Value = course.CourseID;

            ExecuteNonQuery(command, parameters);
        }

        public IList<Course> GetAllCourses()
        {
            string command = @"SELECT * FROM Course ORDER BY CourseID ASC";
            IList<Course> courses = ExecuteQueryWithRowMapper(command);
            return courses;
        }

        public Course GetCourseByCourseName(string CourseName)
        {
            string command = @"SELECT * FROM Course WHERE CourseName = @CourseName";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("CourseName", DbType.String).Value = CourseName;

            IList<Course> courses = ExecuteQueryWithRowMapper(command, parameters);
            if (courses.Count > 0)
            {
                return courses[0];
            }

            return null;
        }

    }
}
