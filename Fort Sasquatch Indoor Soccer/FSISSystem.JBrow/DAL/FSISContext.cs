using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces

//using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel.DataAnnotations;
using System.Data.Entity; // for the entity framework ADO.Net stuff
using FSISSystem.JBrow.Data; // for the <T> definitions

#endregion

namespace FSISSystem.JBrow.DAL
{
    internal class FSISContext : DbContext
    {
        //the class access is restriced to requests from within the
        // library the class exists in: internal


        //the class inherits (ties to entityframework) the class DbContext


        //setup you class default constructor to supply your connection string name to the dbContext
        // inherited (base) class
        public FSISContext() : base("FSIS_db")
        {

        }

        //create an EntityFramework DbSet<T> for each mapped sql table
        //<T> is your class in the .Data project 
        //this is a property

        public DbSet<Guardian> Guardians { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }



    }

}
