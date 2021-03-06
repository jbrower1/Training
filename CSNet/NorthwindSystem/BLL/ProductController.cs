﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additional Namespaces
using NorthwindSystem.Data; //obtains the <T> devinitions
using NorthwindSystem.DAL;  //obtains the context class
using System.Data.SqlClient; //required for the parameter used in SQL Proc calls
using System.ComponentModel;
#endregion

namespace NorthwindSystem.BLL
{
    //this class needs to be called from another class(es)
    //this class is part of the system interface to the
    //   web application (and/or any other client that
    //   needs to get to the Northwind database)
    //this class is the enter point into the Northwind system
    //this class needs to be public
    [DataObject]
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
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Product> Products_GetByCategory(int categoryid)
        {
            using (var context = new NorthwindContext())
            {
                //generally datasets from DbSet calls return as a datatype of IEnumerable<T>
                //this IEnumerable dataset will be turned into a list using .ToList()
                IEnumerable<Product> results = context.Database.SqlQuery<Product>(
                    "Products_GetByCategories @CategoryID", new SqlParameter("CategoryID", categoryid));
                return results.ToList();


                //IEnumerable<Product> results = context.Database.SqlQuery<Product>(
                //    "Products_GetByCategories @CategoryID, @Second", new SqlParameter("CategoryID", categoryid), new SqlParameter("SomethingID, somethingid"));
                //return results.ToList();
            }
        }

        public List<Product> Products_GetByPartialProductName(string partialname)
        {
            using (var context = new NorthwindContext())
            {
                IEnumerable<Product> results =
                    context.Database.SqlQuery<Product>("Products_GetByPartialProductName @PartialName",
                                    new SqlParameter("PartialName", partialname));
                return results.ToList();
            }
        }


        public List<Product> Products_GetBySupplierPartialProductName(int supplierid, string partialproductname)
        {
            using (var context = new NorthwindContext())
            {
                //sometimes there may be a sql error that does not like the new SqlParameter()
                //       coded directly in the SqlQuery call
                //if this happens to you then code your parameters as shown below then
                //       use the parm1 and parm2 in the SqlQuery call instead of the new....
                //don't know why but its weird
                //var parm1 = new SqlParameter("SupplierID", supplierid);
                //var parm2 = new SqlParameter("PartialProductName", partialproductname);
                IEnumerable<Product> results =
                    context.Database.SqlQuery<Product>("Products_GetBySupplierPartialProductName @SupplierID, @PartialProductName",
                                    new SqlParameter("SupplierID", supplierid),
                                    new SqlParameter("PartialProductName", partialproductname));
                return results.ToList();
            }
        }

        public List<Product> Products_GetForSupplierCategory(int supplierid, int categoryid)
        {
            using (var context = new NorthwindContext())
            {
                IEnumerable<Product> results =
                    context.Database.SqlQuery<Product>("Products_GetForSupplierCategory @SupplierID, @CategoryID",
                                    new SqlParameter("SupplierID", supplierid),
                                    new SqlParameter("CategoryID", categoryid));
                return results.ToList();
            }
        }

        public List<Product> Products_GetByCategoryAndName(int category, string partialname)
        {
            using (var context = new NorthwindContext())
            {
                IEnumerable<Product> results =
                    context.Database.SqlQuery<Product>("Products_GetByCategoryAndName @CategoryID, @PartialName",
                                    new SqlParameter("CategoryID", category),
                                    new SqlParameter("PartialName", partialname));
                return results.ToList();
            }
        }

        #region Insert, Update, and Delete of CRUD
        // returning the new identity primary key value is optional
        public int Product_Add(Product item)
        {
            //the webpage will create an instance of the Product entity and load the incomming web page data into the instance

            using (var context = new NorthwindContext())
            {
                //Step 1) Staging 
                // assign the incoming product instance to its apropriate DbSet<T>
                //the instance will not be placed on the database at this point in time
                //therefore the primary key value will not be available
                context.Products.Add(item);


                //step 2 Commit
                //during this instance the data instance will be placed on the database

                //if the commiting command in this method is NOT executed 
                // the staged instance will be rolled back

                //this code is being executed within a transaction

                //successful execution of the command will be a commit to the transaction
                //if the transaction is commited the new primary key will be in your instance

                //during this command execution any entity validation annotation is executed
                context.SaveChanges();

                //optionally this method is retuning the new primary key value
                return item.ProductID;
            }

        }

        //update will recieve an instance of <T> that contains the needed primary key values

        //the method will return the number of rows affected

        public int Product_Update(Product item)
        {
            using (var context = new NorthwindContext())
            {
                //sometimes you may have aditional fields on your entity that track dates and times that the record was altered
                // these fields should be set by the controller method and not be altered/set by the application user

                //assume that our entity has a LastModified date

                //item.LastModified = DateTime.Now;

                //stage 
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                //commit
                //the value reuturned from the SaveChanges() is the number of rows affected by the update
                return context.SaveChanges();
            }
        }

        //only the primary key is acually required for this proccess
        public int Product_Delete(int productid)
        {
            using (var context = new NorthwindContext())
            { 
                //physical delete
                //removal of the physical record from the database

                //Find the record on the database

                var existing = context.Products.Find(productid);


                //Remove found record

                //context.Products.Remove(existing);

                

                //logical delete
                //the record is NOT physically removed from the database
                //usually a flag of some sort is set on the record
                //instead of a .Remove, an update is accually done

                //Find the record on the database
                 existing.Discontinued = true;
                //alter the appropriate fields on the record which will apply the logical delete


                context.Entry(existing).State = System.Data.Entity.EntityState.Modified;
                

                //Commit and return the changes
                return context.SaveChanges();
            }
        }


        #endregion
    }
}
