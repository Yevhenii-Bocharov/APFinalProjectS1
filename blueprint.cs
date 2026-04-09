public class Room
{
    public int Id;
    public string Name = string.Empty;
    public string Description = string.Empty;
    public int[] avaliableRooms = Array.Empty<int>();
    public bool IsLocked = false;
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
            // MAIN ROOM
            new Room { Id = 0, Name = "Main Room", Description = "The central hub of the facility.", avaliableRooms=[1,4,5,6]}, 


            // BATHROOMS
            new Room { Id = 1, Name = "Bathroom Hallway", Description = "Leads to restrooms.",avaliableRooms=[0,2,3]
                 },

            new Room { Id = 2, Name = "Female Bathroom", Description = "Women's restroom.",avaliableRooms=[1]
                 },

            new Room { Id = 3, Name = "Male Bathroom", Description = "Men's restroom.",avaliableRooms=[1]
                 },


            // CELLS
            new Room { Id = 4, Name = "Cell Hallway", Description = "A narrow hall lined with holding cells.",
                avaliableRooms=[0,7,8,9] },
           
            new Room { Id = 7, Name = "Cell 1 (Top)", Description = "The first holding cell.",
                   avaliableRooms=[4]},
            
            new Room { Id = 8, Name = "Cell 2 (Middle)", Description = "The middle holding cell.",
                  avaliableRooms=[4] },
    
            new Room { Id = 9, Name = "Cell 3 (Bottom)", Description = "The lower holding cell.",
                avaliableRooms=[4] },


            // MAIN OFFICE
            new Room { Id = 5, Name = "Main Office", Description = "A locked administrative office.",
                avaliableRooms=[0,6], IsLocked=true },

           // CONFERENCE ROOM
            new Room { Id = 6, Name = "Conference Room", Description = "A room for meetings and briefings.",
                avaliableRooms=[0,5] },

        };
    }
}