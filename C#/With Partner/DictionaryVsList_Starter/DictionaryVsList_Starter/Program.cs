using System;
using System.Collections.Generic;

namespace DictionaryVsList_Starter
{
	class Program
	{
		static void Main(string[] args)
		{
			//variables
			string option;
			string wordDouble;
			System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();

			// Creates a new file reader, which loads a file of words
			// into both a list and a dictionary
			PracticeExerciseFileReader reader = new PracticeExerciseFileReader();

			// Get the two data structures needed for the exercise
			List<String> wordList = reader.WordList;
			Dictionary<String, bool> wordDictionary = reader.WordDictionary;

			// *********************
			// TODO: Put your code between here...
			Console.Write("Do you want to search the (L)ist or (D)ictionary? ");
			option = Console.ReadLine().ToUpper().Trim();

			switch(option)
            {
				//List
				case "L":
					watch.Start();

					//Checks each word that is in the list
					for (int i = 0; i < wordList.Count; i++)
                    {
						wordDouble = wordList[i] + wordList[i];

						//If the word is in the list
						if (wordList.Contains(wordDouble))
                        {
							Console.WriteLine(wordDouble);
						}
                    }
					watch.Stop();
					Console.WriteLine(
						"List search for all double words took "
						+ watch.Elapsed.TotalMilliseconds + "ms\n");
					break;

				//Dictionary
				case "D":
					watch.Start();

					//Checks each word that is in the dictionary
					for (int i = 0; i < wordDictionary.Count; i++)
					{
						wordDouble = wordList[i] + wordList[i];

						//If the word is in the dictionary
						if (wordDictionary.ContainsKey(wordDouble))
						{
							Console.WriteLine(wordDouble);
							wordDictionary[wordDouble] = true;
						}
					}
					watch.Stop();
					Console.WriteLine(
						"List search for all double words took "
						+ watch.Elapsed.TotalMilliseconds + "ms\n");

					//While the user does not want to quit
					while(option != "quit")
					{
						Console.Write("Which word do you want to check (or enter QUIT)? ");
						option = Console.ReadLine().ToLower();

						//if the word is in the dictionary
						if (wordDictionary.ContainsKey(option))
						{
							//if the word is a double word
							if(wordDictionary[option])
                            {
								Console.WriteLine("{0} IS a double word", option);
							}

							//if it is not a double word
							else
							{
								Console.WriteLine("{0} IS NOT a double word (or is not in the list).", option);
							}
						}

						//if it is not in the list
						else
						{
							Console.WriteLine("{0} IS NOT a double word (or is not in the list).", option);
						}
					}
					break;

				//not an option
				default:
					Console.WriteLine("Invalid input.");
					break;
            }
			// ...and here.
			// *********************

		}
	}
}
