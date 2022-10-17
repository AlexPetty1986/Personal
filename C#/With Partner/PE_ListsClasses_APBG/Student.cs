using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_ListsClasses_APBG
{
    /// <summary>
    /// Provides data for student
    /// </summary>
    class Student
    {
        //private fields
        private string name;
        private string major;
        private int year;

        //getters and setters
        public string Name
        {
            get { return name; }
        }

        public string Major
        {
            get { return major; }
            set { major = value; }
        }

        public int Year
        {
            get { return year; }
        }

        //constructor
        public Student(string name, string major, int year)
        {
            this.name = name;
            this.major = major;
            this.year = year;
        }

        //toString method
        public override string ToString()
        {
            return "\t" + name + " – " + year + " - " + major;
        }
    }
}
