using KuasCore.Dao;
using KuasCore.Dao.Impl;
using KuasCore.Models;
using System;
using System.Collections.Generic;

namespace KuasCore.Services.Impl
{
    public class TxCourseService : ITxCourseService
    {

        public ICourseDao CourseDao { get; set; }

        public void ExecuteTxMethod()
        {
            Course course1 = new Course();
            course1.CourseID = "AAA";
            course1.CourseName = "AAA";
            course1.CourseDescription = "AAA";
            CourseDao.AddCourse(course1);

            Course course2 = new Course();
            course2.CourseID = "BBB";
            course2.CourseName = "BBB";
            course2.CourseDescription = "BBB";
            CourseDao.AddCourse(course2);

            Course dbCourse = CourseDao.GetCourseByCourseName("AAA");
            dbCourse.CourseName = "XXX";
            CourseDao.UpdateCourse(dbCourse);

            throw new Exception("Get an exception");
        }

    }

}
