using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Lab7
{
    public partial class RegisterCourse : System.Web.UI.Page
    {
       
        public int weeklyHours=0, numOfCourses = 0;

        // to call getAvailableCourses method
        List<Course> availableCourses = Helper.GetAvailableCourses();
        public List<Course> registeredCourse = new List<Course>();

        private List<Student> registeredStudents; //private field

        //initial load content
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack == false) // if it's not postback...
            {
                // list all students
                registeredStudents = (List<Student>)Session["students"]; //retrieve objects from session on load
                if (registeredStudents == null)
                {
                    registeredStudents = new List<Student>();
                }

                // add to the drpStudent list
                drpStudent.Items.Clear();
                drpStudent.Items.Add(new ListItem("Select...", "-1"));//initialization to a new original value;
                foreach(Student student in registeredStudents)
                {
                    drpStudent.Items.Add(new ListItem(student.ToString(), student.Id));//value will be Id; content will be each item of the dropdown (student.ToString()). ToString is the name of the method to be called. so confused. now lighted by my own careful observation!!
                }

                // all the possible course 
                for (int i = 0; i < availableCourses.Count; i++)
                {
                    Course course = availableCourses[i];
                    CheckBoxList1.Items.Add(course.Title + "-" + course.WeeklyHours + " hours/week");
                }
            }
        }

        protected void drpStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            studentCoursesLabel.Text = "";
            alert1.Text = "";
            //registeredStudents = (List<Student>)Session["students"];
            //foreach (Student student in registeredStudents)
            //{
            //    if (student.Id == drpStudent.SelectedValue)// ?? disappear when exceeds weeklyHours
            //    {
            //        studentCoursesLabel.Text = string.Format("Selected student has registered {0} course(s), {1} hours weekly.", student.RegisteredCourses.Count, student.TotalWeeklyHours());
            //        break;
            //    }
            //}
        }

        protected void Main(object sender, EventArgs e)
        {
            studentCoursesLabel.Text = "";
            alert1.Text = "";

            if (!rfvStudent.IsValid)
            {
                return;
            }

            List<Course> selectedCourses = new List<Course>();
            for (int i = 0; i < availableCourses.Count; i++)
            {
                Course course = availableCourses[i] as Course;
                if (CheckBoxList1.Items[i].Selected)
                {
                    Course selectedCourse = availableCourses[i];
                    selectedCourses.Add(selectedCourse);
                    weeklyHours += course.WeeklyHours;
                }
            }

            if(selectedCourses.Count == 0)
            {
                alert1.Text = "Select at least 1 course";
                return;
            }

            try
            {
                registeredStudents = (List<Student>)Session["students"];//make a new session for students
                for (int i = 0; i < registeredStudents.Count; i++)
                {
                    Student student = registeredStudents[i];  // index[i] is important
                    if (student.Id == drpStudent.SelectedValue)
                    {
                        if (drpStudent.SelectedItem.Text.Contains("Coop"))
                        {
                            CoopStudent coopStudent = (CoopStudent)student;//connect this student with CoopStudent class
                            coopStudent.RegisterCourses(selectedCourses);
                            registeredStudents[i] = coopStudent;
                        }
                        else if (drpStudent.SelectedItem.Text.Contains("Full"))
                        {
                            Fulltime fulltimeStudent = student as Fulltime;//casting to fulltime student
                            fulltimeStudent.RegisterCourses(selectedCourses);
                            registeredStudents[i] = fulltimeStudent;

                        }
                        else if (drpStudent.SelectedItem.Text.Contains("Part"))
                        {
                            ParttimeStudent parttimeStudent = (ParttimeStudent)student;
                            parttimeStudent.RegisterCourses(selectedCourses);
                            registeredStudents[i] = parttimeStudent;

                        }
                        Session["students"] = registeredStudents;
                    }
                }

                studentCoursesLabel.Text = string.Format("Selected student has registered {0} course(s), {1} hours weekly.", selectedCourses.Count, weeklyHours);
            }
            catch(Exception ex)
            {
                alert1.Text = ex.Message;
            }
        }
    }
}