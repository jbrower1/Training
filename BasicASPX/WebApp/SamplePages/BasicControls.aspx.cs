using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class BasicControls : System.Web.UI.Page
    {
        //create a static list<T> that will hang around between postings of a web page
        //this could also have been done using a view sate variable
        //using a viewstate variable would reqire the user to retrive the data on each posting
        public static List<DDLClass> DataCollection;


        protected void Page_Load(object sender, EventArgs e)
        {
            //page load executes each and every time there is a posting to this page
            //page load is executed before any submit events
            
            //this method is and exelent place to do form initialization
            // you can test your postings using Page.IsPostBack
            
            //page.IsPostBack is the same as IsPost in our razor
            if(!Page.IsPostBack)
            {
                //this code will be executed only on the first pass to this page

                //create an instance for the static data collection
                DataCollection = new List<DDLClass>();

                //Add instances to this collection using the DDL gready constructor
                DataCollection.Add(new DDLClass(1, "COMP1008"));
                DataCollection.Add(new DDLClass(2, "CPSC1517"));
                DataCollection.Add(new DDLClass(3, "DMIT2018"));
                DataCollection.Add(new DDLClass(4, "DMIT1508"));
                //Sorting a list of <T>
                //using the .Sort() method
                //(x,y) this represents any two items in your list
                //Compare x.Field to y.Field; acending
                //Compare y.field to x.field; decending
                DataCollection.Sort((x,y) => x.DisplayField.CompareTo(y.DisplayField));

                //put the data collection into the dropdown list
                //a) assign the collection to the controls DataSource
                CollectionList.DataSource = DataCollection;

                //b) assign the field names to the properties of the drop down list for data association
                //data value field represents the value of the item
                //data text value represents the display value of the line item
                CollectionList.DataValueField = "ValueField";
                CollectionList.DataTextField = "DisplayField";
                //CollectionList.DataTextField = nameof(DDLClass.DisplayField);

                //c) bind the data to the web control
                //NOTE: this statment is NOT required in a windows form application
                CollectionList.DataBind();

                //Can one put a promt on their drop down list control
                //yes
                CollectionList.Items.Insert(0, "select ...");

            }



        }

        protected void SubmitButtonChoice_Click(object sender, EventArgs e)
        {
            MessageLabel.Text = "You Pressed the Submit Button";

            //to grab the contents of a control will depend on the access technique of the control
            //for a TextBox, Label, Literal use .Text
            //for Lists(RadioButtonList, DropDownList) you may use
            //a) .SelectedValue -> assorciate data value field
            //b) .SelectedIndex -> the pysical index position in the list
            //c) .SelectedItem -> associate data display field
            //for a checkbox use .Checked (true or false)

            //for the most part, all data from a control returns as a string execpt for boolean tpye controls

            string submitchoice = TextBoxNumberChoice.Text;
            int anum = 0;
            if(string.IsNullOrEmpty(submitchoice))
            {
                MessageLabel.Text = "Enter a number from 1 to 4.";
            }
            else if(!int.TryParse(submitchoice, out anum ))
            {
                MessageLabel.Text = "Entered value must be a number";

            }
            else if(anum >4 || anum < 1)
            {
                MessageLabel.Text = "Entered value must be a number from 1 to 4";
            }
            else
            {
                //when positioning in a list it is best to position using the selected value
                //UNLESS you wish to position in a specific physical location such as your prompt line
                //then use selected index

                //SelectedValue expects a string value
                //Selected index expects a numeric value
                //
                RadioButtonListChoice.SelectedValue = submitchoice;
                
                //boolean controls are set using true or false
                if(submitchoice.Equals("2") || submitchoice.Equals("3"))
                {
                    CheckBoxChoice.Checked = true;
                }
                else
                {
                    CheckBoxChoice.Checked = false;
                }

                CollectionList.SelectedValue = submitchoice;

                //Display label will show the various values obtained from a list using
                //SelectedValue, SelectedIndex and SelectedItem

                DisplayReadOnly.Text = CollectionList.SelectedItem.Text + " at index " + CollectionList.SelectedIndex + " has a value of " + CollectionList.SelectedValue;
            }
        }
        protected void DropDownList_Click(object sender, EventArgs e)
        {
            MessageLabel.Text = "You Pressed the List Submit Button";
            string submitchoice = CollectionList.Text;
            int anum = 0;
            if (string.IsNullOrEmpty(submitchoice))
            {
                MessageLabel.Text = "Enter a number from 1 to 4.";
            }
            else if (!int.TryParse(submitchoice, out anum))
            {
                MessageLabel.Text = "Entered value must be a number";

            }
            else if (anum > 4 || anum < 1)
            {
                MessageLabel.Text = "Entered value must be a number from 1 to 4";
            }
            else
            {
                //when positioning in a list it is best to position using the selected value
                //UNLESS you wish to position in a specific physical location such as your prompt line
                //then use selected index

                //SelectedValue expects a string value
                //Selected index expects a numeric value
                //
                TextBoxNumberChoice.Text = submitchoice;

                RadioButtonListChoice.SelectedValue = submitchoice;

                //boolean controls are set using true or false
                if (submitchoice.Equals("2") || submitchoice.Equals("3"))
                {
                    CheckBoxChoice.Checked = true;
                }
                else
                {
                    CheckBoxChoice.Checked = false;
                }

                

                //Display label will show the various values obtained from a list using
                //SelectedValue, SelectedIndex and SelectedItem

                DisplayReadOnly.Text = CollectionList.SelectedItem.Text + " at index " + CollectionList.SelectedIndex + " has a value of " + CollectionList.SelectedValue;
            }
        }
        }
}