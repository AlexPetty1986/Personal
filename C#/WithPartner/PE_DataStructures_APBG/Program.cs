using System;
using System.Collections.Generic;

namespace PE_DataStructures_APBG
{
    class Program
    {
        static void Main(string[] args)
        {
            //example
            string[] ex1 = new string[5];
            ex1[2] = "Shiro";

            //part 1
            List<string> pets1 = new List<string>();
            pets1.Add("Pax");
            pets1.Add("Aiden");

            //part 2
            Pet[] pets2 = new Pet[5];
            pets2[0] = new Pet();
            pets2[1] = new Pet("Lacy", 7.5);

            //part 3
            List<Pet> pets3 = new List<Pet>();
            pets3.Add(new Pet("Pax", 80));
            pets3.Add(new Pet());

            //part 4
            bool[,] board = new bool[4,4];
            for(int i = 0; i < board.GetLength(0); i++)
            {
                for(int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = false;

                    if ((i+j) % 2 == 0)
                    {
                        board[i, j] = true;
                    }
                }
            }

            //part 5
            List<int[]> grades = new List<int[]>();
            grades.Add(new[] { 89, 87, 85 });
            grades.Add(new[] { 73, 75 });
            grades.Add(new[] { 88, 90, 92, 94, 99 });

            //part 6
            List<Pet>[] familyPets = new List<Pet>[4];
            familyPets[2] = new List<Pet>();
            familyPets[2].Add(new Pet("Samson", 11.5));
            familyPets[3] = new List<Pet>();
            familyPets[3].Add(new Pet("Indy", 75));
            familyPets[3].Add(new Pet("Odin", 93));

            //part 7
            string[,] seats = new string[3, 5];
            seats[0, 0] = "Pax";
            seats[1, 1] = "Lacy";
            seats[1, 3] = "Shiro";
            seats[2, 4] = "Pidge";

            //seats[1, 9] = "Uh oh"; out of range
            //seats[0] = new string[5]; 1d array
        }
    }
}
