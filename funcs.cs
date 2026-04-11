using System;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;

class Funcs
{
    // MOVING
    public void WhereAmI(Player player, Room[] Map)
    {
        Console.WriteLine("");

        foreach (var room in Map)
        {
            if (player.CurrentRoomId == room.Id)
            {
                Console.WriteLine($"You are in: {room.Name}");
                Console.WriteLine(room.Description);
                WhereCanIGo(player, room, Map);
                return;
            }
        }
        Console.WriteLine("Error: Your current location doesn't exist on the map.");
    }



public void WhereCanIGo(Player player, Room room, Room[] Map)
{
    Console.WriteLine("");
    Console.WriteLine("From here, you can go to:");

    int optionCount = 0;

    for (int i = 0; i < room.avaliableRooms.Length; i++)
    {
        foreach (var possibleRoom in Map)
        {
            if (room.avaliableRooms[i] == possibleRoom.Id)
            {
                Console.WriteLine($"Press {optionCount} to go to: {possibleRoom.Name}");
                optionCount++;
                break;
            }
        }
    }

    Console.WriteLine("Choose an option: ");
    Console.Write(">");
    int userInput;

    if (!int.TryParse(Console.ReadLine(), out userInput))
    {
        Console.Clear();
        Console.WriteLine("Invalid input.");
        WhereCanIGo(player,room,Map);
        return;
    }

    if (userInput < 0 || userInput >= room.avaliableRooms.Length)
    {
        Console.Clear();
        Console.WriteLine("That option doesn't exist.");
        WhereCanIGo(player,room,Map);
        return;
    }

    Move(player, room.avaliableRooms[userInput], Map);
}


    public void Move(Player player, int roomId, Room[] Map)
    {
        bool hasChanged = false;
        foreach (var room in Map)
        {
            if (room.Id == roomId)
            {
                if (room.IsLocked)
                {
                    Console.WriteLine($"The {room.Name} is locked. You cannot enter.");
                    WhereAmI(player, Map);
                    return;
                }
                player.CurrentRoomId = roomId;
                Console.Clear();
                hasChanged=true;
                WhereAmI(player, Map);
                return;
            }
        }
        if (hasChanged==false)
        {
            Console.WriteLine("There is no room in that way");
                
            return;
        }

    }


// ITEM ARRAY 

    public void AddItemToInventory(Player player, string item)
    {
        for (int i = 0; i < player.ItemArray.Length; i++)
        {
            if (string.IsNullOrEmpty(player.ItemArray[i]))
            {
                player.ItemArray[i] = item;
                Console.WriteLine($"Added {item} to inventory.");
                return;
            }
        }
        Console.WriteLine("Current Inventory:");
        foreach (var inventoryItem in player.ItemArray)
        {
            if (!string.IsNullOrEmpty(inventoryItem))
            {
                Console.WriteLine($"- {inventoryItem}");
            }
        }
    }

    




    public void Inspecting()
    {
        Console.Write("Inspecting");
        for (int i = 0; i < 3; i++)
        {
            Console.Write(".");
            Thread.Sleep(500);
        }
    }
    //i guant to kill myself
}