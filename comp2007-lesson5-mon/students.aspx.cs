using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//reference entity framework models
using comp2007_lesson5_mon.Models;
using System.Web.ModelBinding;

namespace comp2007_lesson5_mon
{
    public partial class students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //fill the grid
            if (!IsPostBack)
            {
                GetStudents();
            }
        }
        protected void GetStudents()
        {
            //connect using our connection string from web.config and EF context class
            using (DefaultConnection conn = new DefaultConnection())
            {

                //use link to query the students model
                var studs = from d in conn.Students
                            select d;

                //bind the query result to the gridview       
                grdStudents.DataSource = studs.ToList();
                grdStudents.DataBind();
            }
        }

        protected void grdStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //connect
            using (DefaultConnection conn = new DefaultConnection())
            {
                //get the selected studentID
                Int32 StudentID = Convert.ToInt32(grdStudents.DataKeys[e.RowIndex].Values["StudentID"]);

                var d = (from stud in conn.Students
                         where stud.StudentID == StudentID
                         select stud).FirstOrDefault();

                //process the delete
                conn.Students.Remove(d);
                conn.SaveChanges();

                //update the grid
                GetStudents();
            }
        }

        public int StudentID { get; set; }
        public string FirstMidName { get; set; }
        public string LastName { get; set; }
        public decimal EnrollmentDate { get; set; }
    }
}