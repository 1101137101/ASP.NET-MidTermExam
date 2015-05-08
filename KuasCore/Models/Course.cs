using System;

namespace KuasCore.Models
{
    public class Course
    {
        public string CourseID { get; set; }

        public string CourseName { get; set; }

        public string CourseDescription { get; set; }

        public override string ToString()
        {
            return "Course: CourseID = " + CourseID + ", CourseName = " + CourseName + ", CourseDescription = " + CourseDescription + ".";
        }

    }
}
