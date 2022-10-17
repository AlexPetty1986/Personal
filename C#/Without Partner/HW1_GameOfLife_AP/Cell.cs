using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HW1_GameOfLife_AP
{
    //Determines if the cell is dead or alive
    class Cell
    {
        //private fields
        private bool isAlive;
        private string live;
        private string dead;
        private int neighbors;

        //constructor
        public Cell(bool isAlive, string live, string dead)
        {
            this.isAlive = isAlive;
            this.live = live;
            this.dead = dead;
            this.neighbors = 0;
        }

        //getters
        public bool Alive
        {
            get { return isAlive; }

            set { isAlive = value; }
        }

        public int Neighbors
        {
            get { return neighbors; }

            set { neighbors = value; } 
        }

        //toString
        public override string ToString()
        {
            //if cell is alive
            if(isAlive)
            {
                return live;
            }

            //if cell is dead
            return dead;
        }
    }
}
