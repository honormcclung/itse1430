﻿using System;
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
            String[] primaryStorageOptions = {"SSD 256 GB", "SSD 512 GB", "SSD 1 TB", "SSD 2 TB"};
            double[] primaryStoragePrices = {90, 100, 125, 230};
            String[] secondaryStorageOptions = {"None", "HDD 1 TB", "HDD 2 TB", "HDD 4 TB", "SSD 512 GB", "SSD 1 TB", "SSD 2 TB"};
            double[] secondaryStoragePrices = {0, 40, 50, 70, 100, 125, 230};
            String[] graphicsCardOptions = {"None", "GeForce RTX 3070", "GeForce RTX 2070", "Radeon RX 6600", "Radeon RX 5600"};
            double[] graphicsCardPrices = {0, 580, 400, 300, 325};
            String[] operatingSystemOptions = {"Windows 11 Home", "Windows 11 Pro", "Windows 10 Home", "Windows 10 Pro", "Linux (Fedora)", "Linux (Red Hat)"};
            double[] operatingSystemPrices = {140, 160, 150, 170, 20, 60};

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
                    newOrder(computerParts, cartTotal, processors, processorPrices, memory, memoryPrices, primaryStorageOptions,
                             primaryStoragePrices, secondaryStorageOptions, secondaryStoragePrices, graphicsCardOptions, 
                             graphicsCardPrices, operatingSystemOptions, operatingSystemPrices);
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
                    computerParts = ModifyOrder(computerParts, hasMadeOrder, processors, processorPrices, memory, memoryPrices, primaryStorageOptions,
                                                primaryStoragePrices, secondaryStorageOptions, secondaryStoragePrices, graphicsCardOptions, graphicsCardPrices,
                                                operatingSystemOptions, operatingSystemPrices);
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

        static List<String> newOrder (List<String> computerParts, double cartTotal, String[] processors, double[] processorPrices, 
                                      String[] memory, double[] memoryPrices, String[] primaryStorageOptions, double[] primaryStoragePrices,
                                      String[] secondaryStorageOptions, double[] secondaryStoragePrices, String[] graphicsCardOptions,
                                      double[] graphicsCardPrices, String[] operatingSystemOptions, double[] operatingSystemPrices)
        {
            computerParts.AddRange(ChooseProcessor(processors, processorPrices));
            cartTotal = AddToTotal(cartTotal, Convert.ToDouble(computerParts[1]));
            computerParts.AddRange(ChooseMemory(memory, memoryPrices));
            cartTotal = AddToTotal(cartTotal, Convert.ToDouble(computerParts[3]));
            computerParts.AddRange(choosePrimaryStroage(primaryStorageOptions, primaryStoragePrices));
            cartTotal = AddToTotal(cartTotal, Convert.ToDouble(computerParts[5]));
            computerParts.AddRange(chooseSecondaryStroage(secondaryStorageOptions, secondaryStoragePrices));
            cartTotal = AddToTotal(cartTotal, Convert.ToDouble(computerParts[7]));
            computerParts.AddRange(chooseGraphicsCard(graphicsCardOptions, graphicsCardPrices));
            cartTotal = AddToTotal(cartTotal, Convert.ToDouble(computerParts[9]));
            computerParts.AddRange(chooseOperatingSystem(operatingSystemOptions, operatingSystemPrices));
            cartTotal = AddToTotal(cartTotal, Convert.ToDouble(computerParts[11]));

            computerParts.Add(cartTotal.ToString());

            ViewOrder(computerParts, true);

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
                Console.WriteLine("Processor:        " + computerParts[0] + "              $" + computerParts[1]);
                Console.WriteLine("Memory:           " + computerParts[2] + "              $" + computerParts[3]);
                Console.WriteLine("Primary Storage:  " + computerParts[4] + "              $" + computerParts[5]);
                Console.WriteLine("Secondary Storage:" + computerParts[6] + "              $" + computerParts[7]);
                Console.WriteLine("Graphics Card:    " + computerParts[8] + "              $" + computerParts[9]);
                Console.WriteLine("Operating System: " + computerParts[10] + "              $" + computerParts[11]);
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Total:                         $" + computerParts.Last());
            } else
            {
                Console.WriteLine();
                Console.WriteLine("No Order.");
            }
        }
        
        static List<String> ModifyOrder (List<String> computerParts, Boolean hasMadeOrder, String[] processors, double[] processorPrices,
                                         String[] memory, double[] memoryPrices, String[] primaryMemoryOptions, double[] primaryMemoryPrices,
                                         String[] secondaryMemoryOptions, double[] secondaryMemoryPrices, String[] graphicsCardOptions, 
                                         double[] graphicsCardPrices, String[] operatingSystemOptions, double[] operatingSystemPrices)
        {
            String menuOption; 
            List<String> processorInfo = new List<String>();
            List<String> memoryInfo = new List<String>();
            List<String> primaryStorageInfo = new List<String>();
            List<String> secondaryStorageInfo = new List<String>();
            List<String> graphicsCardInfo = new List<String>();
            List<String> operatingSystemInfo = new List<String>();
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
                    Console.WriteLine("3) Modify Primary Memory");
                    Console.WriteLine("4) Modify Secondary Memory");
                    Console.WriteLine("5) Modify Graphics Gard");
                    Console.WriteLine("6) Modify Operating System");
                    Console.WriteLine("7) Return to Menu");

                    //DisplayMenuOptions(cartTotal);
                    menuOption = Console.ReadLine();
                    if (menuOption != "1" && menuOption != "2" && menuOption != "3" && menuOption != "4" && menuOption != "5" && menuOption != "6"
                        && menuOption != "7")
                    {
                        Console.WriteLine("Error: Invalid Input");
                    } 
                } while (menuOption != "1" && menuOption != "2" && menuOption != "3" && menuOption != "4" && menuOption != "5" && menuOption != "6"
                         && menuOption != "7");

                if (menuOption == "1")
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter New Processor:");
                    processorInfo = ChooseProcessor(processors, processorPrices);
                    computerParts[0] = processorInfo[0];
                    cartTotal = cartTotal - Convert.ToDouble(computerParts[1]);
                    computerParts[1] = processorInfo[1];
                    cartTotal = AddToTotal(cartTotal, Convert.ToDouble(computerParts[1]));
                } else if (menuOption == "2")
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter New Memory:");
                    memoryInfo = ChooseMemory(memory, memoryPrices);
                    computerParts[2] = memoryInfo[0];
                    cartTotal = cartTotal - Convert.ToDouble(computerParts[3]);
                    computerParts[3] = memoryInfo[1];
                    cartTotal = AddToTotal(cartTotal, Convert.ToDouble(computerParts[3]));
                } else if (menuOption == "3")
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter New Primary Storage:");
                    primaryStorageInfo = choosePrimaryStroage(primaryMemoryOptions, primaryMemoryPrices);
                    computerParts[4] = primaryStorageInfo[0];
                    cartTotal = cartTotal - Convert.ToDouble(computerParts[5]);
                    computerParts[5] = primaryStorageInfo[1];
                    cartTotal = AddToTotal(cartTotal, Convert.ToDouble(computerParts[5]));
                } else if (menuOption == "4")
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter New Secondary Storage:");
                    secondaryStorageInfo = chooseSecondaryStroage(secondaryMemoryOptions, secondaryMemoryPrices);
                    computerParts[6] = secondaryStorageInfo[0];
                    cartTotal = cartTotal - Convert.ToDouble(computerParts[7]);
                    computerParts[7] = secondaryStorageInfo[1];
                    cartTotal = AddToTotal(cartTotal, Convert.ToDouble(computerParts[7]));
                } else if (menuOption == "5")
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter New Graphics Card:");
                    graphicsCardInfo = chooseGraphicsCard(graphicsCardOptions, graphicsCardPrices);
                    computerParts[8] = graphicsCardInfo[0];
                    cartTotal = cartTotal - Convert.ToDouble(computerParts[9]);
                    computerParts[9] = graphicsCardInfo[1];
                    cartTotal = AddToTotal(cartTotal, Convert.ToDouble(computerParts[9]));
                } else if (menuOption == "6")
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter New Operating System:");
                    operatingSystemInfo = chooseOperatingSystem(operatingSystemOptions, operatingSystemPrices);
                    computerParts[10] = operatingSystemInfo[0];
                    cartTotal = cartTotal - Convert.ToDouble(computerParts[11]);
                    computerParts[11] = operatingSystemInfo[1];
                    cartTotal = AddToTotal(cartTotal, Convert.ToDouble(computerParts[11]));
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

        static List<String> choosePrimaryStroage(String[] primaryStorageOptions, double[] primaryStoragePrices)
        {
            List<String> primaryStorageInfo = new List<String>();

            String chosenPrimaryStorage = "";
            double primaryStoragePrice = 0;
            Boolean isPrimaryStorageValid = false;

            Console.WriteLine("{0,-20} {1,5}\n", "Primary Storage", "Price");

            for (int currentOption = 0; currentOption < primaryStorageOptions.Length; currentOption++)
            {
                Console.WriteLine("{0,-20} {1,5:N1}", primaryStorageOptions[currentOption], primaryStoragePrices[currentOption]);
            }

            do
            {
                Console.WriteLine("Select a primary storage option:");
                chosenPrimaryStorage = Console.ReadLine();

                for (int currentOption = 0; currentOption < primaryStorageOptions.Length; currentOption++)
                {
                    if (chosenPrimaryStorage.Equals(primaryStorageOptions[currentOption]))
                    {
                        primaryStorageInfo.Add(chosenPrimaryStorage);
                        primaryStoragePrice = primaryStoragePrices[currentOption];
                        primaryStorageInfo.Add(primaryStoragePrice.ToString());
                        //cartTotal = AddToTotal(cartTotal,processorPrices[currProcessor]);
                        isPrimaryStorageValid = true;
                    }
                }

                if (isPrimaryStorageValid == false)
                {
                    Console.WriteLine("Invalid Input. Try again.");
                    Console.WriteLine();
                }
            } while (isPrimaryStorageValid == false);

            return primaryStorageInfo;
        }

        static List<String> chooseSecondaryStroage (String[] secondaryStorageOptions, double[] secondaryStoragePrices)
        {
            List<String> secondaryStroageInfo = new List<String>();

            String chosenSecondaryStorage = "";
            double secondaryStoragePrice = 0;
            Boolean isSecondaryStorageValid = false;

            Console.WriteLine("{0,-20} {1,5}\n", "Secondary Storage", "Price");

            for (int currentOption = 0; currentOption < secondaryStorageOptions.Length; currentOption++)
            {
                Console.WriteLine("{0,-20} {1,5:N1}", secondaryStorageOptions[currentOption], secondaryStoragePrices[currentOption]);
            }

            do
            {
                Console.WriteLine("Select a secondary storage option:");
                chosenSecondaryStorage = Console.ReadLine();

                for (int currentOption = 0; currentOption < secondaryStorageOptions.Length; currentOption++)
                {
                    if (chosenSecondaryStorage.Equals(secondaryStorageOptions[currentOption]))
                    {
                        secondaryStroageInfo.Add(chosenSecondaryStorage);
                        secondaryStoragePrice = secondaryStoragePrices[currentOption];
                        secondaryStroageInfo.Add(secondaryStoragePrice.ToString());
                        //cartTotal = AddToTotal(cartTotal,processorPrices[currProcessor]);
                        isSecondaryStorageValid = true;
                    }
                }

                if (isSecondaryStorageValid == false)
                {
                    Console.WriteLine("Invalid Input. Try again.");
                    Console.WriteLine();
                }
            } while (isSecondaryStorageValid == false);

            return secondaryStroageInfo;
        }

        static List<String> chooseGraphicsCard (String[] graphicsCardOptions, double[] graphicsCardPrices)
        {
            List<String> graphicsCardInfo = new List<String>();

            String chosenGraphicsCard = "";
            double graphicsCardPrice = 0;
            Boolean isGraphicsCardValid = false;

            Console.WriteLine("{0,-20} {1,5}\n", "Graphics Card", "Price");

            for (int currentOption = 0; currentOption < graphicsCardOptions.Length; currentOption++)
            {
                Console.WriteLine("{0,-20} {1,5:N1}", graphicsCardOptions[currentOption], graphicsCardPrices[currentOption]);
            }

            do
            {
                Console.WriteLine("Select a graphics card:");
                chosenGraphicsCard = Console.ReadLine();

                for (int currentOption = 0; currentOption < graphicsCardOptions.Length; currentOption++)
                {
                    if (chosenGraphicsCard.Equals(graphicsCardOptions[currentOption]))
                    {
                        graphicsCardInfo.Add(chosenGraphicsCard);
                        graphicsCardPrice = graphicsCardPrices[currentOption];
                        graphicsCardInfo.Add(graphicsCardPrice.ToString());
                        //cartTotal = AddToTotal(cartTotal,processorPrices[currProcessor]);
                        isGraphicsCardValid = true;
                    }
                }

                if (isGraphicsCardValid == false)
                {
                    Console.WriteLine("Invalid Input. Try again.");
                    Console.WriteLine();
                }
            } while (isGraphicsCardValid == false);

            return graphicsCardInfo;
        }

        static List<String> chooseOperatingSystem (String[] operatingSystemOptions, double[] operatingSystemPrices)
        {
            List<String> operatingSystemInfo = new List<String>();

            String chosenOperatingSytem = "";
            double operatingSystemPrice = 0;
            Boolean isOperatingSystemValid = false;

            Console.WriteLine("{0,-20} {1,5}\n", "Operating System", "Price");

            for (int currentOption = 0; currentOption < operatingSystemOptions.Length; currentOption++)
            {
                Console.WriteLine("{0,-20} {1,5:N1}", operatingSystemOptions[currentOption], operatingSystemPrices[currentOption]);
            }

            do
            {
                Console.WriteLine("Select an Operating System:");
                chosenOperatingSytem = Console.ReadLine();

                for (int currentOption = 0; currentOption < operatingSystemOptions.Length; currentOption++)
                {
                    if (chosenOperatingSytem.Equals(operatingSystemOptions[currentOption]))
                    {
                        operatingSystemInfo.Add(chosenOperatingSytem);
                        operatingSystemPrice = operatingSystemPrices[currentOption];
                        operatingSystemInfo.Add(operatingSystemPrice.ToString());
                        //cartTotal = AddToTotal(cartTotal,processorPrices[currProcessor]);
                        isOperatingSystemValid = true;
                    }
                }

                if (isOperatingSystemValid == false)
                {
                    Console.WriteLine("Invalid Input. Try again.");
                    Console.WriteLine();
                }
            } while (isOperatingSystemValid == false);

            return operatingSystemInfo;
        }
    }
}