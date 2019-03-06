using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class DDLClass
    {
        public int ValueField { get; set; }
        public string DisplayField { get; set; }

        public DDLClass()
        {
            //Default
        }

        public DDLClass(int valueField , string displayField)
        {
            ValueField = valueField;
            DisplayField = displayField;
        }
    }
}