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

        static int topChem = 0;
        static string topName = "";

        static int botChem = 99999999;
        static string botName = "";

        static int effAv = 0;

        const int TIME = 5000;

        static List<int> efficiency = new List<int>() { 7, 3, 4, 2, 6 };

        static List<string> chemicals = new List<string>() { "Cyanide", "Sulfuric Acid", "Lemonade", "Propane", "Alcohol" };

        //methods/functions

        static void ChemicalTest()
        {

            //reset values to 0

            int effRating = 0;

            int chemChoice = 1;

            //ask user for the chemical they are testing

            Console.WriteLine("Please enter a number for the chemical you wish to test.\n1. Cyanide \n2. Sulfuric Acid\n3. Lemonade\n4. Propane\n5. Alcohol");

            chemChoice = Convert.ToInt32(Console.ReadLine());

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

        }

        static void Main(string[] args)
        {


            string flag = "";

            //loop ChemicalTest() until user enters "XXX"

            while (!flag.Equals("XXX"))
            {

                //run ChemicalTest()

                ChemicalTest();

                //prompt the user if they want to exit or continue

                Console.WriteLine("Type XXX to exit or press enter to continue.");

                flag = Console.ReadLine();

                

            }



            //display topChem and botChem

            Console.WriteLine($"The highest rating out of all the chemicals tested was: \n{topName} \nEfficiency: {topChem} \n\nThe lowest rating out of all the chemicals tested was: {botName} \nEfficiency: {botChem}");

        }
    }
}
