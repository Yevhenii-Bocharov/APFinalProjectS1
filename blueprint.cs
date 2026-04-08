public class Room
{
    public int Id;
    public string Name = string.Empty;
    public string Description = string.Empty;
    public int[] avaliableRooms = Array.Empty<int>();
    // public int North;
    // public int South;
    // public int East;
    // public int West;
}

public class Blueprint
{
    public Room[] Map;

    public Blueprint()
    {
        Map = new Room[]
        {

            new Room { Id = 0, Name = "Main Room", Description = "The central hub of the facility.", avaliableRooms=[1,4,5,6]}, 
// North = 0, South = 0, East = 0, West = 0,



            // BATHROOMS
            new Room { Id = 1, Name = "Bathroom Hallway", Description = "Leads to restrooms.",avaliableRooms=[0,2,3]
                 },
// North = 1, South = -1, East = 0, West = 0
              // 2 - FEMALE BATHROOM (Bottom Right)
            new Room { Id = 2, Name = "Female Bathroom", Description = "Women's restroom.",avaliableRooms=[1]
                 },
// North = 1, South = -1, East = 1, West = -1
            // 3 - MALE BATHROOM (Top Right)
            new Room { Id = 3, Name = "Male Bathroom", Description = "Men's restroom.",avaliableRooms=[1]
                 },
// North = 2, South = -2, East = 1, West = -1



            // CELLS
            new Room { Id = 4, Name = "Cell Hallway", Description = "A narrow hall lined with holding cells.",
                avaliableRooms=[0,7,8,9] },
// North = 1, South = -1, East = -1, West = 2
            
            new Room { Id = 7, Name = "Cell 1", Description = "The first holding cell.",
                   avaliableRooms=[4]},
// North = 3, South = -3, East = 1, West = -1
            
            new Room { Id = 8, Name = "Cell 3 (Middle)", Description = "The middle holding cell.",
                  avaliableRooms=[4] },
// North = 2, South = -2, East = 1, West = -1
            
            new Room { Id = 9, Name = "Cell 3 (Bottom)", Description = "The lower holding cell.",
                avaliableRooms=[4] },
// North = 1, South = -1, East = 1, West = -1


            // MAIN OFFICE
            new Room { Id = 5, Name = "Main Office", Description = "A locked administrative office.",
                avaliableRooms=[0,6] },
// North = 1, South = -1, East = 3, West = -3

            // CONFERENCE ROOM
            new Room { Id = 6, Name = "Conference Room", Description = "A room for meetings and briefings.",
                avaliableRooms=[0,5] },
//  North = 0, South = 0, East = -3, West = -3
        };
    }
}