using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemApp
{
    internal class Program
    {

        //global variables

        static string flag = "e";

        static int chemChoice = 1;

        static int chemRemain = 6;

        static int topChem = 0;
        static string topName = "";

        static int botChem = 99999999;
        static string botName = "";

        static int effAv = 0;

        const int TIME = 5000;

        

        static List<int> efficiency = new List<int>() { 7, 3, 4, 2, 6 };

        static List<string> chemicals = new List<string>() { "Cyanide", "Sulfuric Acid", "Lemonade", "Propane", "Alcohol" };

        //methods/functions

        static string CheckFlag()
        {

            if (chemicals.Count < 1)
            {

                Console.WriteLine("All chemicals have been used, automatically exiting.");
                flag = "XXX";
                return flag;

            }

            while (true)
            {



                Console.WriteLine("Type XXX to exit or press enter to continue.");

                flag = Console.ReadLine();

                flag = flag.ToUpper();

                if (flag.Equals("XXX") || flag.Equals(""))
                {

                    return flag;

                }

                Console.WriteLine("Error: Invalid Input.");

            }
        }

        static int CheckChem()
        {

            while (true)
            {
                try
                {
                    string chemMenu = "Please enter a number for the chemical you wish to test.\n";

                    for (int i = 0; i < chemicals.Count; i++)
                    {

                        chemMenu += $"{i + 1}. {chemicals[i]}\n";

                    }

                    Console.WriteLine(chemMenu);

                    chemChoice = Convert.ToInt32(Console.ReadLine());

                    if (chemChoice > 0 && chemChoice < chemRemain)
                    {

                        chemRemain = chemRemain - 1;

                        return chemChoice;
                        
                    }

                    Console.WriteLine("Error: Invalid Input.");
                }
                catch 
                {
                    Console.WriteLine("Error: Invalid Input.");
                }

            }
        }


        static void ChemicalTest()
        {

            //reset values to 0

            int effRating = 0;
            


            //ask user for the chemical they are testing



            CheckChem();

            Console.WriteLine($"{chemicals[chemChoice - 1]}");
            
            

            for (int i = 0; i < 5; i++)
            {
                
                //generate live germs

                Random ranGen = new Random();

                int preGerms = ranGen.Next(1000, 10001);

                //display live germs

                Console.WriteLine($"Current germ sample size: {preGerms}");

                //wait for a set amount of time

                Console.WriteLine("Please wait a moment while we test.");

                System.Threading.Thread.Sleep(TIME);

                int postGerms = preGerms / efficiency[chemChoice - 1];

                //re-measure and display post germs

                Console.WriteLine($"{postGerms}");

                //determine efficiency rating

                effRating = (preGerms - postGerms) / (TIME / 100);

                effAv = effAv + effRating;


            }


            //average the 5 tests

            effAv = effAv / 5;


            if (effAv > topChem)
            {

                topChem = effAv;
                topName = chemicals[chemChoice - 1];

            }

            if (effAv < botChem)
            {

                botChem = effAv;
                botName = chemicals[chemChoice - 1];

            }

            //display average and chemical name

            Console.WriteLine($"The average efficiency rating of {chemicals[chemChoice - 1]} is: {effAv}");

            
            chemicals.Remove(chemicals[chemChoice - 1]);
            

        }

        static void Main(string[] args)
        {

            //displays title and 

            Console.WriteLine(@" _____ _                       ___  " + "\n" +
            @"/  __ \ |                     / _ \" + "  \n" +
            @"| /  \/ |__   ___ _ __ ___   / /_\ \_ __  _ __  " + "\n" +
            @"| |   | '_ \ / _ \ '_ ` _ \  |  _  | '_ \| '_ \  " + "\n" +
            @"| \__/\ | | |  __/ | | | | | | | | | |_) | |_) |  " + "\n" +
            @" \____/_| |_|\___|_| |_| |_| \_| |_/ .__/| .__/  " + "\n" +
            @"                                   | |   | |  " + "\n" +
            @"                                   |_|   |_|  " + "\n\n");
            
            Console.WriteLine("██████████████████████████████████████████████████\n");

            Console.WriteLine("Welcome to Chemical App. (Chem App for short) \n\nChem App will calculate the efficiency of a user selected chemical\n" +
                "It will generate and display the germ sample before testing \nIt will then calculate and display the remaining germs and then repeat this 5 times\n" +
                "Once it has finished testing it will calculate efficiency of the chemical \nThe user will then be asked if they want to continue or exit\n" +
                "if they choose to continue the program will repeat the previous processes \nhowever if they choose to exit by entering XXX, the program will display the best and worst chemicals\n");


            //loop ChemicalTest() until user enters "XXX"

            while (!flag.Equals("XXX"))
            {

                


                //run ChemicalTest()
                
                ChemicalTest();

                //run CheckFlag()

                CheckFlag();

                

            }



            //display topChem and botChem

            Console.WriteLine($"The highest rating out of all the chemicals tested was: {topName} \nEfficiency: {topChem} \n\nThe lowest rating out of all the chemicals tested was: {botName} \nEfficiency: {botChem}");

        }
    }
}
