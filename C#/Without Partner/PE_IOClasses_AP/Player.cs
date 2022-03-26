using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_IOClasses_AP
{
    class Player
    {
        //private fields
        private int health;
        private string name;
        private int strength;

        //constructor
        public Player(int health, string name, int strength)
        {
            this.health = health;
            this.name = name;
            this.strength = strength;
        }

        //getters
        public int Health
        {
            get { return health ; }
        }

        public string Name
        {
            get { return name; }
        }

        public int Strength
        {
            get { return strength; }
        }

        public override string ToString()
        {
            return String.Format("Player: {0}. Strength {1}, Health {2}", name, strength, health);
        }
    }
}
