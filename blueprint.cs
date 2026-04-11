public class Room
{
    public int Id;
    public string Name = string.Empty;
    public string Description = string.Empty;
    public int[] avaliableRooms = Array.Empty<int>();
    public bool IsLocked = false;

    public ActionOption[] ActionsArray = Array.Empty<ActionOption>();
}

public class ActionOption
{
    public string Title = string.Empty;
    public string Description = string.Empty;
    public string[] ItemArray = Array.Empty<string>();
}


public class Blueprint
{
    public Room[] Map;

    public Blueprint()
    {
        Map = new Room[]
        {
            // MAIN ROOM
            new Room
            {
                Id = 0,
                Name = "Main Room",
                Description = "The central hub of the facility.",
                avaliableRooms = [1,4,5,6],
                ActionsArray = new ActionOption[]
                {
                    new ActionOption
                    {
                        Title = "Inspect Front Desk",
                        Description = "Search the old reception desk.",
                        ItemArray = new string[] { }
                    },
                    new ActionOption
                    {
                        Title = "Go to Bathroom Hallway",
                        Description = "Enter the bathroom section."
                    },
                    new ActionOption
                    {
                        Title = "Go to Cell Hallway",
                        Description = "Walk toward the prison cells."
                    },
                    new ActionOption
                    {
                        Title = "Go to Chief’s Office",
                        Description = "Try accessing the locked office."
                    },
                    new ActionOption
                    {
                        Title = "Go to Conference Room",
                        Description = "Enter the meeting room."
                    }
                }
            },

            // BATHROOM HALLWAY
            new Room
            {
                Id = 1,
                Name = "Bathroom Hallway",
                Description = "Leads to restrooms.",
                avaliableRooms = [0,2,3],
                ActionsArray = new ActionOption[]
                {
                    new ActionOption { Title = "Return to Main Room", Description = "Go back to the main hall." },
                    new ActionOption { Title = "Go to Men's Bathroom", Description = "Enter the men's restroom." },
                    new ActionOption { Title = "Go to Women's Bathroom", Description = "Enter the women's restroom." }
                }
            },

            // WOMEN'S BATHROOM
            new Room
            {
                Id = 2,
                Name = "Female Bathroom",
                Description = "Women's restroom.",
                avaliableRooms = [1],
                ActionsArray = new ActionOption[]
                {
                    new ActionOption
                    {
                        Title = "Inspect Toolbox",
                        Description = "Search the toolbox beside the sink.",
                        ItemArray = new string[] { "screwdriver" }
                    },
                    new ActionOption
                    {
                        Title = "Leave Bathroom",
                        Description = "Return to the hallway."
                    }
                }
            },

            // MEN'S BATHROOM
            new Room
            {
                Id = 3,
                Name = "Male Bathroom",
                Description = "Men's restroom.",
                avaliableRooms = [1],
                ActionsArray = new ActionOption[]
                {
                    new ActionOption { Title = "Use Flashlight", Description = "Light up the dark room." },
                    new ActionOption { Title = "Inspect Stalls", Description = "Look around the stalls." },
                    new ActionOption { Title = "Return to Hallway", Description = "Leave the restroom." }
                }
            },

            // CELL HALLWAY
            new Room
            {
                Id = 4,
                Name = "Cell Hallway",
                Description = "A narrow hall lined with holding cells.",
                avaliableRooms = [0,7,8,9],
                ActionsArray = new ActionOption[]
                {
                    new ActionOption { Title = "Enter Cell 1", Description = "Inspect the first cell." },
                    new ActionOption { Title = "Enter Cell 2", Description = "Inspect the second cell." },
                    new ActionOption { Title = "Enter Cell 3", Description = "Inspect the third cell." },
                    new ActionOption { Title = "Return to Main Room", Description = "Go back to the main hall." }
                }
            },

            // CELL 1
            new Room
            {
                Id = 7,
                Name = "Cell 1 (Top)",
                Description = "The first holding cell.",
                avaliableRooms = [4],
                ActionsArray = new ActionOption[]
                {
                    new ActionOption { Title = "Inspect Bed", Description = "Search the mattress." },
                    new ActionOption { Title = "Inspect Walls", Description = "Look at the scratch marks." },
                    new ActionOption { Title = "Exit Cell", Description = "Return to hallway." }
                }
            },

            // CELL 2
            new Room
            {
                Id = 8,
                Name = "Cell 2 (Middle)",
                Description = "The middle holding cell.",
                avaliableRooms = [4],
                ActionsArray = new ActionOption[]
                {
                    new ActionOption { Title = "Inspect Leak", Description = "Check the dripping water." },
                    new ActionOption { Title = "Crawl Through Hole", Description = "Pass into the next cell." },
                    new ActionOption { Title = "Exit Cell", Description = "Return to hallway." }
                }
            },

            // CELL 3
            new Room
            {
                Id = 9,
                Name = "Cell 3 (Bottom)",
                Description = "The lower holding cell.",
                avaliableRooms = [4],
                ActionsArray = new ActionOption[]
                {
                    new ActionOption
                    {
                        Title = "Check Body",
                        Description = "Search the corpse.",
                        ItemArray = new string[] { "Keys" }
                    },
                    new ActionOption { Title = "Move Body", Description = "Inspect the body closely." },
                    new ActionOption { Title = "Return Through Hole", Description = "Go back to Cell 2." }
                }
            },

            // CONFERENCE ROOM
            new Room
            {
                Id = 6,
                Name = "Conference Room",
                Description = "A room for meetings and briefings.",
                avaliableRooms = [0,5],
                ActionsArray = new ActionOption[]
                {
                    new ActionOption
                    {
                        Title = "Take Flashlight",
                        Description = "Pick up the flashlight."
                    },
                    new ActionOption { Title = "Inspect Whiteboard", Description = "Examine the faded notes." },
                    new ActionOption { Title = "Interact with Vent", Description = "Check the vent on the wall." },
                    new ActionOption { Title = "Return to Main Room", Description = "Leave the conference room." }
                }
            },

            // CHIEF OFFICE
            new Room
            {
                Id = 5,
                Name = "Chief’s Office",
                Description = "A locked administrative office.",
                avaliableRooms = [0,6],
                IsLocked = true,
                ActionsArray = new ActionOption[]
                {
                    new ActionOption { Title = "Inspect Safe", Description = "Try opening the locked safe." },
                    new ActionOption { Title = "Return to Conference Room", Description = "Leave the office." }
                }
            }
        };
    }
}