using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Lab7
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Fulltime.MaxWeeklyHours = 16;
            ParttimeStudent.MaxNumOfCourses = 3;
            CoopStudent.MaxWeeklyHours = 4;
            CoopStudent.MaxNumOfCourses = 2;

        }
    }
}