using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additional Namespaces
using NorthwindSystem.Data; //obtains the <T> devinitions
using NorthwindSystem.DAL;  //obtains the context class
using System.Data.SqlClient; //required for the parameter used in SQL Proc calls
#endregion

namespace NorthwindSystem.BLL
{
    //this class needs to be called from another class(es)
    //this class is part of the system interface to the
    //   web application (and/or any other client that
    //   needs to get to the Northwind database)
    //this class is the enter point into the Northwind system
    //this class needs to be public
    public class ProductController
    {
        //this method will receive a value that
        //   represents the ProductID
        //this method will forward the value to
        //   the DbSet<T> in the DbContext class
        //   for processing
        //this method will return an instance of Product
        //this method must be public
        public Product Product_Get(int productid)
        {
            //the instantiation of the DbContext will
            //  be done in a transaction using group
            using (var context = new NorthwindContext())
            {
                //return the results of the method call
                //context points to the DAL context class
                //Products is theDbSet<T>
                //.Find(pkey value) looks for a set record
                //     whom's primary key is equal to the
                //     supplied value
                return context.Products.Find(productid);
            }
        }

        //this method will return all records of a DbSet<T>
        //no parameter value is necessarys
        public List<Product> Product_List()
        {
            using (var context = new NorthwindContext())
            {
                return context.Products.ToList();
            }
        }
        //this method will querry the DbSet<T> using an sql procedure
        //the querry will be against a non primary key field
        // the result return will still be the complete entity <T> record

        //we need to add a using clause to Dystem.Data.Entity
        // to our class

        // input: category id
        //output: List<Product> matching category id
        public List<Product> Products_GetByCategory(int categoryid)
        {
            using (var context = new NorthwindContext())
            {
                //generally datasets from DbSet calls return as a datatype of IEnumerable<T>
                //this IEnumerable dataset will be turned into a list using .ToList()
                IEnumerable<Product> results = context.Database.SqlQuery<Product>(
                    "Products_GetByCategories @CategoryID", new SqlParameter("CategoryID",categoryid));
                return results.ToList();

               
                //IEnumerable<Product> results = context.Database.SqlQuery<Product>(
                //    "Products_GetByCategories @CategoryID, @Second", new SqlParameter("CategoryID", categoryid), new SqlParameter("SomethingID, somethingid"));
                //return results.ToList();
            }
        }
    }
}
