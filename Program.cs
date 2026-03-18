Rooms Room0 = new Rooms { Name = "Kitchen", Description = "Wasd", North = -1, South = 2, East = -1, West = -1 };

Rooms Room1 = new Rooms { Name = "Small Bedroom", Description = "Wasd", North= 1, South = 2, West = 3, East = 4 };
Rooms Room2 = new Rooms { Name = "Main Hallway", Description = "Wasd", North = 1, South = 2, West = 3, East = 4 };
Rooms Room3 = new Rooms { Name = "Foyer", Description = "Wasd", North = 1, South = 2, West = 3, East = 4 };
Rooms Room4 = new Rooms { Name = "Living Room", Description = "Wasd" , North = 1, South = 2, West = 3, East = 4};

Rooms[] Map = { Room0, Room1, Room2, Room3, Room4 };

class Player
{
    string PlayersName;
    class PlayerPosition
    {

    }

    class PlayerKey
    {

    }

}

class GameStart
{

}

struct Rooms
{
    public string Name, Description;
    public int North, South, East, West;
}