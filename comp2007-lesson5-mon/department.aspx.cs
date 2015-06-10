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
    public partial class department : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if page isn't posted back, check url for an id to see know add or edit
            if(!IsPostBack)
            {
                if(Request.QueryString.Keys.Count > 0)
                {
                    //we have a url parameter id the count is > 0 so populate the form
                    getDepartment();
                }
            }
        }
        protected void getDepartment()
        {
            //connect
            using(DefaultConnection conn = new DefaultConnection())
            {
                //get the id from url parameter ans store in a variable
                Int32 DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);

                var d = (from dep in conn.Departments
                         where dep.DepartmentID == DepartmentID
                         select dep).FirstOrDefault();

                //populate the from from our department object
                txtname.Text = d.Name;
                txtBudget.Text = d.Budget.ToString();

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //connect
            using(DefaultConnection conn = new DefaultConnection())
            {
                //instantiate a new department object in memory
                Department d = new Department();

                //fill the properties of our object from the form inputs
                d.Name = txtname.Text;
                d.Budget = Convert.ToDecimal(txtBudget.Text);

                //decide if updating or adding then save
                if (Request.QueryString.Count > 0)
                {               
                    d.DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);
                }
                                 
                conn.Departments.Add(d);
                conn.SaveChanges();

                //redirect to the updated departments page
                Response.Redirect("departments.aspx");
            }
        }
    }
}