using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7
{
    public class CoopStudent : Student
    {
        public static int MaxNumOfCourses { get; set; }
        public static int MaxWeeklyHours { get; set; }

        public CoopStudent(string name):base(name)
        {
            //Student student = new Student("a");
        }

        public override void RegisterCourses(List<Course> selectedCourses)
        {
            if (selectedCourses.Count <= MaxNumOfCourses) // max num of courses selected
            {
                int totalWeeklyHours = 0;

                foreach (Course course in selectedCourses)//get totalWeeklyHours
                {
                    totalWeeklyHours += course.WeeklyHours;
                }

                if (totalWeeklyHours <= MaxWeeklyHours)  
                {
                    base.RegisterCourses(selectedCourses);//call the function
                }
                else
                {
                    throw new Exception("Your selection exceeds the maximum weekly hours: " + MaxWeeklyHours);
                }
            }
            else
            {
                throw new Exception("Your selection exceeds the maximum number of course: " + MaxNumOfCourses);
            }

        }
        public override string ToString()  //overide the name is ToString.
        {
            return string.Format("{0} - {1} (Coop)", Id, Name);
        }
    }
}