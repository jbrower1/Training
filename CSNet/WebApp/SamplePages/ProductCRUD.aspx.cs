using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using NorthwindSystem.Data;
using NorthwindSystem.Data.Views;
using NorthwindSystem.BLL;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;

#endregion

namespace WebApp.NorthwindPages
{
    public partial class ProductCRUD : System.Web.UI.Page
    {
        List<string> errormsgs = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            //clear out all old messages from the Datalist Control
            Message.DataSource = null;
            Message.DataBind();

            //Page initialization
            if (!Page.IsPostBack)
            {
                BindProductList();
                BindSupplierList();
                BindCategoryList();

            }
        }

        //use this method to discover the inner most error message.
        //this rotuing has been created by the user
        protected Exception GetInnerException(Exception ex)
        {
            //drill down to the inner most exception
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }

        //use this method to load a DataList with a variable
        //number of message lines.
        //each line is a string
        //the strings (lines) are passed to this routine in
        //   a List<string>
        //second parameter is the bootstrap cssclass
        protected void LoadMessageDisplay(List<string> errormsglist, string cssclass)
        {
            Message.CssClass = cssclass;
            Message.DataSource = errormsglist;
            Message.DataBind();
        }
        protected void BindProductList()
        {
            try
            {
                ProductController sysmgr = new ProductController();

                List<Product> datainfo = sysmgr.Product_List();

                datainfo.Sort((x, y) => x.ProductName.CompareTo(y.ProductName));
                ProductList.DataSource = datainfo;
                ProductList.DataTextField = nameof(Product.ProductName);
                ProductList.DataValueField = nameof(Product.ProductID);
                ProductList.DataBind();
                ProductList.Items.Insert(0, "select ....");
            }
            catch (Exception ex)
            {

                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");


            }
        }
        protected void BindSupplierList()
        {
            try
            {
                SupplierController sysmgr = new SupplierController();

                List<Supplier> datainfo = sysmgr.Supplier_List();

                datainfo.Sort((x, y) => x.CompanyName.CompareTo(y.CompanyName));
                SupplierList.DataSource = datainfo;
                SupplierList.DataTextField = nameof(Supplier.CompanyName);
                SupplierList.DataValueField = nameof(Supplier.SupplierID);
                SupplierList.DataBind();
                SupplierList.Items.Insert(0, "select ....");
            }
            catch (Exception ex)
            {

                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");


            }
        }
        protected void BindCategoryList()
        {
            try
            {
                CategoryController sysmgr = new CategoryController();

                List<Category> datainfo = sysmgr.Category_List();

                datainfo.Sort((x, y) => x.CategoryName.CompareTo(y.CategoryName));
                CategoryList.DataSource = datainfo;
                CategoryList.DataTextField = nameof(Category.CategoryName);
                CategoryList.DataValueField = nameof(Category.CategoryID);
                CategoryList.DataBind();
                CategoryList.Items.Insert(0, "select ....");
            }
            catch (Exception ex)
            {

                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");


            }
        }
        protected void Search_Click(object sender, EventArgs e)
        {

        }

        protected void Clear_Click(object sender, EventArgs e)
        {

        }

