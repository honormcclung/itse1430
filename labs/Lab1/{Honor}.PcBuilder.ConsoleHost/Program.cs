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

        static void Test()
        {
            Console.WriteLine("Test Complete");
        }

        static void DisplayMenuOptions()
        {
            int cartTotal = 0;
            String menuOption = "";
            Boolean isQuitting = false;

            do
            {
                Console.WriteLine("Cart Total: $" + cartTotal);
                Console.WriteLine();

                Console.WriteLine("Enter Menu Option.");
                Console.WriteLine("Menu Options:");
                Console.WriteLine("1) Quit");

                menuOption = Console.ReadLine();
            } while (menuOption != "Quit" && menuOption != "quit");

            if (menuOption == "Quit")
            {
                Console.WriteLine("Are you sure you want to quit? (Enter Yes or No)");
                if (Console.ReadLine() == "No")
                {
                    isQuitting = true;
                } else
                {
                    do
                    {
                        Console.WriteLine("Cart Total: $" + cartTotal);
                        Console.WriteLine();

                        Console.WriteLine("Enter Menu Option.");
                        Console.WriteLine("Menu Options:");
                        Console.WriteLine("1) Quit");

                        menuOption = Console.ReadLine();
                    } while (menuOption != "Quit" && menuOption != "quit");
                }
            }
        }
    }
}