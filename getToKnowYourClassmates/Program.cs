using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace getToKnowYourClassmates
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<string, string> classmateDictionary = new Dictionary<string, string>();

            Console.WriteLine("***** Welcome to my REALLY COOL STUDENT DATABASE!!! *****");
            Console.WriteLine();

            string[,] classMateInfo = new string[3, 3]
            {
                { "Josh", "Robbie", "Jordan"},
                { "Baseball", "Soccer", "Basketball"},
                { "Blue", "Yellow", "Blue"}
            };

            bool cont = true;

            while (cont)
            {
                //int count = 0;
                //foreach (string classMate in classMateInfo)
                //{
                    

                //    Console.WriteLine((count + 1) + ": " + classMateInfo[0,count]);

                //    //count++;

                //}

                

                int choice = SelectPerson(classMateInfo);

                SelectAttribute(classMateInfo, choice);

                Console.WriteLine("Would you like to learn about another student? y/n");
                string input = Console.ReadLine();
                if (input[0] == 'n')
                {
                    cont = false;
                }

            }

            Console.WriteLine("***** Thank you for using my REALLY COOL STUDENT DATABASE!!! *****");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }

        public static int SelectAttribute(string[,] classMateInfo, int person)
        {
            int choice = 0;

            bool invalid = true;
            while (invalid)
            {
                Console.WriteLine("What would you like to know about " + classMateInfo[0, person - 1] + "? Enter 1 for their favorite sport, or 2 for their favorite color.");

                try
                {
                    choice = int.Parse(Console.ReadLine());

                    if (choice > 0 && choice < 3)
                    {
                        if (choice == 1)
                        {
                            Console.WriteLine(classMateInfo[0, person - 1] + "'s favorite sport is " + classMateInfo[1, person - 1]);
                        }
                        else
                        {
                            Console.WriteLine(classMateInfo[0, person - 1] + "'s favorite color is " + classMateInfo[2, person - 1]);
                        }
                        
                        invalid = false;
                    }
                    else
                    {
                        Console.WriteLine("That number is not in range, please try again.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Sorry, that is not a valid number. Please try again.");
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
                Console.WriteLine("Which student would you like to learn about? Please enter a number from 1-3");

                try
                {
                    choice = int.Parse(Console.ReadLine());

                    if (choice > 0 && choice < 4)
                    {
                        Console.WriteLine("You chose " + classMateName[0,(choice-1)]);
                        invalid = false;
                    }
                    else
                    {
                        Console.WriteLine("That number is not in range, please try again.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Sorry, that is not a valid number. Please try again.");
                }
            }

            return choice;

        }        
    }
}
