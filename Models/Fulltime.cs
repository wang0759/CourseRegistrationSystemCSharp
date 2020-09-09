using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7
{
    public class Fulltime: Student
    {
        public static int MaxWeeklyHours { get; set; }//property

        public Fulltime(string name):base(name) //constructor
        {
            // why is this empty
        }

        public override void RegisterCourses(List<Course> selectedCourses)
        {
            int totalWeeklyHours = 0;

            foreach (Course course in selectedCourses) 
            {
                totalWeeklyHours += course.WeeklyHours;
            }

            if (totalWeeklyHours<=MaxWeeklyHours)
            {
                base.RegisterCourses(selectedCourses);//call the function
            }
            else
            {
                throw new Exception("Your selection exceeds the maximum weekly hours: " + MaxWeeklyHours);
            }
        }

        public override string ToString()  //overide from the Object class (base method for all method)
        {
            return string.Format("{0} - {1} (Full time)", Id, Name);
        }
    }

    
    
}