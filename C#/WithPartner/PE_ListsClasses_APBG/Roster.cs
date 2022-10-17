using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PE_ListsClasses_APBG
{
    /// <summary>
    /// class to create a roster of student objects
    /// </summary>
    class Roster
    {
        //private fields
        private string name;
        private List<Student> students;

        //constructor
        public Roster(string name)
        {
            this.name = name;
            this.students = new List<Student>();
        }

        //locates student in list using name
        public Student SearchByName(string name)
        {
            //Looks throguh the list to find student
            for(int i = 0; i < students.Count; i++)
            {
                //If student is found
                if(students[i].Name == name)
                {
                    Console.WriteLine(students[i]);
                    return students[i];
                }
            }

            //Search unsuccessful
            return null;
        }

        //Adds a student to list
        public void AddStudent(Student s)
        {
            //add the student if they don't exist
            if(SearchByName(s.Name) == null)
            {
                students.Add(s);
                Console.WriteLine("\nAdded {0} to the {1} roster:", s.Name, name);
            }
            //if they are already in the roster
            else
            {
                Console.WriteLine("\n{0} is already in the {1} roster:", s.Name, name);
            }
        }

        //user creates a new student and adds said student to list
        public Student AddStudent()
        {
            //variables
            string studentName;
            string studentMajor;
            int studentYear;

            //prompt for name
            string prompt = "\nWhat is the student's full name?: ";
            studentName = SmartConsole.GetStringInput(prompt);

            //prompt for major
            prompt = "What is the student's major?: ";
            studentMajor = SmartConsole.GetStringInput(prompt);

            //prompt for year level
            prompt = "What year is the student in?: ";
            studentYear = SmartConsole.GetIntRangeInput(prompt, 1, 4);

            //creates new student based off of information provided
            Student stud = new Student(studentName, studentMajor, studentYear);
            AddStudent(stud);
            return stud;
        }

        //method to print out roster of students
        public void DisplayRoster()
        {
            //roster name and student count
            Console.WriteLine("{0} has {1} students.", name, students.Count);

            //displays information fo every student in roster
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(students[i]);
            }
        }

        //saves students to text file
        public void Save(string filename)
        {
            StreamWriter output = null;
            string choice;

            //if students exist
            if (students.Any())
            {
                Console.Write("Students present in list. Overwrite list?(Y/N)\n > ");
                choice = Console.ReadLine().ToUpper();

                //invalid input check
                while(choice != "Y" && choice != "N")
                {
                    Console.Write("Invalid Input.\nOverwrite list?(Y/N)\n >");
                    choice = Console.ReadLine().ToUpper();
                }

                //if they said yes
                if(choice == "Y")
                {
                    //Try to open text file
                    try
                    {
                        output = new StreamWriter(filename);

                        //for each student in list
                        for(int i = 0; i < students.Count; i++)
                        {
                            //save to text file
                            output.WriteLine(students[i].Name + "," + students[i].Major + "," + students[i].Year);
                        }

                        //confirmation
                        Console.WriteLine("Saved {0} students to file allStudents.txt", students.Count);
                    }

                    // if exception is thrown
                    catch(Exception e)
                    {
                        Console.WriteLine("ERROR!" + e.Message);
                    }

                    //close file
                    if(output != null)
                    {
                        output.Close();
                    }
                }

                //if not
                else if(choice == "N")
                {
                    Console.WriteLine("OK");
                }
            }
        }
    }
}
