using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Die
    {
        //create a new instance of the math class Random
        //this instance(occourance, object) will be shared by each instance of the class die
        //this instance will be created when the first instance of die is created

        private static Random _rnd = new Random();

        // this is the definition of a object
        // it is a conceptual view of the data
        // that will be held by a physical
        // Instance (object) of this class

        //Data Members*

        // is an internal private storage item
        // private data members cannot be reached directly by the user
        // Public data members can be reached directly by the user

        private int _Sides;
        private string _Color;



        //Properties*

        // a property is an external interface between the user
        // and a single piece of data within the instance.

        // a property has two abilites
        // a) the ability to assign a value to the internal data member
        // b) return an internal data member value to the user

        // Fully Iplemented Property

        public int Sides
        {
            get
            {
                //Takes internal values and returns to user
                return _Sides;
            }
            set
            {
                //Takes the suplied user value and places it into the internal private data member

                //The incoming piece of data is place into a special variable that is called "value"

                //Optionally you may place validation on the incoming value

                if (value >= 6 && value <= 20)
                {
                    _Sides = value;
                    Roll();
                    //consider placing this method within the property if it is not private
                }
                else
                {
                    throw new Exception("Die cannot be " + value.ToString() + " sides. Die must have between 6 and 20 sides.");
                }

                

            }
        }

        //Another version of sides using a private set and auto implimented property

        //in this version you would need to code a method like SetSides()

        // public int Sides { get; private set; }
   
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

        public int FaceValue { get; private set;}

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

        //Constructor*

        //optional ; if not supplied the system default constructor
        // is used which will assign a system value to each data member /auto
        // implimented property according to it's data type

        //you can have any number of constructors within your class
        //as soon as you code a constructor your program is responsible 
        // for all constructors

        //syntax 
        // public *classname*([list of parameters]) {Code}

        //typical constructors

        //Default Construtor
        //this is similar to the system default constructor

        public Die()
        {
            // you could leave this constructor empty and the system would assign the normal default value
            // to your data members and auto implimented properties

            // you can directly access a private data member any place within your class
            _Sides = 6;

            // you can access any property any place within your class
            Color = "White";

            //you could use a class method to generate a value for a data member/auto property

            Roll();
        }

        //Greedy Constructor
        //typicaly has a paremeter for each data member and each auto implimented property within your class
        //parameter order is not important
        //this constructor allows the outside user to create and assign their own values 
        // to the data members / auto properties at the time of instance creation

        public Die(int sides, string color)
        {
            //Since this data is coming from an outside scource it is best to use
            // your property to save the values especially if the property has validation

            Sides = sides;
            Color = color;
            Roll();
        }


        //Behaviours (Methods)*

        //these are actions that the class can perform
        //the actions may or may not alter data members/auto property values
        // the actions could simply take a value(s) from the user
        // and perform some logic operations against the values

        // can be public or private
        //create a method that allows to user to change the number of sides on a die

        public void SetSides(int sides)
        {
            if(sides >= 6 && sides <=20)
            {
                Sides = sides;
                
            }
            else
            {
                // Optionally
                //A) throw new exeption

                throw new Exception("Invalid value for number of sides");

                //B) set _sides to a default value

                //Sides = 6;

            }
            Roll();
        }

        public void Roll()
        {
            // no paremeters are required for this method since it will be using the internal data values to complete its funtionality

            //Randomly generate a value for the Die depending on the maximum sides


            FaceValue = _rnd.Next(1, Sides+1);
        }
    }
}
