using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7

{
    public class Course
    {
        private string code; // field
        private string title;
        private int weeklyHours;

        public string Code   // property
        {
            get { return code; }  // get method, read only
        }

        public string Title // property
        {
            get { return title; }
        }

        public int WeeklyHours // property
        {
            //provide public get and set methods, through properties, to access and update the value of a private field
            get { return weeklyHours; }  // get method
            set { weeklyHours = value; } // set method
        }

        //call this constructor in Main 
        public Course(string code, string title ) // constructor
        {
            this.code = code;
            this.title = title;
        }

        //public string Title { get; }
        //public int WeeklyHours { get; }

        //private Course(string title, int hours)
        //{
        //    Title = title;
        //    WeeklyHours = hours;
        //}
    }
}