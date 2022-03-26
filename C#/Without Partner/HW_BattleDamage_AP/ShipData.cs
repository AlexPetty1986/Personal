using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace HW8_BattleDamage_AP
{
    class ShipData
    {
        //Private field
        private String[,] data;
        protected string fileName;

        //Constructor
        public ShipData(string fileName)
        {
            this.fileName = fileName;
        }

        //Loads the data from the provided text document
        public void LoadData()
        {
            //Constants
            const int MAX_ROWS = 6;

            StreamReader input = null;

            //Attempt to open the file
            try
            {
                //Variables
                string filename = fileName;
                input = new StreamReader(filename);

                String line = null;
                line = input.ReadLine();

                //Find total number of ships in the list
                int maxShips = int.Parse(line);
                data = new String[maxShips, MAX_ROWS];
                String[] info = null;

                line = input.ReadLine();
                info = line.Split(',');

                //For each ship in the text document
                for(int i = 0; i < data.GetLength(0); i++)
                {
                    line = input.ReadLine();

                    //For each piece of information on thh ship
                    for (int j = 0; j < MAX_ROWS; j++)
                    {
                        info = line.Split(",");
                        data[i, j] = info[j];
                    }
                }

                //Print out how many ships were recorde
                Console.WriteLine("{0} total ships successfully recorded.", data.GetLength(0));

            }

            //Can't find the file
            catch (FileNotFoundException e)
            {
                Console.WriteLine("ERROR!!! FILE CAN NOT BE FOUND!!!\n" + e.Message);
                Environment.Exit(0);
            }

            //If they reach the end of the list
            if (input != null)
            {
                input.Close();
            }
        }

        //Gets the data of the ships from the 2d array
        public string[] GetShipData(int row)
        {
            //Constants
            const int MAX_ROWS = 6;

            //Tries to pull info from specific row in the array
            try
            {
                string[] ship = new string[MAX_ROWS];

                //For each piece of data in the row
                for (int i = 0; i < MAX_ROWS; i++)
                {
                    ship[i] = data[row, i];
                }
                
                return ship;
            }

            //Row does not exist in the array
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine("ERROR!!! ROW VALUE NOT IN RANGE!!!\n" + e.Message);
                Environment.Exit(0);
            }

            return null;
        }

        //Stores the amount of rows of the 2d array
        public int Count
        {
            get 
            { 
                //If there is nothing in the array
                if(data.GetLength(0) == 0)
                {
                    return 0;
                }

                return data.GetLength(0); 
            }
        }

        //ToString method
        public override string ToString()
        {
            StreamReader input = null;
            string[] ship = new string[data.GetLength(0)];
            string filename = "..\\..\\..\\shipstats.csv";
            input = new StreamReader(filename);
            String line = null;
            String[] info = null;
            line = input.ReadLine();
            line = input.ReadLine();
            info = line.Split(',');

            //Prints out the title of each piece of the key pieces of information
            Console.WriteLine(info[0] + "\t        " + info[1] + "\t        "
                + info[2] + "\t" + info[3] + "\t" + info[4] + "\t" + info[5]);
            input.Close();

            //Prints out the information of each ship in the array
            for (int i = 0; i < data.GetLength(0); i++)
            {
                ship = GetShipData(i);
                Console.WriteLine(ship[0] + "\t" + ship[1] + "\t" + ship[2] + "\t        " + ship[3]
                    + "\t" + ship[ 4] + "\t" + ship[5]);
            }

            Console.WriteLine("");

            return null;
        }
    }
}
