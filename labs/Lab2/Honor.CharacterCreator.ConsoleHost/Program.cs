// See https://aka.ms/new-console-template for more information

/*
 * ITSE 1430 Sample Implementation
 * Computer Builder
 */

DisplayProgramInformation();

var done = false;
do
{
    switch (DisplayMenu())
    {
        //case MenuOption.NewOrder: HandleNewOrder(); break;
        //case MenuOption.ViewOrder: HandleViewOrder(); break;
        //case MenuOption.ClearOrder: HandleClearOrder(); break;
        //case MenuOption.ModifyOrder: HandleModifyOrder(); break;

        case MenuOption.Quit: done = HandleQuit(); break;
    };
} while (!done);

#region Helper Functions 

/// <summary>Displays program information.</summary>
void DisplayProgramInformation ()
{
    Console.WriteLine("Lab 2 - Character Creator");
    Console.WriteLine("ITSE 1430");
    Console.WriteLine("Honor McClung");
    DrawLine(40);

    Console.WriteLine();
}

MenuOption DisplayMenu ()
{
    Console.WriteLine();

    //var price = CalculatePrice();
    //DrawHeader($"Main Menu [Cart Total: {price:C}]");

    //Console.WriteLine("N)ew Order");
    //Console.WriteLine("M)odify Order");
    //Console.WriteLine("V)iew Order");
    //Console.WriteLine("C)lear Order");
    Console.WriteLine("Q)uit");

    switch (GetKeyInput(ConsoleKey.Q/*, ConsoleKey.N, ConsoleKey.V, ConsoleKey.M, ConsoleKey.C*/))
    {
        //case ConsoleKey.N: return MenuOption.NewOrder;
        //case ConsoleKey.V: return MenuOption.ViewOrder;
        //case ConsoleKey.C: return MenuOption.ClearOrder;
        //case ConsoleKey.M: return MenuOption.ModifyOrder;

        case ConsoleKey.Q: return MenuOption.Quit;
    };

    return 0;
}
#endregion

#region General Purpose Functions 

/// <summary>Draws a line.</summary>
/// <param name="width">The desired width.</param>
void DrawLine ( int width )
{
    Console.WriteLine("".PadLeft(width, '-'));
}

/// <summary>Prompts for a single, valid key.</summary>
/// <param name="validKeys">The list of valid keys.</param>
/// <returns>The entered key.</returns>
ConsoleKey GetKeyInput ( params ConsoleKey[] validKeys )
{
    do
    {
        var key = Console.ReadKey(true);
        if (validKeys.Contains(key.Key))
        {
            Console.WriteLine();
            return key.Key;
        } else
        {
            Console.WriteLine("Error: Invalid input. Try again.");
        }
    } while (true);
}

/// <summary>Displays a confirmation message and waits for a valid response.</summary>
/// <param name="message">The message to display.</param>
/// <returns><see langword="true"/> if confirmed.</returns>
bool Confirm ( string message )
{
    Console.WriteLine(message);

    return GetKeyInput(ConsoleKey.Y, ConsoleKey.N) == ConsoleKey.Y;
}
#endregion

#region Command Functions

/// <summary>Handles the Quit command.</summary>
bool HandleQuit ()
{
    if (Confirm("Are you sure you want to quit (Y/N)? "))
        return true;

    return false;
}
#endregion





