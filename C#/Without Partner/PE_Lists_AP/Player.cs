using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Lists_AP
{
    class Player
    {
        //Private fields
        private string name;
        private List<String> inventory;

        //Constructor
        public Player(string name)
        {
            this.inventory = new List<String>();
            this.name = name;
        }

        //Getter
        public string Name
        {
            get { return name; }
        }

        //Adds an item to the list
        public void AddToInventory(String item)
        {
            //If the item is not null
            if(item != null)
            {
                //If the item is not in the list of stolen items
                if(name != "stolen")
                {
                    Console.WriteLine("Item '{0}' added to {1}'s inventory.", item, name);
                }
                inventory.Add(item);
            }
            
        }

        //Determines if an item is in the list and returns it, it then deletes the item form the list they found it in
        public String GetItemInSlot(int index)
        {
            //variables
            string item;

            //If the index is in range
            if(index > 0 && index <= inventory.Count)
            {
                item = inventory[index - 1];
                Console.WriteLine("{0} stolen from slot {1} of {2}'s list.", inventory[index - 1], index, name);
                inventory.RemoveAt(index - 1);
                return item;
            }
           
            //If the index is invalid
            else
            {
                Console.WriteLine("{0} is not a valid number!", index);
                return null;
            }
        }

        //Prints out each item in the list
        public void PrintInventory()
        {
            //If the item is not in the list of stolen items
            if (name != "stolen")
            {
                Console.WriteLine("{0}'s Inventory:", name);
            }

            //For each item in the list
            foreach(String n in inventory)
            {
                Console.WriteLine("\t- " + n);
            }
        }

    }
}
