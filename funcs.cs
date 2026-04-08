using System;

class Funcs
{
    // Pass the Player and the Array of Rooms
    public void WhereAmI(Player player, Room[] Map)
    {
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
        for (int i = 0; i < room.avaliableRooms.Length; i++)
        {
            foreach (var possibleRoom in Map)
            {
                if (room.avaliableRooms[i] == possibleRoom.Id)
                {
                    Console.WriteLine($"You can go to: {possibleRoom.Name}");
                    Console.WriteLine($"Press {i} to go to: {possibleRoom.Name}");
                    break;
                }
            }
        }
    }
}