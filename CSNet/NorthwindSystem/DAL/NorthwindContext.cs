using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces

//using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel.DataAnnotations;
using System.Data.Entity; // for the entity framework ADO.Net stuff
using NorthwindSystem.Data; // for the <T> definitions

#endregion

// this class needs to have Access to ADO.Net in entity framework
// the nuget package manager will have the entity framework. Install
//this project needs the assembly System.Data.Entity
//this project needs the a referance to your .Data project 
//this project needs to use the following namespaces
// a) System.Data.Entity
// b) .Data project namespace
namespace NorthwindSystem.DAL
{
    //the class access is restriced to requests from within the
    // library the class exists in: internal


    //the class inherits (ties to entityframework) the class DbContext

    internal class NorthwindContext : DbContext
    {
        //setup you class default constructor to supply your connection string name to the dbContext
        // inherited (base) class
        public NorthwindContext() : base("NWDB")
        {

        }

        //create an EntityFramework DbSet<T> for each mapped sql table
        //<T> is your class in the .Data project 
        //this is a property
        public DbSet<Product> Products { get; set; }
        
    }
}
