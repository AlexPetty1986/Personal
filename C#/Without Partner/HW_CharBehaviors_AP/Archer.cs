using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_CharBehaviors_AP
{
    class Archer : CommonCharacter
    {
        //Private fields
        private double piercing;
        private double dodge;

        //Constructor
        public Archer(double dodge, int health, int strength, int dexterity, double piercing, string name) 
            : base(strength, health, dexterity, name, "archer")
        {
            this.dodge = dodge;
            this.piercing = piercing;
        }

        //Getters
        public double Piercing
        {
            get { return piercing; }
        }

        public double Dodge
        {
            get { return dodge; }
        }

        //Prints out the info of the character
        public override string ToString()
        {
            return base.ToString() + "They have a small chance of dodging incoming attacks, as well as have a small chance of " +
                "\npiercing through armor, doing double damage.";
        }

        //Calculates the damage of the character
        public override int Attack()
        {
            int damage = rng.Next(strength) + dexterity;

            //If piercing activates
            if (piercing + rng.NextDouble() >= 1)
            {
                damage = rng.Next(strength) * dexterity * 2;
            }

            return damage;
        }

        //Calculates how many damage the character will take
        public override int TakeDamage(int damage)
        {

            if (dodge + rng.NextDouble() >= 1)
            {
                Console.WriteLine("But the {0} was able to dodge!", name);
                health = health - 0;
            }
            else
            {
                health = health - damage;
            }

            return health;
        }

    }
}
