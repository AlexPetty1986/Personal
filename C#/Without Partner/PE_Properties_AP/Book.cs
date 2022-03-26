using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Properties_AP
{
    class Book
    {
        //private fields
        private string title;
        private string author;
        private int pages;
        private string owner;
        private int timesRead;

        //Constructor method
        public Book(string title, string author, int pages, string owner)
        {
            this.title = title;
            this.author = author;
            this.pages = pages;
            this.owner = owner;
            timesRead = 0;
        }

        //Getters & Setters
        public string Title
        {
            get { return title; }
        }

        public string Author
        {
            get { return author; }
        }

        public int Pages
        {
            get { return pages; }
        }

        public string Owner
        {
            get { return owner; }
            set 
            {
                if (value != null && value.Trim().Length > 0)
                {
                    owner = value;
                }
            }
        }

        public int TotalTimesRead
        {
            get { return timesRead; }
            set
            {
                if (value > timesRead)
                {
                    timesRead = value;
                }
            }
        }

        //prints out the info on the book
        public void Print()
        {
            Console.WriteLine("{0} by {1} has {2} pages. It is owned by {3} and has been read {4} " +
                "\ntimes.", title, author, pages, owner, timesRead);
        }
    }
}
