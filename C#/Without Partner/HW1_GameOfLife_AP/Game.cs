using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HW1_GameOfLife_AP
{
    //Game of Life code
    class Game
    {
        //private fields
        private Cell[,] life;
        private Cell[,] future;
        private Random rand;
        private int rows;
        private int cols;
        private string dead;
        private string alive;

        //Constructor
        public Game()
        {
            this.rand = new Random();
        }

        //Generates the board for the game
        public void GenerateBoard()
        {
            //variables
            rows = rand.Next(5, 20);
            cols = rand.Next(5, 20);
            life = new Cell[cols,rows];
            future = new Cell[cols,rows];
            string alive = "O";
            string dead = "X";

            //for each column
            for (int i = 0; i < cols; i++)
            {
                //for each row
                for(int j = 0; j < rows; j++)
                {

                    life[i, j] = new Cell(rand.NextDouble() < .3, alive, dead);
                }
            }

            //let user know the board was generated
            Console.WriteLine("A {0} x {1} board was generated."
                ,rows, cols);
        }

        //Loads the board from a text file
        public void loadFile(StreamReader input)
        {
            //variables

            String line = null;
            String[] data = null;

            //Size of the array
            line = input.ReadLine();
            data = line.Split(',');
            rows = int.Parse(data[0]);
            cols = int.Parse(data[1]);
            life = new Cell[rows, cols];
            future = new Cell[rows, cols];

            //Dead and Alive cells
            line = input.ReadLine();
            data = line.Split(',');
            alive = data[0];
            dead = data[1];

            //Cell Map
            //for each column
            for (int i = 0; i < cols; i++)
            {
                line = input.ReadLine();

                //for each row
                for (int j = 0; j < rows; j++)
                {
                    //if cell is alive
                    if (line[j].Equals('o'))
                    {
                        life[i, j] = new Cell(true, alive, dead);
                    }

                    //if cell is dead
                    else
                    {
                        life[i, j] = new Cell(false, alive, dead);
                    }
                }

            }

            //Display board from file
            DisplayBoard();
        }

        public void saveFile(StreamWriter output)
        {
            output.WriteLine(rows + "," + cols);
            output.WriteLine(alive + "," + dead);
            string item;

            //for each column
            for (int i = 0; i < cols; i++)
            {
                if(i != 0)
                {
                    output.WriteLine();
                }
                //for each row
                for (int j = 0; j < rows; j++)
                {
                    item = life[i, j].ToString();

                    //if cell is alive
                    if (item == alive)
                    {
                        output.Write(new Cell(true, "o", "x"));
                    }

                    //if cell is dead
                    else if (item == dead)
                    {
                        output.Write(new Cell(false, "o", "x"));
                    }
                }
            }

        }

        //displays the generated board
        public void DisplayBoard()
        {
            //for each column
            for (int i = 0; i < cols; i++)
            {
                //for each row
                for (int j = 0; j < rows; j++)
                {
                    Console.Write(life[i, j]);
                }
                Console.WriteLine();
            }
        }

        //Advances the board
        public void Advance()
        {
            future = life;

            //for each cols
            for (int x = 0; x < cols; x++)
            {
                //for each row
                for(int y = 0; y < rows; y++)
                {
                    //get the total living neighbors for each cell
                    future[x,y].Neighbors = Neighbor(future, x, y);
                }

            }

            //for each cols
            for (int w = 0; w < cols; w++)
            {
                //for each row
                for (int v = 0; v < cols; v++)
                {
                    //if a living cell has less than two neighbors or more than three neighbors
                    if((future[w,v].Neighbors < 2 || future[w, v].Neighbors > 3) && future[w,v].Alive)
                    {
                        future[w, v].Alive = false;

                    }

                    //if a dead cell has more than 3 neighbors
                    if(future[w,v].Neighbors == 3 && !future[w, v].Alive)
                    {
                        future[w, v].Alive = true;
                    }

                    //save second baord to first board
                    life[w, v] = future[w, v];
                }
            }

        }

        //checks how many neighbors a cell has around it
        public int Neighbor(Cell[,] future, int x, int y)
        {
            int neighbors = 0;

            //for each column
            for(int colLoc = x - 1; colLoc <= x + 1; colLoc++)
            {
                //for each row
                for(int rowLoc = y - 1; rowLoc <= y + 1; rowLoc++)
                {
                    //if it is the cell that is looking for it's neighbors
                    if(!((colLoc == x) && (rowLoc == x)))
                    {
                        //if cell is in range
                        if(inRange(colLoc, rowLoc))
                        {
                            //if nearby cell is alive
                            if(future[colLoc,rowLoc].Alive == true)
                            {
                                neighbors++;
                            }
                        }
                    }
                }
            }

            //return total number of living neighbors
            return neighbors;
        }

        //checks to see if the cell is actually in the array
        public bool inRange(int colLoc, int rowLoc)
        {
            //if out of range
            if(colLoc < 0 || rowLoc < 0)
            {
                return false;
            }

            //if out of range
            if (colLoc >= cols || rowLoc >= rows)
            {
                return false;
            }

            return true;
        }
    }
}
