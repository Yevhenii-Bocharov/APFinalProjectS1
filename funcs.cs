using System;

class Funcs
{
    // Pass the Player and the Array of Rooms
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
        for (int i = 0; i < room.avaliableRooms.Length; i++)
        {
            foreach (var possibleRoom in Map)
            {
                if (room.avaliableRooms[i] == possibleRoom.Id)
                {
                    // Console.WriteLine($"You can go to: {possibleRoom.Name}");
                    Console.WriteLine($"Press {i} to go to: {possibleRoom.Name}");
                    break;
                }
            }

        }
        int userInput = int.Parse(Console.ReadLine()!);
        Move(player, room.avaliableRooms[userInput], Map);

    }

    public void Move(Player player, int roomId, Room[] Map)
    {
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
                WhereAmI(player, Map);

                return;
            }
        }

    }

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
}