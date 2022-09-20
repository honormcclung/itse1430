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
                Console.WriteLine("3) View Order");

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
            double cartTotal = 0;
            String chosenProcessor = "";
            double processorPrice = 0;
            String chosenMemory = "";
            double memoryPrice = 0;
            Boolean isProcessorValid = false;
            Boolean isMemoryValid = false;

            String[] processors = {"AMD Ryzen 9 5900X", "AMD Ryzen 7 5700X", "AMD Ryzen 5 5600X", "Intel i9-12900K", "Intel i7-12700K", "Intel i5-12600K" };
            double[] processorPrices = {1410, 1270, 1200, 1590, 1400, 1280};
            String[] memory = { "8 GB", "16 GB", "32 GB", "64 GB", "128 GB"};
            double[] memoryPrices = {30, 40, 90, 410, 600};

            Console.WriteLine("{0,-20} {1,5}\n", "Processor", "Price");

            for (int currProcessor = 0; currProcessor < processors.Length; currProcessor++)
            {
                Console.WriteLine("{0,-20} {1,5:N1}", processors[currProcessor], processorPrices[currProcessor]);
            }

            do
            {
                Console.WriteLine("Select a processor:");
                chosenProcessor = Console.ReadLine();

                for (int currProcessor = 0; currProcessor < processors.Length; currProcessor++)
                {
                    if (chosenProcessor.Equals(processors[currProcessor]))
                    {
                        processorPrice = processorPrices[currProcessor];
                        cartTotal = cartTotal + processorPrices[currProcessor];
                        isProcessorValid = true;
                    }
                }

                if (isProcessorValid == false)
                {
                    Console.WriteLine("Invalid Input. Try again.");
                }
            } while (isProcessorValid == false);


            Console.WriteLine("{0,-20} {1,5}\n", "Memory", "Price");

            for (int currMemory = 0; currMemory < memory.Length; currMemory++)
            {
                Console.WriteLine("{0,-20} {1,5:N1}", memory[currMemory], memoryPrices[currMemory]);
            }

            do
            {
                Console.WriteLine("Select a memory option:");
                chosenMemory = Console.ReadLine();

                for (int currMemory = 0; currMemory < memory.Length; currMemory++)
                {
                    if (chosenMemory.Equals(memory[currMemory]))
                    {
                        memoryPrice = memoryPrices[currMemory];
                        cartTotal = cartTotal + memoryPrices[currMemory];
                        isMemoryValid = true;
                    }
                }

                if (isMemoryValid == false)
                {
                    Console.WriteLine("Invalid Input. Try again.");
                }
            } while (isMemoryValid == false);

            Console.WriteLine();
            Console.WriteLine("Cart Total: $" + cartTotal);

        }

        /*
        static void viewOrder (chosenProcessor, processorPrice, chosenMemory, memoryPrice, cartTotal)
        {
            Console.WriteLine("Processor: " + chosenProcessor + " $" + processorPrice);
            Console.WriteLine("Memory: " + chosenMemory + " $" + memoryPrice);
            Console.WriteLine("-------------------------");
            Console.WriteLine("Total: $" + cartTotal);
        }
        */
    }
}