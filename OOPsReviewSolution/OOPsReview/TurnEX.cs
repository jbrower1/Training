using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    class TurnEX
    {
        private int _Player1Roll;

        public int Player1Roll
        {
            get
            {
                return _Player1Roll;
            }
            set
            {
                _Player1Roll = value;
            }
        }

        public int Player2Roll { get; set; }

        public TurnEX()
        {

        }
        public TurnEX(int Player1,int Player2)
        {
            Player1Roll = Player1;
            Player2Roll = Player2;
        }

        //methods 
        //public String findRollResults()
        //{
        //  return null;
        //}
    }
}
