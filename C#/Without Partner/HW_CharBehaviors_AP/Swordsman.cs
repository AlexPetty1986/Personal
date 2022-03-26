using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_CharBehaviors_AP
{
    class Swordsman : CommonCharacter
    { 
        //Private fields
        private int defense;
        private bool berserker;

        //Constructor
        public Swordsman(int defense, int strength, int health, int dexterity, bool berserker, string name) 
            : base(strength, health, dexterity, name, "swordsman")
        {
            this.defense = defense;
            this.berserker = berserker;
        }

        //Getters and Setters
        public int Defense
        {
            get { return defense; }

            set { defense = value; }
        }

        public bool Berserker
        {
            get { return berserker; }

            set { berserker = value; }
        }

        //Prints out the info of the character
        public override string ToString()
        {
            return base.ToString() + "They take " + defense + " less damage thanks to their defense.  When they get to less than half of their health,\n" +
                "their attack doubles, but their defense drops to 0.";
        }

        //Calculates the damage of the character
        public override int Attack()
        {
            int damage = rng.Next(strength) + dexterity;
            
            //If berserker has activated
            if(berserker == true)
            {
                damage = ((rng.Next(strength)) + 2 * 2) + dexterity;
            }

            return damage;
        }

        //Calculates how many damage the character will take
        public override int TakeDamage(int damage)
        {
            damage = damage - defense;

            //If damage is less than or equal to 0
            if(damage <= 0)
            {

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
