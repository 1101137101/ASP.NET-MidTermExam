using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using KuasCore.Models;
using KuasCore.Services.Impl;
using Core;
using Spring.Context;
using Spring.Context.Support;
using KuasCore.Services;

namespace KuasCoreTests.Core
{
    [TestClass]
    public class ObjectFactoryUnitTest : AbstractDependencyInjectionSpringContextTests
    {

        #region Spring 單元測試必寫的內容

        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    //assembly://MyAssembly/MyNamespace/ApplicationContext.xml
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }

        #endregion

        [TestMethod]
        public void TestObjectFactory_GetObject1()
        {

            // 利用 Spring Object Name 來依賴尋找找出我們要的 Spring Object.
            IApplicationContext applicationContext = ContextRegistry.GetContext();
            ICourseService courseService = (ICourseService)applicationContext["courseService"];

            Course course = courseService.GetCourseByCourseName("Chinese");
            Assert.IsNotNull(course);

            Console.WriteLine("課程編號為 = " + course.CourseID);
            Console.WriteLine("課程名稱為 = " + course.CourseName);
            Console.WriteLine("課程描述為 = " + course.CourseDescription);

        }

        [TestMethod]
        public void TestObjectFactory_GetObject2()
        {

            // 利用 Spring Object Name 來依賴尋找找出我們要的 Spring Object.
            ICourseService employeeService = (ICourseService)ObjectFactory.GetObject("courseService");

            Course course = employeeService.GetCourseByCourseName("Chinese");
            Assert.IsNotNull(course);

            Console.WriteLine("課程編號為 = " + course.CourseID);
            Console.WriteLine("課程名稱為 = " + course.CourseName);
            Console.WriteLine("課程描述為 = " + course.CourseDescription);
        }

    }
}
