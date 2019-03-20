using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using NorthwindSystem.BLL;  //points to the controller class
using NorthwindSystem.Data; //points to the record descriptions
#endregion

namespace WebApp.SamplePages
{
    public partial class SqlProcQueries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // clear old messages
            MessageLabel.Text = "";

            //load the drop down list on the first time processing this page
            //all calls should be done in user friendly error handling
            if (!Page.IsPostBack)
            {


                try
                {

                    //when the page is first loaded, obtain the complete list of categories from the database

                    CategoryController sysmgr = new CategoryController();

                    List<Category> datainfo = sysmgr.Category_List();

                    //sort this list alphabetically
                    datainfo.Sort((x, y) => x.CategoryName.CompareTo(y.CategoryName));
                    //assign the data to the drop down list control
                    CategoryList.DataSource = datainfo;
                    //indicate the DataTextField and DataValueField
                    CategoryList.DataTextField = nameof(Category.CategoryName);
                    CategoryList.DataValueField = nameof(Category.CategoryID);
                    //bind the resource
                    CategoryList.DataBind();
                    //add a prompt
                    CategoryList.Items.Insert(0, "select ...");
                }
                catch (Exception ex)
                {

                    MessageLabel.Text = ex.Message;
                }
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //Ensure a selection was made
            if (CategoryList.SelectedIndex == 0)
            {
                MessageLabel.Text = "Select a category of products to display";
            }
            else
            {


                //within user fiendly error handling
                try
                {

                    //connect to the appropriate controller
                    ProductController sysmgr = new ProductController();

                    // issure a request to the controller's appropriate method
                    List<Product> datainfo = sysmgr.Products_GetByCategory(int.Parse(CategoryList.SelectedValue));

                    //check results

                    if(datainfo.Count()==0)
                    {
                        //   none( .Count()== 0 ): Message to user
                        MessageLabel.Text = "No Products for selected category";
                        //optionally clear out display
                        CategoryProductList.DataSource = null;
                        CategoryProductList.DataBind();
                    }
                    else
                    {

                        // found : load to gridview
                        //optional sort on product name
                        datainfo.Sort((x, y) => x.ProductName.CompareTo(y.ProductName));
                        CategoryProductList.DataSource = datainfo;
                        CategoryProductList.DataBind();
                    }

                }
                catch (Exception ex)
                {

                    MessageLabel.Text = ex.Message;
                }
                
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            CategoryList.ClearSelection();
            CategoryProductList.DataSource = null;
            CategoryProductList.DataBind();
        }
    }
}