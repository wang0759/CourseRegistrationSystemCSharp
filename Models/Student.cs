using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7
{

    public class Student
    {
        //A property is like a combination of a variable and a method, 
        //and it has two methods: a get and a set method
        public string Id { get; }//property
        public string Name { get; }//property
        public List<Course> RegisteredCourses { get; }//property
        public Student(string name) // constructor
        {
            Random generator = new Random();
            Id = generator.Next(900000,999999).ToString("D6");
            Name = name; // pass the name in parameter to property Name
            RegisteredCourses = new List<Course>(); // instance; assign the value otherwise: Object reference not set to an instance of an object.
        }

        //This method first removes all elements in the RegisteredCourse and then adds the selectedCourses to the RegisteredCourse.
        public virtual void RegisterCourses(List<Course> selectedCourses)
        {
            RegisteredCourses.Clear();//method  to make the list empty
            RegisteredCourses.AddRange(selectedCourses);
        }

        //This method returns the calculated total hours of all registered courses by the student
        public int TotalWeeklyHours()
        {
         int totalWeeklyHours=0; 
 
            foreach( Course course in RegisteredCourses)
            {
                totalWeeklyHours += course.WeeklyHours; // to call the property of WeeklyHours in Course.cs
            }
            return totalWeeklyHours;
        }




    }
}