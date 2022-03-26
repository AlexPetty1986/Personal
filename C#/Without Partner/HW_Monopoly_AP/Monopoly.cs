using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Monopoly_AP
{
    class Monopoly
    {
		//Private variables
        private Dice dice;
		private String[] propertyNames = 
		{
			"Go",
			"Mediterranean Avenue",
			"Community Chest (1)",
			"Baltic Avenue",
			"Income Tax",
			"Reading Railroad",
			"Oriental Avenue",
			"Chance (1)",
			"Vermont Avenue",
			"Connecticut Avenue",
			"Jail",
			"St. Charles Place",
			"Electric Company",
			"States Avenue",
			"Virginia Avenue",
			"Pennsylvania Railroad",
			"St. James Place",
			"Community Chest (2)",
			"Tennessee Avenue",
			"New York Avenue",
			"Free Parking",
			"Kentucky Avenue",
			"Chance (2)",
			"Indiana Avenue",
			"Illinois Avenue",
			"B&O Railroad",
			"Atlantic Avenue",
			"Ventnor Avenue",
			"Water Works",
			"Marvin Gardens",
			"Go To Jail",
			"Pacific Avenue",
			"North Carolina Avenue",
			"Community Chest (3)",
			"Pennsylvania Avenue",
			"Short Line Railroad",
			"Chance (3)",
			"Park Place",
			"Luxury Tax",
			"Boardwalk"
		};
		private int numPlayers;
        private int roundabout;

		//Constructor class
        public Monopoly(int numPlayers, int roundabout)
        {
            this.numPlayers = numPlayers;
            this.roundabout = roundabout;
			this.dice = new Dice();
		}


		//Analyzes the average amount of times each space is landed on
		public double[] Analyze()
		{
			//constants
			const int TOTAL_DICE = 2;
			//variables
			int totalSpaces;
			int[] visits = new int[propertyNames.Length];
			double[] visitPercentages = new double[propertyNames.Length];
			int position = 0;
			double totalVisits = 0;

			//For the number of players playing
			for(int i = 0; i < numPlayers; i++)
            {
				//While total rolls is less than max turns needed
				while(totalVisits <= roundabout)
                {
					totalSpaces = dice.RollDice(TOTAL_DICE);

					//For each space the player takes
					for(int j = 0; j < totalSpaces; j++)
                    {
						position++;

						//If they pass go
						if (position == propertyNames.Length)
						{
							position = 0;
							totalVisits++;
						}
					}

					//Adds number of times space was landed on in array
					visits[position] += 1;

					//If they land on GO TO JAIL
					if (position == 30)
					{
						position = 10;
						totalVisits++;
					}
				}
            }

			//Stores the average amount of times a space is landed on into the array
			for(int j = 0; j < visits.Length; j++)
            {
				visitPercentages[j] = (visits[j] / totalVisits) * 100;
            }

			return visitPercentages;
		}

		//Prints the results onto the screen
		public void PrintResults(double[] visitPercentages)
        {
			Console.WriteLine("\nStudy Results:\n");

			//While i is less then the length of propertyNames
			for(int i = 0; i < propertyNames.Length; i++)
            {
				Console.WriteLine("\t\t\t{0} : {1:F2}", propertyNames[i], visitPercentages[i]);

            }
		}
	}
}
