using System;
using System.Collections.Generic;
using System.Text;

namespace HW8_BattleDamage_AP
{
    class Ship
    {
        //private fields
        private string faction;
        private string name;
        private int mainWeapon;
        private int agility;
        private int hull;
        private int shield;
        private Random rng;

        //Constructor
        public Ship(string[] data, Random rng)
        {
            this.faction = data[0];
            this.name = data[1];
            this.mainWeapon = int.Parse(data[2]);
            this.agility = int.Parse(data[3]);
            this.hull = int.Parse(data[4]);
            this.shield = int.Parse(data[5]);
            this.rng = rng;
        }

        //Getter
        public string Name
        {
            get { return name; }
        }

        //ToString method
        public override string ToString()
        {
            return "Faction: " + faction + " Name: " + name + " Main Weapon: " + 
                mainWeapon + " Agility: " + agility + " Hull: " + hull + " Shields:" + shield;
        }

        //Calculates how much damage the ship might be able to do
        public int GetAttackValue(string range)
        {
            //Variables
            int damage = 0;
            int roll = 0;

            //Determines the range
            switch(range)
            {
                //Long range attack
                case "long":
                    //For each dice being rolled based on mainWeapon value
                    for (int i = 0; i < mainWeapon; i++)
                    {
                        roll = rng.Next(1, 9);

                        if(roll == 1)
                        {
                            Console.Write("Critical! ");
                            damage += 2;
                        }

                        else if(roll >= 2 && roll <= 4)
                        {
                            Console.Write("Regular Hit! ");
                            damage += 1;
                        }

                        else if(roll >= 5 && roll <= 8)
                        {
                            Console.Write("Miss! ");
                            damage += 0;
                        }
                    }
                    break;

                //Medium range attack
                case "medium":
                    //For each dice being rolled based on mainWeapon value
                    for (int i = 0; i < mainWeapon; i++)
                    {
                        roll = rng.Next(1, 9);

                        if (roll == 1)
                        {
                            Console.Write("Critical! ");
                            damage += 2;
                        }

                        else if (roll >= 2 && roll <= 4)
                        {
                            Console.Write("Regular Hit! ");
                            damage += 1;
                        }

                        else if (roll >= 5 && roll <= 8)
                        {
                            Console.Write("Miss! ");
                            damage += 0;
                        }
                    }
                    break;

                //Short range attack
                case "short":
                    //For each dice being rolled based on mainWeapon value
                    for(int i = 0; i < mainWeapon + 1; i++)
                    {
                        roll = rng.Next(1, 9);

                        //Critical Hit
                        if (roll == 1)
                        {
                            Console.Write("Critical! ");
                            damage += 2;
                        }

                        //Regular Hit
                        else if (roll >= 2 && roll <= 4)
                        {
                            Console.Write("Regular Hit! ");
                            damage += 1;
                        }

                        //Miss
                        else if (roll >= 5 && roll <= 8)
                        {
                            Console.Write("Miss! ");
                            damage += 0;
                        }
                    }
                    break;
            }

            //Return how much damage the ship can potentionlly do
            return damage;
        }

        //Caluclates how much damage a ship could potentionally prevent
        public int GetDefenseValue(string range)
        {
            //Variables
            int roll = 0;
            int defend = 0;

            //Determines the range of the attack
            switch (range)
            {
                //Long range attack
                case "long":
                    //For each dice being rolled based on the ability value
                    for (int i = 0; i < agility + 1; i++)
                    {
                        roll = rng.Next(1, 9);

                        //Evade
                        if (roll >= 1 && roll <= 3)
                        {
                            Console.Write("Evade! ");
                            defend += 1;
                        }

                        //Fail to evade
                        else if (roll >= 4 && roll <= 8)
                        {
                            Console.Write("No Effect! ");
                            defend += 0;
                        }
                    }
                        break;

                //Medium range attack
                case "medium":
                    //For each dice being rolled based on the ability value
                    for (int i = 0; i < agility + 1; i++)
                    {
                        roll = rng.Next(1, 9);

                        //Evade
                        if (roll >= 1 && roll <= 3)
                        {
                            Console.Write("Evade! ");
                            defend += 1;
                        }

                        //Failed to evade
                        else if (roll >= 4 && roll <= 8)
                        {
                            Console.Write("No Effect! ");
                            defend += 0;
                        }
                    }
                    break;

                //Short range attack
                case "short":
                    //For each dice being rolled based on the ability value
                    for (int i = 0; i < agility + 1; i++)
                    {
                        roll = rng.Next(1, 9);

                        //Evade
                        if (roll >= 1 && roll <= 3)
                        {
                            Console.Write("Evade! ");
                            defend += 1;
                        }

                        //Failed to evade
                        else if (roll >= 4 && roll <= 8)
                        {
                            Console.Write("No Effect! ");
                            defend += 0;
                        }
                    }
                    break;
            }

            //Return how much damage will be prevented
            return defend;
        }

        //Finalizes damage done to ship
        public void TakeDamage(int totalDamage)
        {
            //If shield is stronger than the incoming attack
            if(shield > totalDamage)
            {
                shield = shield - totalDamage;
            }
            //if it is not
            else if(shield <= totalDamage)
            {
                totalDamage = totalDamage - shield;
                hull -= totalDamage;
                shield = 0;
            }
        }

        //Determines if the ship has been destroyed or not
        public bool IsDestroyed()
        {
            //If both the shield and the hull have been destroyed
            if(shield <= 0 && hull <= 0)
            {
                return true;
            }

            return false;
        }
    }
}
