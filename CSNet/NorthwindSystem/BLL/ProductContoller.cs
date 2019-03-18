using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using NorthwindSystem.Data;
//obtains the <T> definitions
using NorthwindSystem.DAL;
// obtains the Context class
#endregion


namespace NorthwindSystem.BLL
{
    //this class need to be called from another class(es)
    //this class is part of the system interface to the web application
    //this class is the entry point to the northwind system and/or any other client that needs to get to the northwind DB
    // this class needs to be public
    public class ProductController
    {
        //this method will receive a value that represents the ProductID
        //this method will forward the the value to the DbSet<T> in the DbContext Class for processing
        //this method will return an instance of product
        // this method must be public
        public Product Product_Get(int productid)
        {
            // the instantiation of the dbContext will be done in a transaction using group
            using (var context = new NorthwindContext())
            {
                //return the results of the method call
                //context points to the DAL context class
                //Products is the DbSet<T>
                //.Find (pKey value) looks for a set record whom's primary key is equal to the supplied value
                return context.Products.Find(productid);
            }
        }
        //this method will return all records of a DbSet<T>
        //no parameter value is necessary
        public List<Product> Product_List()
        {
            using (var context = new NorthwindContext())
            {
                return  ;
            }
        }
    }
}
