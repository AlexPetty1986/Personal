using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_IOClasses_AP
{
    class PlayerManager
    {
        //private fields
        private string filename;
        private List<Player> players;

        //Constructor
        public PlayerManager()
        {
            this.filename = "..\\..\\..\\players.txt";
            this.players = new List<Player>();
        }

        //Creates player data
        public void CreatePlayer(string name, int strength, int health)
        {
            Player person = new Player(health, name, strength);
            players.Add(person);
            Console.WriteLine("Added {0} to the list.", name);
        }

        //Prints player data from list
        public void Print()
        {
            //If there are no players in the list
            if (!players.Any())
            {
                Console.WriteLine("ERROR!! NO PLAYERS PRESENT IN LIST!!");
            }

            //If there are players in list
            else
            {
                foreach (Player p in players)
                {
                    Console.WriteLine(p);
                }
            }

        }

        //Loads player data from text file to list
        public void Load()
        {
            StreamReader input = null;

            try
            {

                input = new StreamReader(filename);

                //If there are any players already in the list
                if (players.Any())
                {
                    players.Clear();
                }

                String line = null;
                String[] data = null;

                while ((line = input.ReadLine()) != null)
                {
                    data = line.Split(',');
                    CreatePlayer(data[0], int.Parse(data[1]), int.Parse(data[2]));
                }

                //Print out how many characters transferred
                Console.WriteLine("Objects successfully created.\n{0} players created.", players.Count);
            }

            catch(Exception e)
            {
                Console.WriteLine("ERROR!! " + e.Message);
            }

            if(input != null)
            {
                input.Close();
            }

        }

        //Save player data to text file
        public void Save()
        {
            StreamWriter output = null;

            //If there are no players in the list
            if (!players.Any())
            {
                Console.WriteLine("ERROR!! NO PLAYERS PRESENT IN LIST!!");
                return;
            }

            try
            {
                output = new StreamWriter(filename);

                //Save stuff in list to text file
                for(int i = 0; i < players.Count; i++)
                {
                    output.WriteLine(players[i].Name + "," + players[i].Strength + "," + players[i].Health);
                }

                //Print out total characters transferred
                Console.WriteLine("Saved {0} players to file players.txt",players.Count);
            }

            catch(Exception e)
            {
                Console.WriteLine("ERROR!! " + e.Message);
            }

            if(output != null)
            {
                output.Close();
            }
        }

    }

}
