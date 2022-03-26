using System;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// Empty starter project with the shipstats.csv data file for HW 8
/// As configured, the relative path for shipstats.csv in this project is
///         "../../../shipstats.csv"
/// https://docs.google.com/document/d/1PZlqdP3MJlPMuIFZiztK-_R0iUy654XPnbFu85Xcuvo/edit?usp=sharing
/// </summary>
namespace HW8_BattleDamage_AP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables
            ShipData ships = new ShipData("..\\..\\..\\shipstats.csv");
            Random rng = new Random();
            Ship ship1 = null;
            Ship ship2 = null;
            int rounds = 1;
            int damage;
            int defense;
            int totalDamage;

            /*//Part 1 Test
            ships.LoadData();
            ships.ToString();
            int count = ships.Count;

            //Part 2 Test
            List<Ship> oneOfEach = new List<Ship>();
            oneOfEach.Add(new Ship(ships.GetShipData(0), rng));
            oneOfEach.Add(new Ship(ships.GetShipData(2), rng));
            oneOfEach.Add(new Ship(ships.GetShipData(4), rng));
            oneOfEach.Add(new Ship(ships.GetShipData(6), rng));
            oneOfEach.Add(new Ship(ships.GetShipData(7), rng));

            Console.WriteLine(oneOfEach[0].ToString());
            Console.WriteLine(oneOfEach[1].ToString());
            Console.WriteLine(oneOfEach[2].ToString());
            Console.WriteLine(oneOfEach[3].ToString());
            Console.WriteLine(oneOfEach[4].ToString());

            //Prints attack results at each range
            Console.WriteLine("\nAttack results for {0}.", oneOfEach[4].Name);
            damage = oneOfEach[2].GetAttackValue("short");
            Console.WriteLine(" \n - Short Range: {0}", damage);
            damage = oneOfEach[2].GetAttackValue("medium");
            Console.WriteLine(" \n - Medium Range: {0}", damage);
            damage = oneOfEach[2].GetAttackValue("long");
            Console.WriteLine(" \n - Long Range: {0}", damage);

            //Print defense results at each range
            Console.WriteLine("\nDefense results for {0}.", oneOfEach[4].Name);
            defense = oneOfEach[2].GetDefenseValue("short");
            Console.WriteLine(" \n - Short Range: {0}", defense);
            defense = oneOfEach[2].GetDefenseValue("medium");
            Console.WriteLine(" \n - Medium Range: {0}", defense);
            defense = oneOfEach[2].GetDefenseValue("long");
            Console.WriteLine(" \n - Long Range: {0}", defense);

            //Print how long it would take for the ship to be destroyed by predetermined value
            Console.WriteLine("\nDamage {0} by {1} until destroyed...", oneOfEach[2].Name, 4);
            Console.WriteLine(oneOfEach[2].ToString());

            //While the ship is still working
            while (!oneOfEach[2].IsDestroyed())
            {
                oneOfEach[2].TakeDamage(4);
                Console.WriteLine(oneOfEach[2].ToString());
            }

            Console.WriteLine();*/

            //Part 3 Test Finale
            ships.LoadData();
            Console.WriteLine("WE ARE A HIGHER POWER AND WE DEMAND ENTERTAINMENT!!!");

            //Initialize the ships
            ship1 = new Ship(ships.GetShipData(rng.Next(ships.Count)),rng);
            ship2 = new Ship(ships.GetShipData(rng.Next(ships.Count)),rng);

            //Print out ship info
            Console.WriteLine(ship1.ToString());
            Console.WriteLine(ship2.ToString());

            //While either of the ships is currently still active
            while(!ship1.IsDestroyed() && !ship2.IsDestroyed())
            {
                Console.WriteLine("\n\n~~~ Round {0} ~~~\n", rounds);

                //If they are currently engaged in long range combat
                if(rounds >= 1 && rounds <= 2)
                {
                    //Ship 1 attacking Ship 2
                    Console.WriteLine("{0} attack, {1} defends", 
                        ship1.Name, ship2.Name);
                    damage = ship1.GetAttackValue("long");
                    Console.WriteLine();
                    defense = ship2.GetDefenseValue("long");
                    Console.WriteLine("\n{0} avoided {1} of {2}'s {3} damage.", 
                        ship2.Name, defense, ship1.Name, damage);
                    totalDamage = damage - defense;
                    //If total damage is less than zero
                    if (totalDamage < 0)
                    {
                        totalDamage = 0;
                    }
                    ship2.TakeDamage(totalDamage);

                    Console.WriteLine();

                    //Ship 2 attacking Ship 1
                    Console.WriteLine("{0} attack, {1} defends", 
                        ship2.Name, ship1.Name);
                    damage = ship2.GetAttackValue("long");
                    Console.WriteLine();
                    defense = ship1.GetDefenseValue("long");
                    Console.WriteLine("\n{0} avoided {1} of {2}'s {3} damage.", 
                        ship1.Name, defense, ship2.Name, damage);
                    totalDamage = damage - defense;

                    //If total damage is less than zero
                    if (totalDamage < 0)
                    {
                        totalDamage = 0;
                    }
                    ship1.TakeDamage(totalDamage);
                }

                //If they are currently engaged in medium range combat
                else if (rounds > 2 && rounds <= 4)
                {
                    //Ship 1 attacking Ship 2
                    Console.WriteLine("{0} attack, {1} defends", 
                        ship1.Name, ship2.Name);
                    damage = ship1.GetAttackValue("medium");
                    Console.WriteLine();
                    defense = ship2.GetDefenseValue("medium");
                    Console.WriteLine("\n{0} avoided {1} of {2}'s {3} damage.", 
                        ship2.Name, defense, ship1.Name, damage);
                    totalDamage = damage - defense;

                    //If total damage is less than zero
                    if (totalDamage < 0)
                    {
                        totalDamage = 0;
                    }
                    ship2.TakeDamage(totalDamage);

                    Console.WriteLine();

                    //Ship 2 attacking Ship 1
                    Console.WriteLine("{0} attack, {1} defends", 
                        ship2.Name, ship1.Name);
                    damage = ship2.GetAttackValue("medium");
                    Console.WriteLine("");
                    defense = ship1.GetDefenseValue("medium");
                    Console.WriteLine("\n{0} avoided {1} of {2}'s {3} damage.", 
                        ship1.Name, defense, ship2.Name, damage);
                    totalDamage = damage - defense;

                    //If total damage is less than zero
                    if (totalDamage < 0)
                    {
                        totalDamage = 0;
                    }
                    ship1.TakeDamage(totalDamage);
                }

                //If they are currently engaged in short range combat
                else if (rounds > 4)
                {
                    //Ship 1 attacking Ship 2
                    Console.WriteLine("{0} attack, {1} defends", ship1.Name, ship2.Name);
                    damage = ship1.GetAttackValue("short");
                    Console.WriteLine();
                    defense = ship2.GetDefenseValue("short");
                    Console.WriteLine("\n{0} avoided {1} of {2}'s {3} damage.", 
                        ship2.Name, defense, ship1.Name, damage);
                    totalDamage = damage - defense;

                    //If total damage is less than zero
                    if (totalDamage < 0)
                    {
                        totalDamage = 0;
                    }
                    ship2.TakeDamage(totalDamage);

                    Console.WriteLine();

                    //Ship 2 attacking Ship 1
                    Console.WriteLine("{0} attack, {1} defends", ship2.Name, ship1.Name);
                    damage = ship2.GetAttackValue("short");
                    Console.WriteLine();
                    defense = ship1.GetDefenseValue("short");
                    Console.WriteLine("\n{0} avoided {1} of {2}'s {3} damage.", 
                        ship1.Name, defense, ship2.Name, damage);
                    totalDamage = damage - defense;

                    //If total damage is less than zero
                    if (totalDamage < 0)
                    {
                        totalDamage = 0;
                    }
                    ship1.TakeDamage(totalDamage);
                }

                Console.WriteLine();

                //Print out new stats for each ship
                Console.WriteLine(ship1.ToString());
                Console.WriteLine(ship2.ToString());
                rounds++;
            }

            //Results of the battle
            Console.WriteLine(" \n\n **** Final Results ****");

            //If ship 1 was destroyed
            if(ship1.IsDestroyed())
            {
                Console.WriteLine("{0} IS THE WINNER!!!", ship2.Name);
            }

            //If ship 2 was destroyed
            else if(ship2.IsDestroyed())
            {
                Console.WriteLine("{0} IS THE WINNER!!!", ship1.Name);
            }

            //If both of them were destroyed
            else if(ship1.IsDestroyed() && ship2.IsDestroyed())
            {
                Console.WriteLine("{0} AND {1} ARE BOTH DESTROYED!!! NO ONE WINS!!!", 
                    ship1.Name, ship2.Name);
            }

            //Print out final stats of each ship
            Console.WriteLine();
            Console.WriteLine(ship1.ToString());
            Console.WriteLine(ship2.ToString());
        }
    }
}
