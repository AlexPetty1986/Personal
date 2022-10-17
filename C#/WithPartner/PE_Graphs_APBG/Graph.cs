using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Graphs_APBG
{
    class Graph
    {
        //fields
        private Dictionary<string, List<string>> adjacency;

        //constructor
        public Graph(Dictionary<string, List<string>> adjacency)
        {
            this.adjacency = adjacency;

            //dawing room adjacents
            adjacency.Add("drawing room", new List<string>());
            adjacency["drawing room"].Add("billiards room");
            adjacency["drawing room"].Add("game room");
            adjacency["drawing room"].Add("library");

            //liberry adjacents
            adjacency.Add("library", new List<string>());
            adjacency["library"].Add("drawing room");
            adjacency["library"].Add("game room");
            adjacency["library"].Add("exit");

            //billards room adjacents
            adjacency.Add("billiards room", new List<string>());
            adjacency["billiards room"].Add("drawing room");

            //gam room adjacents
            adjacency.Add("game room", new List<string>());
            adjacency["game room"].Add("drawing room");
            adjacency["game room"].Add("library");
        }

        //returns list of adjacent rooms
        public List<string> GetAdjacentList(string room)
        {
            //variables
            List<string> result = new List<string>();

            //if room is not real
            if (!adjacency.ContainsKey(room))
            {
                return null;
            }

            //for each adjacent room
            foreach(string adjRoom in adjacency[room])
            {
                result.Add(adjRoom);
            }

            return result;
        }

        //determines if room2 is directly connected to room 1
        public bool IsConnected(string room1, string room2)
        {
            //if list contains room 2 return true
            if (adjacency[room1].Contains(room2))
            {
                return true;
            }

            return false;
        }
    }
}
