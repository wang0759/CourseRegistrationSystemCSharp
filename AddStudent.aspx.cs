using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab7
{
    public partial class AddStudent : System.Web.UI.Page
    {   //public string id;
        public string name;
        public List<Student> registeredStudent = new List<Student>();  // A NEW list to hold all registeredStudent
        private string studentTpye;//field

        protected void Page_Load(object sender, EventArgs e)
        {
          // we did not initial the session, how could we use it here? 
           registeredStudent = (List<Student>)Session["students"]; //retrieve objects from session on load
            if (registeredStudent == null) 
            {
                registeredStudent = new List<Student>();
            }
            if(registeredStudent.Count>0)
            {
                warn.Attributes.Add("style", "display:none");   //disable the warn tablecell
            }
            else
            {
                warn.Attributes.Remove("style");          //to remove the warn
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {    
            name = txtName.Text;//to store the name
            studentTpye = dpdStudentType.SelectedValue;

            txtName.Text = "";  //to make the button empty when clicked
            dpdStudentType.SelectedIndex = -1; //to make the studentType return to default

            if (name != "" && studentTpye != "")
            {
                Student addStudent=null;//create a null variable
                switch (studentTpye)  // get student type 
                {
                    case "1":
                        addStudent = new Fulltime(name);
                        break;
                    case "2":
                        addStudent = new ParttimeStudent(name);
                        break;
                    case "3":
                        addStudent = new CoopStudent(name);
                        break;
                }
                //Student addStudent = new Student(name);
                registeredStudent.Add(addStudent);
               
                Session["students"] = registeredStudent; //store objects into session["students"]

            }
            if (registeredStudent.Count > 0)
            {
                warn.Attributes.Add("style", "display:none");
            }
            else
            {
                warn.Attributes.Remove("style");
            }
        }

    }


       
    }
