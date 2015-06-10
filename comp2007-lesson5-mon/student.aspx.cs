using comp2007_lesson5_mon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//reference models
using comp2007_lesson5_mon.Models;
using System.Web.ModelBinding;

namespace comp2007_lesson5_mon
{
    public partial class student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if page isn't posted back, check url for an id to see know add or edit
            if (!IsPostBack)
            {
                if (Request.QueryString.Keys.Count > 0)
                {
                    //we have a url parameter id the count is > 0 so populate the form
                    getStudent();
                }
            }
        }

        protected void getStudent()
        {
            //connect
            using (DefaultConnection conn = new DefaultConnection())
            {
                //get the id from url parameter ans store in a variable
                Int32 StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                var d = (from dep in conn.Students
                         where dep.StudentID == StudentID
                         select dep).FirstOrDefault();

                //populate the from from our student object
                txtFirstName.Text = d.FirstMidName;
                txtLastName.Text = d.LastName;
                txtEnrollmentDate.Text = d.EnrollmentDate.ToString();

            }
        }

        protected void btnSave_Click1(object sender, EventArgs e)
        {
            //connect
            using (DefaultConnection conn = new DefaultConnection())
            {
                //instantiate a new student object in memory
                students d = new students();

                //fill the properties of our object from the form inputs
                d.FirstMidName = txtFirstName.Text;
                d.LastName = txtLastName.Text;
                d.EnrollmentDate = Convert.ToDecimal(txtEnrollmentDate.Text);

                //decide if updating or adding then save
                if (Request.QueryString.Count > 0)
                {
                    d.StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);
                }

                //conn.Students.Add(d);
                conn.SaveChanges();

                //redirect to the updated departments page
                Response.Redirect("students.aspx");
            }
        }

        protected void btnSave_Click1(object sender, EventArgs e)
        {

        }
    }
}