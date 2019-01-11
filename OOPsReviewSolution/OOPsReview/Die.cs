using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Die
    {
        // this is the definition of a object
        // it is a conceptual view of the data
        // that will be held by a physical
        // Instance (object) of this class

        //Data Members
        // is an internal private storage item
        // private data members cannot be reached directly by the user
        // Public data members can be reached directly by the user

        private int _Size;
        private string _Color;
       

        //Properties
        // a property is an external interface between the user
        // and a single piece of data within the instance.

        // a property has two abilites
        // a) the ability to assign a value to the internal data member
        // b) return an internal data member value to the user

        // Fully Iplemented Property
        public int Size
        {
            get
            {
                //Takes internal values and returns to user
                return _Size;
            }
            set
            {
                //Takes the suplied user value and places it into the internal private data member

                //The incoming piece of data is place into a special variable that is called "value"

                //Optionally you may place validation on the incoming value

                if (value >= 6 && value <= 20)
                {
                    _Size = value;
                }
                else
                {
                    throw new Exception("Die cannot be " + value.ToString() + " sides. Die must have between 6 and 20 sides.");
                }

                

            }
        }
        
   
        // Auto implimented Property
        //Public
        // It has a datatype
        // it has a name
        //IT DOES NOT HAVE AN INTERNAL DATA MEMBER THAT YOU CAN DIRECTLY ACCESS.
        // the system will create, internally, a data storage area of the apropriate 
        //datatype and manage the area

        //the only way to access the data of an auto implimented property is via 
        //the property
        //Usually used when there is no need for any internal validation or other 
        // Property logic

        public int _FaceValue { get; set; }

        public string Color
        {
            get
            {
                return _Color;
            }
            set
            {
                // (value == null) this will fail for an empty string
                // (value == "") this will fail for a null value
                if(string.IsNullOrEmpty(value))
                {
                    throw new Exception("Color has no value");
                }
                else
                {
                    _Color = value;
                }
            }
        }

        //Constructor

        


        //Behaviours (Methods)


    }
}
