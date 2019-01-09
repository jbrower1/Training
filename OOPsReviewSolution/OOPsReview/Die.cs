﻿using System;
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
        private int _Face;

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
                _Size = value;
            }
        }
        
        public string Color
        {
            get
            {
                return _Color;
            }
            set
            {
                _Color = value;
            }
        }

        public int Face
        {
            get
            {
                return _Face;
            }
        }

        //Constructor


        //Behaviours (Methods)

    }
}
