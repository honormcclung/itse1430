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

                menuOption = Console.ReadLine();

                if (menuOption != "1")
                {
                    Console.WriteLine("Error: Invalid Input");
                }
            } while (menuOption != "1");

            QuitProgram();
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
    }
}