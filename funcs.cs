using System;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
class Funcs
{
    // MOVING
    public void WhereAmI(Player player, Room[] Map)
{
    Console.Clear();
    Console.WriteLine("");

    foreach (var room in Map)
    {
        if (player.CurrentRoomId == room.Id)
        {
            Console.WriteLine($"You are in: {room.Name}");
            Console.WriteLine("");
            Console.WriteLine(room.Description);
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();                              
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
        Console.WriteLine("Type i to check inventory | Type quit to exit | Type findme to see your location :");
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
        //TO QUIT THE GAME!
         else if (input == "quit" || input == "exit")
        {
            Console.Clear();
            Console.WriteLine("Thanks for playing. Goodbye.");
            Environment.Exit(0);
        }
        //TO FIND THE USER 
        else if (input == "findme")
            {
                Console.Clear();
                Console.WriteLine($"You are in: {room.Name}");
                Console.WriteLine("");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                WhatCanIDo(player, room, Map);
            }

        else if (input.Length >= 1)
            {
                char command = input[0];
                int index = command - 'a';

                if (index < 0 || index >= room.ActionsArray.Length)
                {
                    Console.Clear();
                    Console.WriteLine("That action doesn't exist.");
                    Console.WriteLine("");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    WhatCanIDo(player, room, Map);
                    return;
                }

                DoAction(command, player, room, Map);
                WhatCanIDo(player, room, Map);
            }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid input.");
            WhatCanIDo(player, room, Map);
        }
    }

    public void DoAction(char command, Player player, Room room, Room[] Map)
    {
        int index = command - 'a';
        ActionOption action = room.ActionsArray[index];
        Console.Clear();
        Inspecting();
        Console.Clear();


        // CRAWL THROUGH CELL 3 SPECIAL CASE
        if (room.Id == 8 && action.Title == "Crawl Through Hole")
        {
            Console.Clear();
            Console.WriteLine("The concrete scrapes against your arms as you squeeze through. The space is suffocatingly tight.\nFor a moment, you feel stuck... then you push through and drop onto the other side.");
            foreach (var r in Map)
                if (r.Id == 9) r.IsLocked = false;
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            player.CurrentRoomId = 9;
            WhereAmI(player, Map);
            return;
        }

        // SAFE and ENDING SPECIAL CASE
        if (room.Id == 5 && action.Title == "Inspect Safe")
        {
            Console.WriteLine("A four-digit lock stares back at you.");
            Console.WriteLine("Enter the code:");
            Console.Write(">");
            string code = Console.ReadLine()!.Trim();

            if (code == "1548")
            {
                {
                    Console.Clear();
                    Console.WriteLine("The safe clicks open.");
                    Console.WriteLine("Inside, you find a loaded weapon.");
                    Console.WriteLine("You hold it in your hands. The cold metal feels heavy.");
                    Console.WriteLine("For the first time in days, you feel something.");
                    Console.WriteLine("");
                    Console.WriteLine("What do you do?");
                    Console.WriteLine("Press 1: End it. There's nothing left anyway.");
                    Console.WriteLine("Press 2: Not yet. Maybe you can hold to the solitude a little bit longer ");
                    Console.Write(">");
                    string ending = Console.ReadLine()!.Trim();

                    if (ending == "1")
                    {
                        Console.Clear();
                        Console.WriteLine("You close your eyes.");
                        Console.WriteLine("The silence was always going to win.");
                        Console.WriteLine("BANG.");
                        Console.WriteLine("");
                        Console.WriteLine("We understand. The world ended, and so did you.");
                        Console.WriteLine("\n--- THE END ---");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You lower the weapon.");
                        Console.WriteLine("Something falls from inside the safe — a folded note.");
                        Console.WriteLine("");
                        Console.WriteLine("You open it.");
                        Console.WriteLine("'Address of a civilian bunker — may be inhabited.'");
                        Console.WriteLine("");
                        Console.WriteLine("Your hands are shaking.");
                        Console.WriteLine("You are not the last one.");
                        Console.WriteLine("\n--- THE END ---");
                    }
                    Console.WriteLine("\nPress any key to exit...");
                    Console.ReadKey();
                    Environment.Exit(0);
                }

            }
            else
            {
                Console.WriteLine("The code does not match. Maybe I should look around more.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
            return;
        }

        // VENT SPECIAL CASE
        if (room.Id == 6 && action.Title == "Interact with Vent")
        {
            bool hasScrewdriver = Array.Exists(player.ItemArray, i => i?.ToLower() == "screwdriver");
            if (hasScrewdriver)
            {
                Console.WriteLine("You unscrew the cover. It drops with a loud clang.\nYou crawl into the darkness...");
                foreach (var r in Map)
                        if (r.Id == 5) r.IsLocked = false;                   
                         Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                player.CurrentRoomId = 5; 
                 WhereAmI(player, Map);
                return;
            }

            else
            {
                Console.WriteLine("The screws won't budge. You need a tool.");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine(action.Description);

        if (action.ItemArray.Length != 0)
        {
            foreach (var item in action.ItemArray)
            {
                AddItemToInventory(player, item);
            }
        }

        Console.WriteLine("");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public void Move(Player player, int roomId, Room[] Map)
{
    CheckItemUnlocks(player, Map);
    foreach (var room in Map)
    {
        if (room.Id == roomId) 
        {
            if (room.IsLocked)
            {
                Console.Clear();
                switch (room.Id)
                {
                    case 1:
                        Console.WriteLine("The hallway is pitch black. You can't see anything.\nYou need a light source to go further.");
                        break;
                    case 3:
                        Console.WriteLine("The room is completely dark. You can't see anything.\nYou need a light source.");
                        break;
                    case 5:
                        Console.WriteLine("The door to the Chief's Office is sealed shut.\nThere must be another way in.");
                        break;
                    case 6:
                        Console.WriteLine("The door is locked. You need a key to get in.");
                        break;
                    case 9:
                        Console.WriteLine("The cell is locked. There must be another way in.");
                        break;

   
                    default:
                        Console.WriteLine($"The {room.Name} is locked. You cannot enter.");
                        break;
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                WhereAmI(player, Map);
                return;
            }

            player.CurrentRoomId = roomId;
            Console.Clear();
            WhereAmI(player, Map);
            return;
        }
    }
    Console.WriteLine("There is no room in that way");
}


    // ITEM SYSTEM 
        public void AddItemToInventory(Player player, string item)
        {

            foreach (var i in player.ItemArray)
            {
                if (!string.IsNullOrEmpty(i) && i.ToLower() == item.ToLower())
                {
                    Console.WriteLine($"You already have the {item}.");
                    return;
                }
            }

            for (int i = 0; i < player.ItemArray.Length; i++)
            {
                if (string.IsNullOrEmpty(player.ItemArray[i]))
                {
                    player.ItemArray[i] = item;
                    Console.WriteLine($"Added {item} to inventory.");
                    return;
                }
            }

            
            Console.WriteLine("Your inventory is full. You can't carry anything else.");
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
        Console.WriteLine("");
        Console.WriteLine("Press any key to continue..."); 
        Console.ReadKey();

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
                        if (room.Id == 5) room.IsLocked = false;
                    break;

                case "keys":
                    foreach (var room in map)
                        if (room.Id == 6) room.IsLocked = false;
                    break;
            }
        }
    }


}
