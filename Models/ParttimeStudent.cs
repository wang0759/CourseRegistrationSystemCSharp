using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7
{
    public class ParttimeStudent : Student
    {

        public static int MaxNumOfCourses { get; set; }//create here 1st, then get the value from global.asax

        public ParttimeStudent(string name):base(name)//? why :base(name) and empty?
        {
           //why empty here?
        }

        public override void RegisterCourses(List<Course> selectedCourses)
        {   //only need thd number of courses, no foreach needed.
            if (selectedCourses.Count <= MaxNumOfCourses)
            {
                base.RegisterCourses(selectedCourses);  // pass the para to base 
            }
            else
            {
                throw new Exception("Your selection exceeds the maximum number of course: " + MaxNumOfCourses);
            }
        }

        public override string ToString()  //overide from the Object class
        {
            return string.Format("{0} - {1} (Part time)", Id, Name);
        }
    }
}