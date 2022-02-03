using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Nasdaq_Alpha_v0._01
{
    class Dice
    {
        public int dice1;
        public int dice2;

        public Dice()
        {
            dice1 = 0;
            dice2 = 0;
        }

        public int throwDice()
        {
            Random dicenumber = new Random();
            dice1 = dicenumber.Next(1, 7);
            dice2 = dicenumber.Next(1, 7);
            return dice1 + dice2;
        }

        public bool isDouble()
        {
            bool dub = false;
            if (dice1 == dice2)
            {
                dub = true;
            }
            return dub;
        }

        public int getDice1()
        {
            return dice1;
        }
        public int getDice2()
        {
            return dice2;
        }
        public int getDice3()
        {
            return dice1 + dice2;
        }

    }
}
