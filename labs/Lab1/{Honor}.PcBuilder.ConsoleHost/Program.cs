using System;

namespace Lab1
{
    internal class Program
    {
        static void Main ( string[] args )
        {
            Console.WriteLine("Name: Honor");
            Console.WriteLine("Class: ISTE 1430");
            Console.WriteLine("Date: 9/19/2022");

            Test();
            DisplayMenuOptions();
        }

        static void Test ()
        {
            Console.WriteLine("Test Complete");
        }

        static void DisplayMenuOptions ()
        {
            int cartTotal = 0;
            String menuOption = "";

            do
            {
                Console.WriteLine();
                Console.WriteLine("Cart Total: $" + cartTotal);

                Console.WriteLine("Enter Menu Option.");
                Console.WriteLine("Menu Options:");
                Console.WriteLine("1) Quit");
                Console.WriteLine("2) New Order");

                menuOption = Console.ReadLine();

                if (menuOption != "1" && menuOption != "2")
                {
                    Console.WriteLine("Error: Invalid Input");
                }
            } while (menuOption != "1" && menuOption != "2");

            if (menuOption == "1")
            {
                QuitProgram();
            } else if (menuOption == "2")
            {
                newOrder();
            }
        }

        static void QuitProgram ()
        {
            Console.WriteLine("Are you sure you want to quit? (Enter Yes or No)");

            if (Console.ReadLine() == "No")
            {
                DisplayMenuOptions();
            } else
            {
                Console.WriteLine("Program Quit.");
            }
        }

        static void newOrder ()
        {
            int cartTotal = 0;
            String chosenProcessor = "";
            String chosenMemory = "";

            String[] processors = {"AMD Ryzen 9 5900X", "AMD Ryzen 7 5700X", "AMD Ryzen 5 5600X", "Intel i9-12900K", "Intel i7-12700K", "Intel i5-12600K" };
            double[] processorPrices = {1410, 1270, 1200, 1590, 1400, 1280};
            String[] memory = { "8 GB", "16 GB" };
            double[] memoryPrices = { };

            Console.WriteLine("Select a processor:");
            Console.WriteLine();
            Console.WriteLine("{0,-20} {1,5}\n", "Processor", "Price");

            for (int currProcessor = 0; currProcessor < processors.Length; currProcessor++)
            {
                Console.WriteLine("{0,-20} {1,5:N1}", processors[currProcessor], processorPrices[currProcessor]);
            }

            chosenProcessor = Console.ReadLine(); 


        }
    }
}