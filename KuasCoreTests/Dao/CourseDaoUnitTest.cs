using KuasCore.Dao;
using KuasCore.Dao.Impl;
using KuasCore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace KuasCoreTests.Dao
{

    [TestClass]
    public class CourseDaoUnitTest : AbstractDependencyInjectionSpringContextTests
    {
        #region 單元測試 Spring 必寫的內容 
        
        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    // assembly://MyAssembly/MyNamespace/ApplicationContext.xml
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }

        #endregion

        public ICourseDao CourseDao { get; set; }

        [TestMethod]
        public void TestCourseDao_AddCourse()
        {
            Course course = new Course();
            course.CourseID = "UnitTests";
            course.CourseName = "單元測試";
            course.CourseDescription = "單元測試";
            CourseDao.AddCourse(course);

            Course dbCourse = CourseDao.GetCourseByCourseName(course.CourseID);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(course.CourseID, dbCourse.CourseID);

            Console.WriteLine("課程編號為 = " + course.CourseID);
            Console.WriteLine("課程名稱為 = " + course.CourseName);
            Console.WriteLine("課程描述為 = " + course.CourseDescription);

            CourseDao.DeleteCourse(dbCourse);
            dbCourse = CourseDao.GetCourseByCourseName(course.CourseID);
            Assert.IsNull(dbCourse);
        }

        [TestMethod]
        public void TestCourseDao_UpdateCourse()
        {
            // 取得資料
            Course course = CourseDao.GetCourseByCourseName("Chinese");
            Assert.IsNotNull(course);

            // 更新資料
            course.CourseName = "單元測試";
            CourseDao.UpdateCourse(course);

            // 再次取得資料
            Course dbCourse = CourseDao.GetCourseByCourseName(course.CourseID);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(course.CourseName, dbCourse.CourseName);

            Console.WriteLine("課程編號為 = " + course.CourseID);
            Console.WriteLine("課程名稱為 = " + course.CourseName);
            Console.WriteLine("課程描述為 = " + course.CourseDescription);

            Console.WriteLine("================================");

            // 將資料改回來
            course.CourseName = "Chinese";
            CourseDao.UpdateCourse(course);

            // 再次取得資料
            dbCourse = CourseDao.GetCourseByCourseName(course.CourseID);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(course.CourseName, dbCourse.CourseName);

            Console.WriteLine("課程編號為 = " + course.CourseID);
            Console.WriteLine("課程名稱為 = " + course.CourseName);
            Console.WriteLine("課程描述為 = " + course.CourseDescription);
        }


        [TestMethod]
        public void TestCourseDao_DeleteCourse()
        {
            Course newCourse = new Course();
            newCourse.CourseID = "UnitTests";
            newCourse.CourseName = "單元測試";
            newCourse.CourseDescription = "單元測試";
            CourseDao.AddCourse(newCourse);

            Course dbCourse = CourseDao.GetCourseByCourseName(newCourse.CourseID);
            Assert.IsNotNull(dbCourse);

            CourseDao.DeleteCourse(dbCourse);
            dbCourse = CourseDao.GetCourseByCourseName(newCourse.CourseID);
            Assert.IsNull(dbCourse);
        }

        [TestMethod]
        public void TestCourseDao_GetCourseByCourseName()
        {
            Course course = CourseDao.GetCourseByCourseName("Chinese");
            Assert.IsNotNull(course);

            Console.WriteLine("課程編號為 = " + course.CourseID);
            Console.WriteLine("課程名稱為 = " + course.CourseName);
            Console.WriteLine("課程描述為 = " + course.CourseDescription);
        }

    }
}
