using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1
{
    internal class Program
    {
        static void Main ( string[] args )
        {
            String chosenOption;
            Boolean hasMadeOrder = false;
            Boolean isQuitting = false;
            double cartTotal = 0;

            String[] processors = {"AMD Ryzen 9 5900X", "AMD Ryzen 7 5700X", "AMD Ryzen 5 5600X", "Intel i9-12900K", "Intel i7-12700K", "Intel i5-12600K" };
            double[] processorPrices = {1410, 1270, 1200, 1590, 1400, 1280};
            String[] memory = { "8 GB", "16 GB", "32 GB", "64 GB", "128 GB"};
            double[] memoryPrices = {30, 40, 90, 410, 600};

            List<String> computerParts = new List<String>();

            Console.WriteLine("Name: Honor");
            Console.WriteLine("Class: ISTE 1430");
            Console.WriteLine("Date: 9/19/2022");

            do
            {
                chosenOption = ChooseMenuOption(cartTotal);

                if (chosenOption == "1")
                {
                    if (QuitProgram() == true)
                    {
                        isQuitting = true;
                    }
                } else if (chosenOption == "2")
                {
                    newOrder(computerParts, cartTotal, processors, processorPrices, memory, memoryPrices);
                    hasMadeOrder = true;
                    cartTotal = Convert.ToDouble(computerParts.Last());
                } else if (chosenOption == "3")
                {
                    ViewOrder(computerParts, hasMadeOrder);
                } else if (chosenOption == "4")
                {
                    if (ClearOrder(computerParts) == true)
                    {
                        hasMadeOrder = false;
                        cartTotal = 0;
                    }
                } else if (chosenOption == "5")
                {
                    computerParts = ModifyOrder(computerParts, hasMadeOrder, processors, processorPrices, memory, memoryPrices);
                    cartTotal = Convert.ToDouble(computerParts.Last());
                }
            } while (isQuitting == false);

        }

        static void DisplayMenuOptions (double cartTotal)
        {
            Console.WriteLine();
            Console.WriteLine("Cart Total: $" + cartTotal);
            Console.WriteLine("----------------------");
            Console.WriteLine("Enter Menu Option: ");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1) Quit");
            Console.WriteLine("2) New Order");
            Console.WriteLine("3) View Order");
            Console.WriteLine("4) Clear Order");
            Console.WriteLine("5) Modify Order");
        }

        static String ChooseMenuOption (double cartTotal)
        {
            string menuOption; 

            do
            {
                DisplayMenuOptions(cartTotal);
                menuOption = Console.ReadLine();
                    if (menuOption != "1" && menuOption != "2" && menuOption != "3" && menuOption != "4" && menuOption != "5")
                    {
                        Console.WriteLine("Error: Invalid Input");
                    } 
            } while (menuOption != "1" && menuOption != "2" && menuOption != "3" && menuOption != "4" && menuOption != "5");

            return  menuOption;
        }

        static Boolean QuitProgram ()
        {
            Boolean isQuitting = true; 

            Console.WriteLine("Are you sure you want to quit? (Enter Yes or No)");

            if (Console.ReadLine() == "No")
            {
                isQuitting = false;
            } else
            {
                Console.WriteLine("Program Quit.");
                Console.ReadLine();
            }

            return isQuitting;
        }

        static Boolean ClearOrder (List<String> computerParts)
        {
            Console.WriteLine("Are you sure you want to clear your order? (Enter Yes or No)");

            if (Console.ReadLine() == "Yes")
            {
                computerParts.Clear();
                return true;
            } else
            {
                return false;
            }

        }

        static List<String> newOrder (List<String> computerParts, double cartTotal, 
                                      String[] processors, double[] processorPrices, string[] memory,
                                      double[] memoryPrices)
        {
            
            String chosenProcessor = "";
            double processorPrice = 0;
            String chosenMemory = "";
            double memoryPrice = 0;
            Boolean isProcessorValid = false;
            Boolean isMemoryValid = false;

            computerParts.AddRange(ChooseProcessor(processors, processorPrices));
            cartTotal = AddToTotal(cartTotal, Convert.ToDouble(computerParts[1]));
            computerParts.AddRange(ChooseMemory(memory, memoryPrices));
            cartTotal = AddToTotal(cartTotal, Convert.ToDouble(computerParts[3]));
            computerParts.Add(cartTotal.ToString());

            ViewOrder(computerParts, true);

            /*
            String[] processors = {"AMD Ryzen 9 5900X", "AMD Ryzen 7 5700X", "AMD Ryzen 5 5600X", "Intel i9-12900K", "Intel i7-12700K", "Intel i5-12600K" };
            double[] processorPrices = {1410, 1270, 1200, 1590, 1400, 1280};
            String[] memory = { "8 GB", "16 GB", "32 GB", "64 GB", "128 GB"};
            double[] memoryPrices = {30, 40, 90, 410, 600};
            */
            
            /*
            Console.WriteLine("{0,-20} {1,5}\n", "Processor", "Price");

            for (int currProcessor = 0; currProcessor < processors.Length; currProcessor++)
            {
                Console.WriteLine("{0,-20} {1,5:N1}", processors[currProcessor], processorPrices[currProcessor]);
            }

            do
            {
                Console.WriteLine("Select a processor:");
                chosenProcessor = Console.ReadLine();
                //computerParts.Add(chosenProcessor);

                for (int currProcessor = 0; currProcessor < processors.Length; currProcessor++)
                {
                    if (chosenProcessor.Equals(processors[currProcessor]))
                    {
                        computerParts.Add(chosenProcessor);
                        processorPrice = processorPrices[currProcessor];
                        computerParts.Add(processorPrice.ToString());
                        cartTotal = AddToTotal(cartTotal,processorPrices[currProcessor]);
                        isProcessorValid = true;
                    }
                }

                if (isProcessorValid == false)
                {
                    Console.WriteLine("Invalid Input. Try again.");
                    Console.WriteLine();
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
                //computerParts.Add(chosenMemory);

                for (int currMemory = 0; currMemory < memory.Length; currMemory++)
                {
                    if (chosenMemory.Equals(memory[currMemory]))
                    {
                        computerParts.Add(chosenMemory);
                        memoryPrice = memoryPrices[currMemory];
                        computerParts.Add(memoryPrice.ToString());
                        cartTotal = AddToTotal(cartTotal, memoryPrices[currMemory]);
                        isMemoryValid = true;
                    }
                }

                if (isMemoryValid == false)    
                { 
                    Console.WriteLine("Invalid Input. Try again.");
                }
            } while (isMemoryValid == false);

            computerParts.Add(cartTotal.ToString());

            ViewOrder(computerParts, true);
            */
            
            return computerParts;

        }
       
        static double AddToTotal (double cartTotal, double priceToAdd)
        {
            cartTotal = cartTotal + priceToAdd;
            return cartTotal;
        }
          
        static void ViewOrder (List<String> computerParts, Boolean hasMadeOrder)
        {
            if (hasMadeOrder == true)
            {
                Console.WriteLine();
                Console.WriteLine("Processor:   " + computerParts[0] + "    $" + computerParts[1]);
                Console.WriteLine("Memory:      " + computerParts[2] + "              $" + computerParts[3]);
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Total:                         $" + computerParts.Last());
            } else
            {
                Console.WriteLine();
                Console.WriteLine("No Order.");
            }
        }
        
        static List<String> ModifyOrder (List<String> computerParts, Boolean hasMadeOrder, String[] processors, double[] processorPrices,
                                         string[] memory, double[] memoryPrices)
        {
            String menuOption; 
            List<String> processorInfo = new List<String>();
            List<String> memoryInfo = new List<String>();
            double cartTotal = 0;

            if (hasMadeOrder == true)
            {
                do
                {
                    Console.WriteLine("Current Order:");
                    ViewOrder(computerParts, true);
                    Console.WriteLine();
                    Console.WriteLine("Options:");
                    Console.WriteLine("1) Modify Processor");
                    Console.WriteLine("2) Modify Memory");
                    Console.WriteLine("3) Return to Menu");

                    //DisplayMenuOptions(cartTotal);
                    menuOption = Console.ReadLine();
                    if (menuOption != "1" && menuOption != "2" && menuOption != "3")
                    {
                        Console.WriteLine("Error: Invalid Input");
                    } 
                } while (menuOption != "1" && menuOption != "2" && menuOption != "3");

                if (menuOption == "1")
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter new processor:");
                    processorInfo = ChooseProcessor(processors, processorPrices);
                    computerParts[0] = processorInfo[0];
                    cartTotal = cartTotal - Convert.ToDouble(computerParts[1]);
                    computerParts[1] = processorInfo[1];
                    cartTotal = AddToTotal(cartTotal, Convert.ToDouble(computerParts[1]));

                } else if (menuOption == "2")
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter new Memory:");
                    memoryInfo = ChooseMemory(memory, memoryPrices);
                    computerParts[2] = memoryInfo[0];
                    cartTotal = cartTotal - Convert.ToDouble(computerParts[3]);
                    computerParts[3] = memoryInfo[1];
                    cartTotal = AddToTotal(cartTotal, Convert.ToDouble(computerParts[3]));
                }
            
            } else
            {
                Console.WriteLine();
                Console.WriteLine("No Order.");
            }

            return computerParts;

        }

        static List<String> ChooseProcessor (String[] processors, double[] processorPrices)
        {
            List<String> processorInfo = new List<String>();

            String chosenProcessor = "";
            double processorPrice = 0;
            Boolean isProcessorValid = false;

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
                        processorInfo.Add(chosenProcessor);
                        processorPrice = processorPrices[currProcessor];
                        processorInfo.Add(processorPrice.ToString());
                        //cartTotal = AddToTotal(cartTotal,processorPrices[currProcessor]);
                        isProcessorValid = true;
                    }
                }

                if (isProcessorValid == false)
                {
                    Console.WriteLine("Invalid Input. Try again.");
                    Console.WriteLine();
                }
            } while (isProcessorValid == false);

            return processorInfo;
        }

        static List<String> ChooseMemory (string[] memory, double[] memoryPrices)
        {
            List<String> memoryInfo = new List<String>();

            String chosenMemory = "";
            double memoryPrice = 0;
            Boolean isMemoryValid = false;

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
                        memoryInfo.Add(chosenMemory);
                        memoryPrice = memoryPrices[currMemory];
                        memoryInfo.Add(memoryPrice.ToString());
                        //cartTotal = AddToTotal(cartTotal, memoryPrices[currMemory]);
                        isMemoryValid = true;
                    }
                }

                if (isMemoryValid == false)    
                { 
                    Console.WriteLine("Invalid Input. Try again.");
                }
            } while (isMemoryValid == false);

            return memoryInfo;
        }
    }
}