using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class ContestEntry : System.Web.UI.Page
    {

        public static List<ContestData> ContestCollection;

        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
            
            if (!Page.IsPostBack)
            {
                ContestCollection = new List<ContestData>();
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {

            //this test will fire the validation cotrols on the server side
            //if aditional validation is required, do that first
            if (Page.IsValid)
            {
                if(Terms.Checked)
                {
                    //the user has agreed to the contest terms, collect the data, create/ load a contest entry to the collection , Display the collection
                }
                else
                {
                    Message.Text = "You did not agree to the contest terms your entry is denied";
                }
                //string firstname = FirstName.Text;
                //string lastname = LastName.Text;
                //string streetaddress1 = StreetAddress1.Text;
                //string streetaddress2 = StreetAddress2.Text;
                //string city = City.Text;
                //string province = Province.Text;
                //string postalcode = PostalCode.Text;
                //string emailaddress = EmailAddress.Text;


                ////the checkbox list is a collection of items (rows)
                ////we can traverse a collection using a loop: foreach
                ////one each row of the collection you can process its data

                //string entrants = "";

                //foreach (ListItem jobrow in Jobs.Items)
                //{
                //    if (jobrow.Selected)
                //    {
                //        jobs += jobrow.Text + " ";
                //    }
                //}

                ////place the data on the data collection
                //gvCollection.Add(new GridViewData(fullname, emailaddress, phonenumber, fullorparttime, jobs));

                ////display the collection of data
                ////we would like to display the data in a tabular format
                ////we will use the gridview control to display the tabular format

                //JobApplicantList.DataSource = gvCollection;
                //JobApplicantList.DataBind();
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            FirstName.Text = "";
            LastName.Text = "";
            StreetAddress1.Text = "";
            StreetAddress2.Text = "";
            City.Text = "";
            Province.Text = "";
            PostalCode.Text = "";
            EmailAddress.Text = "";
            Terms.Checked = false;
            CheckAnswer.Text = "";

        }
    }
}