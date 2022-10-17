using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_StackQueues_APBG
{
    class MyStack<T>:IStack<T>
    {
        //private fields
        private List<T> items;

        //constructor
        public MyStack()
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

        //Look at and return the top of the stack.
        public T Peek()
        {
            //if stack is empty
            if(IsEmpty)
            {
                return default(T);
            }

            return items.Last();
        }

        //Adds new data to the top of the stack.
        public void Push(T item)
        {
            items.Add(item);
        }

        //Removes and returns the data on top
        public T Pop()
        {
            T thing = Peek();

            //if stack is empty
            if (IsEmpty)
            {
                return default(T);
            }

            items.RemoveAt(items.Count-1);

            return thing;
        }
    }
}
