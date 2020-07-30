using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Threading;

namespace getToKnowYourClassmates
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<string, string> classmateDictionary = new Dictionary<string, string>();

            Console.WriteLine("***** Welcome to my REALLY COOL POKEMON COLLECTION database thing!!! *****");
            Console.WriteLine();

            string[,] classMateInfo = new string[,]
            {
                { "Mewtwo", "Kabuto", "Squirtle", "Aerodactyl", "Cloyster", "Blastoise", "Chansey", "Articuno", "Seel", "Jolteon", "Venusaur", "Kadabra", "Rapidash", "Exeggutor", "Arbok", "Gengar", "Porygon", "Vulpix", "Snorlax", "Pidgeotto"},
                { "mindGamesGuy", "littleManDudeGuy", "turtleDude", "flyingDinoGuy", "shellasaurusRex", "waterCannonMan", "cuteAF", "flyingIcicle", "literallyASeal", "electroCutie", "flowerOnBackGuy", "spoonBender", "fireHorse", "treeGuy", "snakeySnake", "fatGhostGuy", "iLoveGeometry", "cuteLilFox", "bigSleepyOne", "birdMan"},
                { "39", "18", "15", "57", "64", "51", "78", "20", "73", "56", "75", "52", "19", "65", "41", "42", "86", "66", "97", "100"},
                { "Psychic", "Rock/Water", "Water", "Rock/Flying", "Water/Ice", "Water", "Normal", "Ice/Flying", "Water", "Electric", "Grass/Poison", "Psychic", "Fire", "Grass/Psychic", "Poison", "Ghost/Poison", "Normal", "Fire", "Normal", "Normal/Flying"}
            };

            bool cont = true;

            while (cont)
            {

                Console.WriteLine("My Pokemon collection is as follows: ");
                for (int col = 0; col <=19; col++)
                {
                    if (col + 1 <= 9)
                    {
                        Console.WriteLine((col + 1) + ")  " + classMateInfo[0,col]);
                    }
                    else
                    {
                        Console.WriteLine((col + 1) + ") " + classMateInfo[0, col]);
                    }
                    
                }
                Console.WriteLine();

                int choice = SelectPerson(classMateInfo);

                SelectAttribute(classMateInfo, choice+1);

                Console.WriteLine("Would you like to learn about another one of my Pokemon? y/n");
                try
                {

                    string input = Console.ReadLine();
                    if (input[0] == 'n')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Are you sure? y/n");
                        input = Console.ReadLine();
                        Console.ResetColor();

                        if (input[0] == 'y')
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Are you REALLY sure? y/n");
                            input = Console.ReadLine();
                            Console.ResetColor();

                            if (input[0] == 'y')
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine();
                                Console.WriteLine("OK, FINE! BE THAT WAY! Ahem, excuse me. I lost my cool for a sec... anyway...");
                                Console.WriteLine();
                                cont = false;
                                Console.ResetColor();
                            }
                        }
                    }
                }
                catch (IndexOutOfRangeException)
                {

                }
            }

            Console.WriteLine("***** Thank you for using my REALLY COOL POKEMON COLLECTION database thing *****");
            Console.WriteLine("Have an Awesometastic day!");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }

        public static int SelectAttribute(string[,] classMateInfo, int person)
        {
            int choice = 0;

            bool invalid = true;

            Console.WriteLine("What would you like to know about my " + classMateInfo[0, person - 1] + "? (Enter a number from 1-3)");
            Console.WriteLine("1) " + classMateInfo[0, person - 1] + "'s REALLY COOL nickname");
            Console.WriteLine("2) " + classMateInfo[0, person - 1] + "'s Level");
            Console.WriteLine("3) " + classMateInfo[0, person - 1] + "'s Pokemon type");
            Console.WriteLine();

            while (invalid)
            {
                try
                {
                    choice = int.Parse(Console.ReadLine());

                    if (choice > 0 && choice < 4)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        if (choice == 1)
                        {
                            Console.WriteLine("The nickname I gave " + classMateInfo[0, person - 1] + " is: " + classMateInfo[1, person - 1]);
                        }
                        else if (choice == 2)
                        {
                            Console.WriteLine(classMateInfo[0, person - 1] + " is at Lv. " + classMateInfo[2, person - 1]);
                        }
                        else
                        {
                            Console.WriteLine(classMateInfo[0, person - 1] + "'s type is " + classMateInfo[3, person - 1]);
                        }
                        Console.ResetColor();
                        Console.WriteLine();

                        invalid = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("That number is not in range, please try again.");
                        Console.ResetColor();
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sorry, that is not a valid number. Please try again.");
                    Console.ResetColor();
                }
            }

            return choice;
        }

        public static int SelectPerson(string[,] classMateName)
        {
            int choice = 0;
            bool invalid = true;
            while (invalid)
            {
                Console.WriteLine("Which of my Pokemon would you like to learn about? Please enter a number from 1-20");
                string input = Console.ReadLine();
                bool match = false;
                string name = "";

                for (int col = 0; col <= 19; col++)
                {
                    if (input.ToLower() == classMateName[0, col].ToLower())
                    {
                        name = classMateName[0, col];
                        match = true;
                        choice = col;
                        Console.WriteLine(match);
                        break;
                    }
                }

                try
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    if (match)
                    {
                        Console.WriteLine("You chose " + name);

                    }
                    else
                    {
                        choice = int.Parse(input);
                        Console.WriteLine("You chose " + classMateName[0,(choice-1)]);
                    }
                    Console.ResetColor();
                    Console.WriteLine();
                    invalid = false;
                    
                    
                    
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sorry, that is not a valid number. Please try again.");
                    Console.ResetColor();
                }
                catch (IndexOutOfRangeException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That number is not in range, please try again.");
                    Console.ResetColor();
                }

            }

            return choice;

        }        
    }
}
