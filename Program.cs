using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // Initialize the game components
        Blueprint blueprint = new Blueprint();
        Funcs funcs = new Funcs();
        Player player = new Player
        {
            Name = "Patricia",
            CurrentRoomId = 0,
            ItemArray = new string[4]
        };

        Console.WriteLine($"Created player: {player.Name}");
        funcs.WhereAmI(player, blueprint.Map);
    }
}