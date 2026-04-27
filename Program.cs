using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // Initialize the game components, player and prompt 
        Blueprint blueprint = new Blueprint();
        Funcs funcs = new Funcs();
        Player player = new Player
        {
            Name = "Patricia",
            CurrentRoomId = 0,
            ItemArray = new string[4]
        };
        Console.WriteLine("");
        Console.WriteLine("You are the last person alive after an atomic bomb killed all of humanity.");
        Console.WriteLine("After days of wandering through ruins and corpses in a smal town ,");
        Console.WriteLine("you finally reach a police station.");
        Console.WriteLine(" ");
        Console.WriteLine("This is your last hope of finding anything useful or meaningful in this empty world.");
        Console.WriteLine("");
        Console.WriteLine("COMMANDS:");
        Console.WriteLine("  i       -> Check inventory");
        Console.WriteLine("  findme  -> See where you are");
        Console.WriteLine("  quit    -> Exit the game");
        Console.WriteLine("");
        Console.WriteLine("Press Enter to start...");
        Console.ReadLine();
        Console.Clear();


        Console.WriteLine($"Created player: {player.Name}");
        funcs.WhereAmI(player, blueprint.Map);
    }
}