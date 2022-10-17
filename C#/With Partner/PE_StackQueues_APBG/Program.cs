using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_StackQueues_APBG
{
    class Program
    {
        static void Main(string[] args)
        {
            //variables
            MyStack<double> stackInt = new MyStack<double>();
            MyStack<double> stackStr = new MyStack<double>();
            MyQueue<char> queueCh = new MyQueue<char>();
            MyQueue<double> queueDb = new MyQueue<double>();

            Console.WriteLine("Adding data: ");
            //int stack
            stackInt.Push(3.14);
            stackInt.Push(2.7);
            stackStr.Push(stackInt.Pop());
            stackInt.Push(1.65);
            stackStr.Push(8.8);
            stackInt.Push(4.9);
            stackInt.Pop();
            stackStr.Push(6.37);
            stackInt.Push(stackStr.Pop());

            //prints out string stack
            Console.WriteLine("\nThe string stack has {0} items in it.\n\tStarting at the top they are:", stackStr.Count);
            Console.WriteLine(stackStr.Peek());
            stackStr.Pop();
            Console.WriteLine(stackStr.Peek());
            stackStr.Pop();
            Console.WriteLine(stackStr.Peek());
            stackStr.Pop();
            Console.WriteLine(stackStr.Peek());
            stackStr.Pop();
            Console.WriteLine(stackStr.Peek());

            //prints out int stack
            Console.WriteLine("\nThe int stack has {0} items in it.\n\tStarting at the top they are:", stackInt.Count);
            Console.WriteLine(stackInt.Peek());
            stackInt.Pop();
            Console.WriteLine(stackInt.Peek());
            stackInt.Pop();
            Console.WriteLine(stackInt.Peek());
            stackInt.Pop();
            Console.WriteLine(stackInt.Peek());
            stackInt.Pop();
            Console.WriteLine(stackInt.Peek());

            Console.WriteLine("\nAdding data: ");
            //char queue
            queueCh.Enqueue('a');
            queueCh.Enqueue('b');
            queueCh.Enqueue('c');
            queueCh.Enqueue('d');
            queueCh.Enqueue('e');

            //double queue
            queueDb.Enqueue(1.5);
            queueDb.Enqueue(2.75);
            queueDb.Enqueue(3.25);
            queueDb.Enqueue(5.88);
            queueDb.Enqueue(10.99);

            //prints out char queue
            Console.WriteLine("\nThe char queue has {0} items in it.\n\tStarting at the top they are:", queueCh.Count);
            Console.WriteLine(queueCh.Peek());
            queueCh.Dequeue();
            Console.WriteLine(queueCh.Peek());
            queueCh.Dequeue();
            Console.WriteLine(queueCh.Peek());
            queueCh.Dequeue();
            Console.WriteLine(queueCh.Peek());
            queueCh.Dequeue();
            Console.WriteLine(queueCh.Peek());

            //prints out double queue
            Console.WriteLine("\nThe double queue has {0} items in it.\n\tStarting at the top they are:", queueDb.Count);
            Console.WriteLine(queueDb.Peek());
            queueDb.Dequeue();
            Console.WriteLine(queueDb.Peek());
            queueDb.Dequeue();
            Console.WriteLine(queueDb.Peek());
            queueDb.Dequeue();
            Console.WriteLine(queueDb.Peek());
            queueDb.Dequeue();
            Console.WriteLine(queueDb.Peek());
        }
    }
}
