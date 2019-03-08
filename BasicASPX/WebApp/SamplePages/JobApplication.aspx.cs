using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class JobApplication : System.Web.UI.Page
    {
        //this is a temporary storage area becasue we are not using a database
        public static List<GridViewData> gvCollection;


        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
            if(!Page.IsPostBack)
            {
                gvCollection = new List<GridViewData>();
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string fullname = FullName.Text;
            string emailaddress = EmailAddress.Text;
            string phonenumber = PhoneNumber.Text;
            string fullorparttime = FullOrPartTime.SelectedValue;

            //the checkbox list is a collection of items (rows)
            //we can traverse a collection using a loop: foreach
            //one each row of the collection you can process its data

            string jobs = "";

            foreach(ListItem jobrow in Jobs.Items)
            {
                if(jobrow.Selected)
                {
                    jobs += jobrow.Text + " ";
                }
            }

            //place the data on the data collection
            gvCollection.Add(new GridViewData(fullname, emailaddress, phonenumber, fullorparttime, jobs));

            //display the collection of data
            //we would like to display the data in a tabular format
            //we will use the gridview control to display the tabular format

            JobApplicantList.DataSource = gvCollection;
            JobApplicantList.DataBind();
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            //assuming for this example all data is valid
            FullName.Text = "";
            EmailAddress.Text = "";
            PhoneNumber.Text = "";
            FullOrPartTime.SelectedIndex = -1;
            Jobs.ClearSelection();


        }
    }
}