using System;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
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
                WhatCanIDo(player, room, Map);
                return;
            }
        }
        Console.WriteLine("Error: Your current location doesn't exist on the map.");
    }



    public void WhatCanIDo(Player player, Room room, Room[] Map)
    {

        Console.WriteLine("");
        Console.WriteLine("From here, you can do:");

        for (int i = 0; i < room.ActionsArray.Length; i++)
        {
            Console.WriteLine($"Press {(char)('a' + i)} to: {room.ActionsArray[i].Title}");
        }

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
        InputByUser(player, Map, room);

    }


    public void InputByUser(Player player, Room[] Map, Room room)
    {
        Console.WriteLine("");
        Console.WriteLine("Choose an option: ");
        Console.WriteLine("Type i to check inventory:");
        Console.Write(">");
        string input = Console.ReadLine()!.ToLower()!;

        if (int.TryParse(input, out int number))
        {
            // numeric input (room index / movement)
            if (number < 0 || number >= room.avaliableRooms.Length)
            {
                Console.Clear();
                Console.WriteLine("That option doesn't exist.");
                WhatCanIDo(player, room, Map);
                return;
            }

            Move(player, room.avaliableRooms[number], Map);
        }
        else if (input == "i")
        {
            Look(player);
            WhatCanIDo(player, room, Map);
        }
        else if (input.Length >= 1)
        {
            // char input (like E, A, B, etc.)
            char command = input[0];

            DoAction(command, player, room);
            WhatCanIDo(player, room, Map);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid input.");
            WhatCanIDo(player, room, Map);
        }
    }

    public void DoAction(char command, Player player, Room room)
    {
        int index = command - 'a';
        ActionOption actionArray = room.ActionsArray[index];
        Console.WriteLine(actionArray.Description);
        if (actionArray.ItemArray.Length != 0)
        {
            foreach (var item in actionArray.ItemArray)
            {
                AddItemToInventory(player, item);
                return;
            }

        }
    }

    public void Move(Player player, int roomId, Room[] Map)
    {
        bool hasChanged = false;
        CheckItemUnlocks(player, Map);
        foreach (var room in Map)
        {
            if (room.Id == roomId)
            {
                if (room.IsLocked)
                {
                    Console.WriteLine($"You cannot enter here.");
                    WhereAmI(player, Map);
                    return;
                }
                player.CurrentRoomId = roomId;
                Console.Clear();
                hasChanged = true;
                WhereAmI(player, Map);
                return;
            }
        }
        if (hasChanged == false)
        {
            Console.WriteLine("There is no room in that way");

            return;
        }

    }


    // ITEM SYSTEM 

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


    //INVENTORY 
    public void Look(Player player)
    {
        Console.Clear();
        Inspecting();
        Console.WriteLine("Inventory:");

        string[] items = player.ItemArray;

        BubbleSort(items);

        bool hasItems = false;

        foreach (string item in items)
        {
            if (!string.IsNullOrEmpty(item))
            {
                Console.WriteLine("- " + item);
                hasItems = true;
            }
        }

        if (!hasItems)
        {
            Console.WriteLine("Your inventory is empty.");
        }
    }


    //BUBBLE SORT FOR INVENTORY 
    public void BubbleSort(string[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                if (string.Compare(array[j], array[j + 1]) > 0)
                {
                    string temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }
    public void Inspecting()
    {
        Console.Write("Inspecting");
        for (int i = 0; i < 3; i++)
        {
            Console.Write(".");
            Thread.Sleep(300);
        }
        Console.Clear();
    }

    public void CheckItemUnlocks(Player player, Room[] map)
    {
        foreach (string item in player.ItemArray)
        {
            if (string.IsNullOrEmpty(item)) continue;

            switch (item.ToLower())
            {
                case "flashlight":
                    foreach (var room in map)
                        if (room.Id == 1) room.IsLocked = false;
                    break;

                case "screwdriver":
                    foreach (var room in map)
                        if (room.Id == 6) room.IsLocked = false;
                    break;

                case "keys":
                    foreach (var room in map)
                        if (room.Id == 5) room.IsLocked = false;
                    break;
            }
        }
    }


}