        protected void AddProduct_Click(object sender, EventArgs e)
        {
            //if(Page.IsValid)
            //{
            //add any additional logic validation required for proccessing

            //in this example we will assume the SupplierID and CategoryID are required
            if (SupplierList.SelectedIndex == 0)
            {
                errormsgs.Add("Please select Supplier");


            }
            if (CategoryList.SelectedIndex == 0)
            {
                errormsgs.Add("Please select a Category");


            }
            //all code behind logical validation errors are captured and reported at once
            if (errormsgs.Count() > 0)
            {
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                try
                {
                    //create an instance of product 
                    Product item = new Product();

                    //collect the data from the web form and place in the product instance
                    item.ProductName = ProductName.Text;
                    item.SupplierID = int.Parse(SupplierList.SelectedValue);
                    item.CategoryID = int.Parse(CategoryList.SelectedValue);
                    item.QuantityPerUnit = string.IsNullOrEmpty(QuantityPerUnit.Text.Trim()) ? null : QuantityPerUnit.Text.Trim();

                    if (string.IsNullOrEmpty(UnitPrice.Text))
                    {
                        item.UnitPrice = null;
                    }
                    else
                    {
                        item.UnitPrice = decimal.Parse(UnitPrice.Text);
                    }

                    if (string.IsNullOrEmpty(UnitsInStock.Text))
                    {
                        item.UnitsInStock = null;
                    }
                    else
                    {
                        item.UnitsInStock = Int16.Parse(UnitsInStock.Text);
                    }

                    if (string.IsNullOrEmpty(UnitsOnOrder.Text))
                    {
                        item.UnitsOnOrder = null;
                    }
                    else
                    {
                        item.UnitsOnOrder = Int16.Parse(UnitsOnOrder.Text);
                    }

                    if (string.IsNullOrEmpty(ReorderLevel.Text))
                    {
                        item.ReorderLevel = null;
                    }
                    else
                    {
                        item.ReorderLevel = Int16.Parse(ReorderLevel.Text);
                    }
                    //handling of the discontinued can be done mannually or logicly
                    item.Discontinued = false;

                    //connect to the apropriate BLL controller
                    ProductController sysmgr = new ProductController();



                    //Issue a call to the apropriate BLL controller method

                    int newProductID = sysmgr.Product_Add(item);

                    //handle results
                    errormsgs.Add(ProductName.Text + " has been added to the database with a key of " + newProductID.ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-success");

                    // also if any controll uses this new instance for a query or other action, you must update (refresh) that control
                    BindProductList();
                    ProductID.Text = newProductID.ToString();
                    ProductList.SelectedValue = ProductID.Text;

                }
                catch (DbUpdateException ex)
                {
                    UpdateException updateException = (UpdateException)ex.InnerException;
                    if (updateException.InnerException != null)
                    {
                        errormsgs.Add(updateException.InnerException.Message.ToString());
                    }
                    else
                    {
                        errormsgs.Add(updateException.Message);
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            errormsgs.Add(validationError.ErrorMessage);
                        }
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }

            }

            //}
        }

        protected void UpdateProduct_Click(object sender, EventArgs e)
        {
            //if(Page.IsValid)
            //{
            //add any additional logic validation required for proccessing

            //in this example we will assume the SupplierID and CategoryID are required
            if (SupplierList.SelectedIndex == 0)
            {
                errormsgs.Add("Please select Supplier");


            }
            if (CategoryList.SelectedIndex == 0)
            {
                errormsgs.Add("Please select a Category");


            }
            //all code behind logical validation errors are captured and reported at once
            if (errormsgs.Count() > 0)
            {
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                try
                {
                    //create an instance of product 
                    Product item = new Product();

                    //collect the data from the web form and place in the product instance

                    //on an update you must ensure that the primary key value exists for use by the update
                    int productid = 0;
                    if(!int.TryParse(ProductID.Text.Trim(), out productid))
                    {
                        errormsgs.Add("Invalid or missing Product ID");
                    }


                    //on the update the primary identity key value MUST ALSO be loaded to the instance
                    item.ProductID = int.Parse(ProductID.Text.Trim());

                    item.ProductName = ProductName.Text;
                    item.SupplierID = int.Parse(SupplierList.SelectedValue);
                    item.CategoryID = int.Parse(CategoryList.SelectedValue);
                    item.QuantityPerUnit = string.IsNullOrEmpty(QuantityPerUnit.Text.Trim()) ? null : QuantityPerUnit.Text.Trim();

                    if (string.IsNullOrEmpty(UnitPrice.Text))
                    {
                        item.UnitPrice = null;
                    }
                    else
                    {
                        item.UnitPrice = decimal.Parse(UnitPrice.Text);
                    }

                    if (string.IsNullOrEmpty(UnitsInStock.Text))
                    {
                        item.UnitsInStock = null;
                    }
                    else
                    {
                        item.UnitsInStock = Int16.Parse(UnitsInStock.Text);
                    }

                    if (string.IsNullOrEmpty(UnitsOnOrder.Text))
                    {
                        item.UnitsOnOrder = null;
                    }
                    else
                    {
                        item.UnitsOnOrder = Int16.Parse(UnitsOnOrder.Text);
                    }

                    if (string.IsNullOrEmpty(ReorderLevel.Text))
                    {
                        item.ReorderLevel = null;
                    }
                    else
                    {
                        item.ReorderLevel = Int16.Parse(ReorderLevel.Text);
                    }
                    //handling of the discontinued needs to take the current value from the form
                    item.Discontinued = Discontinued.Checked;

                    //connect to the apropriate BLL controller
                    ProductController sysmgr = new ProductController();



                    //Issue a call to the apropriate BLL controller method

                    int rowsaffected = sysmgr.Product_Update(item);

                    if(rowsaffected == 0)
                    {
                        errormsgs.Add(ProductName.Text + " has not been Updated, Search for Product again");
                        LoadMessageDisplay(errormsgs, "alert alert-warning");
                        BindProductList();
                    }
                    else
                    {
                        //success
                        errormsgs.Add(ProductName.Text + " has been Updated ");
                        LoadMessageDisplay(errormsgs, "alert alert-success");
                        BindProductList();
                        ProductList.SelectedValue = ProductID.Text;
                    }

                    //handle results
                    

                    // also if any controll uses this new instance for a query or other action, you must update (refresh) that control
                   

                }
                catch (DbUpdateException ex)
                {
                    UpdateException updateException = (UpdateException)ex.InnerException;
                    if (updateException.InnerException != null)
                    {
                        errormsgs.Add(updateException.InnerException.Message.ToString());
                    }
                    else
                    {
                        errormsgs.Add(updateException.Message);
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            errormsgs.Add(validationError.ErrorMessage);
                        }
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }

            }

            //}
        }

        protected void RemoveProduct_Click(object sender, EventArgs e) //may be incomplete
        {
            if (SupplierList.SelectedIndex == 0)
            {
                errormsgs.Add("Please select Supplier");


            }
            if (CategoryList.SelectedIndex == 0)
            {
                errormsgs.Add("Please select a Category");


            }
            //all code behind logical validation errors are captured and reported at once
            if (errormsgs.Count() > 0)
            {
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                try
                {
                    //create an instance of product 
                    Product item = new Product();

                    //collect the data from the web form and place in the product instance

                    //on an update you must ensure that the primary key value exists for use by the update
                    int productid = 0;
                    if (!int.TryParse(ProductID.Text.Trim(), out productid))
                    {
                        errormsgs.Add("Invalid or missing Product ID");
                    }


                    //on the update the primary identity key value MUST ALSO be loaded to the instance
                    item.ProductID = int.Parse(ProductID.Text.Trim());

                    item.ProductName = ProductName.Text;
                    item.SupplierID = int.Parse(SupplierList.SelectedValue);
                    item.CategoryID = int.Parse(CategoryList.SelectedValue);
                    item.QuantityPerUnit = string.IsNullOrEmpty(QuantityPerUnit.Text.Trim()) ? null : QuantityPerUnit.Text.Trim();

                    if (string.IsNullOrEmpty(UnitPrice.Text))
                    {
                        item.UnitPrice = null;
                    }
                    else
                    {
                        item.UnitPrice = decimal.Parse(UnitPrice.Text);
                    }

                    if (string.IsNullOrEmpty(UnitsInStock.Text))
                    {
                        item.UnitsInStock = null;
                    }
                    else
                    {
                        item.UnitsInStock = Int16.Parse(UnitsInStock.Text);
                    }

                    if (string.IsNullOrEmpty(UnitsOnOrder.Text))
                    {
                        item.UnitsOnOrder = null;
                    }
                    else
                    {
                        item.UnitsOnOrder = Int16.Parse(UnitsOnOrder.Text);
                    }

                    if (string.IsNullOrEmpty(ReorderLevel.Text))
                    {
                        item.ReorderLevel = null;
                    }
                    else
                    {
                        item.ReorderLevel = Int16.Parse(ReorderLevel.Text);
                    }
                    //handling of the discontinued needs to take the current value from the form
                    item.Discontinued = Discontinued.Checked;

                    //connect to the apropriate BLL controller
                    ProductController sysmgr = new ProductController();



                    //Issue a call to the apropriate BLL controller method

                    int rowsaffected = sysmgr.Product_Delete(int.Parse(ProductID.Text.Trim()));

                    if (rowsaffected == 0)
                    {
                        errormsgs.Add(ProductName.Text + " has not been Discontinued, Search for Product again");
                        LoadMessageDisplay(errormsgs, "alert alert-warning");
                        BindProductList();
                    }
                    else
                    {
                        //success
                        errormsgs.Add(ProductName.Text + " has been Discontinued ");
                        LoadMessageDisplay(errormsgs, "alert alert-success");
                        BindProductList();
                        //ONLY if it is a LOGICAL DELETE
                        ProductList.SelectedValue = ProductID.Text;
                        Discontinued.Checked = true;
                    }

                    //handle results


                    // also if any controll uses this new instance for a query or other action, you must update (refresh) that control


                }
                catch (DbUpdateException ex)
                {
                    UpdateException updateException = (UpdateException)ex.InnerException;
                    if (updateException.InnerException != null)
                    {
                        errormsgs.Add(updateException.InnerException.Message.ToString());
                    }
                    else
                    {
                        errormsgs.Add(updateException.Message);
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            errormsgs.Add(validationError.ErrorMessage);
                        }
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }
    }
}