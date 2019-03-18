using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

#endregion

namespace NorthwindSystem.Data
{
    //the annotations used within the .Data project will require 
    //the system .ComponentModel.DataAnnotations assembelly 
    //

        //use an annotation the link this class to the appropriate sql table

        // sql [Table("name of sql table")]

         [Table("Products")]
    public class Product
    {

        // use annotation to identify primary key
        //1) Identity   pkey on sql table(considered default)
        // [Key] assumes identity pkey ending in ID or id
        //2) Compound   pkey on sql table
        // [Key, Column(Order=n)] where n is the numeric value of the physical order of the attribute in the key
        //3) user supplied PK
        // [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]  

        private string _QuantityPerUnit;

        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }
        public string QuantityPerUnit
        {
            get
            {
                return _QuantityPerUnit;
            }
            set
            {
                _QuantityPerUnit = string.IsNullOrEmpty(value.Trim()) ? null : value;
            }
        }
        public decimal? UnitPrice { get; set; }
        public Int16? UnitsInStock { get; set; }
        public Int16? UnitsOnOrder { get; set; }
        public Int16? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }


        

        //sample of a computed field on your sql field
        // to annotate this property to be taken as a sql computed field use 
        // [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        // public decimal someComputedSqlField {get; set;}

        // creating a read only property that is NOT an acual field on your sql table means that
        // NO data is accually transfered
        // example FirstName and LastName are often combined into a single field for display
        // such as FullName
        //use the NotMapped Annotation to handle this

        //[NotMapped]
        //public string FullName
        //{
        //    get
        //    {
        //        return FirstName + " " + LastName;
        //    }
        //}

    }
}
