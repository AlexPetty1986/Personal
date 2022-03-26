using System;
using System.Collections.Generic;

namespace HW_CharBehaviors_AP
{
    class Program
    {
        //Main program
        //This is now being used for Homework 7 - Character Battles
        static void Main(string[] args)
        {

            //variables
            int round = 1;
            int dmg;
            Random rng = new Random();
            List<CommonCharacter> cast = new List<CommonCharacter>();

            //Create objects
            CommonCharacter sword = new Swordsman(3, 80, 6, 1, false, "Gary");
            CommonCharacter arrow = new Archer(0.3, 3, 60, 4, 0.5, "Jane");
            CommonCharacter sword2 = new Swordsman(4, 75, 7, 2, false, "Megan");
            CommonCharacter arrow2 = new Archer(0.5, 4, 65, 4, .25, "Roger");
            Swordsman s = (Swordsman)sword;
            Swordsman s2 = (Swordsman)sword2;

            //Add fighter to list
            cast.Add(sword);
            cast.Add(arrow);
            cast.Add(sword2);
            cast.Add(arrow2);

            //Create variable for swordsman health (related to berserker ability)
            int maxSword = sword.Health;
            int maxSword2 = sword2.Health;

            //Start program
            //Print out title as well as fighter information
            Console.WriteLine("Welcome to today's Arena Fight!\n", sword.Name, arrow.Name);
            Console.WriteLine(cast[0].ToString());
            Console.WriteLine("");
            Console.WriteLine(cast[1].ToString());
            Console.WriteLine(""); 
            Console.WriteLine(cast[2].ToString());
            Console.WriteLine("");
            Console.WriteLine(cast[3].ToString());
            Console.WriteLine("");

            //While the swordsman lives and the archer still wishes to fight
            while (cast.Count > 1)
            {
                //Damage that fighters do

                //Print out each round with how much damage each fighter does to each other
                Console.WriteLine("\nRound {0} -----------------------------", round);
                for(int i = 0; i < cast.Count; i++)
                {
                    dmg = cast[i].Attack();

                    //Find out who gets hit
                    int fight = rng.Next(0, cast.Count);

                    //While the variable equals the one who is attacking
                    while (fight == i)
                    {
                        fight = rng.Next(0, cast.Count);
                    }

                    //Print out who hit who
                    Console.WriteLine("{0} does {1} damage to the {2}.", cast[i].Name, dmg, cast[fight].Name);
                    cast[fight].TakeDamage(dmg);
                }

                Console.WriteLine();

                //Prints out the new health parameter each fighter
                for (int i = 0; i < cast.Count; i++)
                {
                    Console.WriteLine("The {0} has {1} health left.", cast[i].Name, cast[i].Health);
                }

                //If the swordsmen is at half health
                if (sword.Health < maxSword / 2 && s.Berserker == false)
                {
                    Console.WriteLine("Swordsman has gone BERSERK!!");

                    s.Berserker = true;
                    s.Defense = 0;
                }
                else if(sword2.Health < maxSword2 / 2 && s2.Berserker == false)
                {
                    Console.WriteLine("Swordsman has gone BERSERK!!");

                    s2.Berserker = true;
                    s2.Defense = 0;
                }

                System.Threading.Thread.Sleep(500); // 500 milliseconds is half a second
                round++;

                //Checks to see if any of the characters were killed
                for(int i = 0; i < cast.Count; i++)
                {
                    if(cast[i].IsDead() == true)
                    {
                        cast.RemoveAt(i);
                    }

                    else if(cast[i].HasFled() == true)
                    {
                        cast.RemoveAt(i);
                    }
                }
            }

            //If no one survives
            if(cast.Count == 0)
            {
                Console.WriteLine("\n** Battle Over **\nNo one remains!!");
            }

            //If only one remains
            else
            {
                Console.WriteLine("\n** Battle Over **\n{0} is the winner!!", cast[0].Name);
            }


        }
    }
}
