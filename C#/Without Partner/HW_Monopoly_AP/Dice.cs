using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Monopoly_AP
{
    class Dice
    {
        //Private fields
        private Random rng;

        //Constructor class
        public Dice()
        {
            this.rng = new Random();
        }

        //Roll a single die
        public int RollDie()
        {
            int roll = rng.Next(1, 7);
            return roll;
        }

        //Roll multiple dice
        public int RollDice(int amount)
        {
            int rolls = 0;
            Dice multiDie = new Dice();
            //Will keep looping to factor in the total amount of dice
            for(int i = 0; i < amount; i++)
            {
                rolls += multiDie.RollDie();
            }

            //Will return the total number made from the multiple dice
            return rolls;
        }
    }
}
