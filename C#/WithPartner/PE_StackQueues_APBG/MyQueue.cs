using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_StackQueues_APBG
{
    class MyQueue<T>:IQueue<T>
    {
        //private fields
        private List<T> items;

        //constructor
        public MyQueue()
        {
            this.items = new List<T>();
        }

        //getters
        public int Count
        {
            get { return items.Count; }
        }

        public bool IsEmpty
        {
            get { return !items.Any(); }
        }

        //Look at and return the front of the queue.
        public T Peek()
        {
            //if queue is empty
            if (IsEmpty)
            {
                return default(T);
            }

            return items.First();
        }

        //Adds new data to the end of the queue
        public void Enqueue(T item)
        {
            items.Add(item);
        }

        //Removes and returns the data in the front of the queue.
        public T Dequeue()
        {
            T thing = Peek();

            //if queue is empty
            if (IsEmpty)
            {
                return default(T);
            }

            items.RemoveAt(0);

            return thing;
        }
    }
}
