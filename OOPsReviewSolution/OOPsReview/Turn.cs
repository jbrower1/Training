using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Turn
    {
        // record one instance of each player rolling the die

        // two ints
        // player 1 player 2

        // two int arrays

        private string[] _Turns;
        private int _TurnCount = 1;

        public string[] Turns
        {
            get
            {
                return _Turns;
            }
        }
       
        public void AddTurn(int Player1Turn, int Player2Turn)
        {
            _Turns[_TurnCount] =(Player1Turn + " " + Player2Turn + " ");
            _TurnCount ++;
        }
    }
}
