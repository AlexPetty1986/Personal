using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_CharBehaviors_AP
{
    abstract class CommonCharacter
    {
        //private fields
        protected int health;
        protected int strength;
        protected int dexterity;
        private string type;
        protected string name;
        protected Random rng;

        //Constructor
        public CommonCharacter(int health, int strength, int dexterity, string name, string type)
        {
            this.health = health;
            this.strength = strength;
            this.dexterity = dexterity;
            this.name = name;
            this.type = type;
            this.rng = new Random();
        }

        //Getters and setters

        public int Health
        {
            get { return health; }

            set
            {
                if (value > health)
                {
                    health = value;
                }
            }
        }

        public int Strength
        {
            get { return strength; }
        }

        public int Dexterity
        {
            get { return dexterity; }
        }

        public string Name
        {
            get { return name; }
        }

        public bool IsDead()
        {
            //If the swordsman has died
            if (health < 0)
            {
                Console.WriteLine("{0} has perished!", name);
                return true;
            }

            //If they still live
            else
            {
                return false;
            }
        }

        //Determines if the archer has fled or not
        public bool HasFled()
        {
            //If the archer has fled
            if (health < 5)
            {
                Console.WriteLine("{0} has fled!", name);
                return true;
            }

            //If they still live
            else
            {
                return false;
            }
        }

        //Abstract methods
        public abstract int TakeDamage(int damage);

        public abstract int Attack();

        //ToString methos
        public override string ToString()
        {
            return name + " the " + type + " has a dexterity of " + dexterity + ", a strength of " + strength + ", and is currently at " + health + " health.\n";
        }

    }
}
