using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_SortedList_APBG
{
    class SortedList : ISortedCollection
    {
        //private fields
        private List<int> sorted;

        //constructor
        public SortedList()
        {
            this.sorted = new List<int>();
        }

        //getters
        public int Count
        {
            get { return sorted.Count; }
        }

        public bool IsEmpty
        {
            get { return !sorted.Any(); }
        }

        /*Create a local variable to track if the data has been added yet
        Initialize this “added” flag to false
        For every index, i, in the underlying List:
            If the newData to add is < the data at index i
                    Insert the data at index i
                    Set the added flag to true
                    Break out of the loop
        When the loop ends, if the data has not been added, add it to the end of the list*/
        public void Add(int newData)
        {
            bool flag = false;

            for(int i = 0; i < sorted.Count; i++)
            {
                if(newData < sorted[i])
                {
                    sorted.Insert(i, newData);
                    flag = true;
                    break;
                }
            }

            if(flag == false)
            {
                sorted.Add(newData);
            }
        }

        //Locates specific variable in list
        public bool Contains(int data)
        {
            for(int i = 0; i < sorted.Count; i++)
            {
                if(data == sorted[i])
                {
                    return true;
                }
            }

            return false;
        }

        //clears list
        public void Clear()
        {
            sorted.Clear();
        }

        //prints out list
        public void Print()
        {
            for(int i = 0; i < sorted.Count; i++)
            {
                Console.WriteLine(sorted[i]);
            }
        }

        //locates smallest number in list
        public int Min()
        {
            if(IsEmpty)
            {
                return int.MinValue;
            }

            return sorted.First();
        }

        //locates largest number in list
        public int Max()
        {
            if(IsEmpty)
            {
                return int.MaxValue;
            }

            return sorted.Last();
        }

    }
}
