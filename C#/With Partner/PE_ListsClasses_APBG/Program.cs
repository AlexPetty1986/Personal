using System;
using System.Collections.Generic;
using System.IO;

namespace PE_ListsClasses_APBG
{
    class Program
    {
        static void Main(string[] args)
        {
            //variables
            Roster allStudents = new Roster("All Students");
            Roster freshmanStudents = new Roster("Freshman");
            int userInput = 0;
            string stringInput;
            string fileName = "..\\..\\..\\allStudents.txt";

            //create the streamreader
            StreamReader input = null;

            //try to open text file
            try
            {
                input = new StreamReader(fileName);

                String line = null;
                String[] data = null;

                while((line = input.ReadLine()) != null)
                {
                    data = line.Split(',');
                    Student studData = new Student (data[0], data[1], int.Parse(data[2]));
                    allStudents.AddStudent(studData);

                    //If student is in year 1
                    if (studData.Year == 1)
                    {
                        freshmanStudents.AddStudent(studData);
                    }
                }

                Console.WriteLine("\nFile opened successfully!!\n");
            }

            //Can't open file
            catch(Exception e)
            {
                Console.WriteLine("Error!! " + e.Message);
            }

            //close text file
            if(input != null)
            {
                input.Close();
            }

            //keep asking user for input until they quit
            while (userInput != 5)
            {
                //give the user choices
                Console.WriteLine("Choose one of the following options:");
                Console.WriteLine("1 - Add a student");
                Console.WriteLine("2 - Change major for a student");
                Console.WriteLine("3 - Print the rosters");
                Console.WriteLine("4 - Save AllStudent roster");
                Console.WriteLine("5 - Quit");

                //get input
                Console.Write("> ");
                userInput = int.Parse(Console.ReadLine());

                //different things occur depending on user choice
                switch (userInput)
                {
                    //add new student to All Students, and if the student is in year 1, add them to Freshman as well
                    case 1:
                        //save info into student object
                        Student student = allStudents.AddStudent();

                        //If student is in year 1
                        if (student.Year == 1)
                        {
                            freshmanStudents.AddStudent(student);
                            Console.WriteLine();
                        }
                        break;

                    //change the students major if they exist, otherwise state that they do not
                    case 2:
                        //prompt user for name of student
                        Console.Write("\nWhose major would you like to change?: ");
                        stringInput = Console.ReadLine();

                        //save info into student object
                        Student search = allStudents.SearchByName(stringInput);

                        //if student is in the roster
                        if (search != null)
                        {
                            Console.Write("\nWhat would you like to change their major to?: ");
                            search.Major = Console.ReadLine();
                        }
                        //student doesn't exist
                        else
                        {
                            Console.WriteLine("\n{0} not Found:\n", stringInput);
                        }
                        break;

                    //display all students in both rosters
                    case 3:
                        Console.WriteLine();
                        allStudents.DisplayRoster();
                        Console.WriteLine();
                        freshmanStudents.DisplayRoster();
                        Console.WriteLine();
                        break;

                    //saves the allStudents roster to the text file
                    case 4:
                        allStudents.Save(fileName);
                        break;

                    //quit
                    case 5:
                        Console.WriteLine("Goodbye!");
                        break;

                    //choice outside of what is provided
                    default:
                        Console.WriteLine("That wasn't an option.");
                        break;
                }
            }
        }
    }
}
