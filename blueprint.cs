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
                Description = "You've entered the Main Hall of the police station. The place is filled with dust and dirt.\nThere is an old carpet underneath you, an old secretary desk, two halls at the back, and two doors on your left.",
                avaliableRooms = [1,4,5,6],
                ActionsArray = new ActionOption[]
                {
                    new ActionOption
                    {
                        Title = "Inspect Front Desk",
<<<<<<< HEAD
                        Description = "The desk is covered in a pile of old papers.\nYou find an attendance book, a magazine, and a useless computer.",
=======
                        Description = "Search the old reception desk.",
>>>>>>> feature/quit-findme
                    }
                }
            },

            // BATHROOM HALLWAY
            new Room
            {
                Id = 1,
                Name = "Bathroom Hallway",
                Description = "You step into a narrow hallway that splits into two sections. The air feels heavy,\nand the floor slopes slightly beneath your feet. The space branches into two areas:\nthe men's restroom and the women's restroom.",
                avaliableRooms = [0,2,3],
                IsLocked = true,
                ActionsArray = new ActionOption[] { }
            },

            // WOMEN'S BATHROOM
            new Room
            {
                Id = 2,
                Name = "Female Bathroom",
                Description = "You enter a surprisingly well-maintained restroom. Despite a few cracked tiles,\neverything looks relatively clean and undisturbed.\nOne of the sinks appears to be under repair, with a toolbox sitting beside it.",
                avaliableRooms = [1],
                ActionsArray = new ActionOption[]
                {
                    new ActionOption
                    {
                        Title = "Inspect Toolbox",
                        Description = "You open the toolbox and rummage through its contents. Most of the tools are either missing or useless.\nOne item catches your attention — a yellow screwdriver. It's old and rusty, but still usable.\nYou take the screwdriver.",
                        ItemArray = new string[] { "screwdriver" }
                    }
                }
            },

            // MEN'S BATHROOM
            new Room
            {
                Id = 3,
                Name = "Male Bathroom",
                Description = "The room is completely dark. You can't see anything.",
                avaliableRooms = [1],
                IsLocked = true,
                ActionsArray = new ActionOption[]
                {
<<<<<<< HEAD
                    new ActionOption
                    {
                        Title = "Inspect Stalls",
                        Description = "The walls are covered in random graffiti, scratches, and faded markings.\nSome of it is just names, symbols, or unfinished thoughts.\nYou can make out fragments:\n\"don't look back\", \"it's still here\", \"1548\", \"help\"\nAll of it seems meaningless."
                    }
=======
                    new ActionOption { Title = "Inspect Stalls", Description = "Look around the stalls." }
>>>>>>> feature/quit-findme
                }
            },

            // CELL HALLWAY
            new Room
            {
                Id = 4,
                Name = "Cell Hallway",
                Description = "A long, narrow hallway stretches into darkness. Three cells line the right side.\nThe air is heavy, and every sound echoes too loudly.",
                avaliableRooms = [0,7,8,9],
                ActionsArray = new ActionOption[] { }
            },

            // CELL 1
            new Room
            {
                Id = 7,
                Name = "Cell 1 (Top)",
                Description = "The air is thick and damp. A weak yellow bulb flickers above, barely lighting the cracked concrete walls.\nThe bed frame is intact, but the mattress is stained beyond recognition.\nScratch marks cover the walls — some deep, like someone tried to claw their way out.",
                avaliableRooms = [4],
                ActionsArray = new ActionOption[]
                {
<<<<<<< HEAD
                    new ActionOption
                    {
                        Title = "Inspect Bed",
                        Description = "The mattress collapses under your touch. Nothing useful."
                    },
                    new ActionOption
                    {
                        Title = "Inspect Walls",
                        Description = "The scratches feel recent... but that doesn't make sense."
                    }
=======
                    new ActionOption { Title = "Inspect Bed", Description = "Search the mattress." },
                    new ActionOption { Title = "Inspect Walls", Description = "Look at the scratch marks." }
>>>>>>> feature/quit-findme
                }
            },

            // CELL 2
            new Room
            {
                Id = 8,
                Name = "Cell 2 (Middle)",
                Description = "Water drips steadily from the ceiling, forming a shallow pool on the floor.\nThe bed is bent and rusted. On the far wall, there's a cracked opening — a rough hole leading into the next cell.\nIt's tight... but passable.",
                avaliableRooms = [4],
                ActionsArray = new ActionOption[]
                {
<<<<<<< HEAD
                    new ActionOption
                    {
                        Title = "Inspect Leak",
                        Description = "Just dirty water. Something shifts for a second... then stops."
                    },
                    new ActionOption
                    {
                        Title = "Crawl Through Hole",
                        Description = "The concrete scrapes against your arms as you squeeze through. The space is suffocatingly tight.\nFor a moment, you feel stuck... then you push through and drop onto the other side."
                    }
=======
                    new ActionOption { Title = "Inspect Leak", Description = "Check the dripping water." },
                    new ActionOption { Title = "Crawl Through Hole", Description = "Pass into the next cell." }
>>>>>>> feature/quit-findme
                }
            },

            // CELL 3
            new Room
            {
                Id = 9,
                Name = "Cell 3 (Bottom)",
                Description = "The smell hits instantly — thick, sour, and rotting. It clings to the back of your throat.\nA dead police officer lies sprawled on the bed. His uniform is stiff and darkened with old, dried fluids.\nParts of his skin have turned gray-green, stretched tight in some places and split open in others.\nFlies crawl in and out of the exposed flesh, and clusters of pale maggots writhe slowly along his neck and under his collar.",
                avaliableRooms = [4],
                ActionsArray = new ActionOption[]
                {
                    new ActionOption
                    {
                        Title = "Check Body",
                        Description = "You search the pockets and find a Keychain.\nA metal ring with one key and a cute cat charm.",
                        ItemArray = new string[] { "Keys" }
                    },
<<<<<<< HEAD
                    new ActionOption
                    {
                        Title = "Move Body",
                        Description = "The corpse shifts too easily. The skin pulls slightly as it moves.\nAnd worms crawl around."
                    }
=======
                    new ActionOption { Title = "Move Body", Description = "Inspect the body closely." }
>>>>>>> feature/quit-findme
                }
            },

            // CONFERENCE ROOM
            new Room
            {
                Id = 6,
                Name = "Conference Room",
                Description = "A long table fills the room, surrounded by chairs left in disorder — some tipped over, others pushed back in a hurry.\nThe lights flicker unevenly, casting moving shadows across the walls.\nA dusty whiteboard stands at the front, its writing smeared and unreadable.\nOn the table sits a Flashlight. The beam flickers, but it works.\nA metal vent is set into the wall nearby, its cover still screwed in.",
                avaliableRooms = [0],
                ActionsArray = new ActionOption[]
                {
                    new ActionOption
                    {
                        Title = "Take Flashlight",
<<<<<<< HEAD
                        Description = "You pick it up. Weak, but usable.",
                        ItemArray = new string[] { "Flashlight" }
                    },
                    new ActionOption
                    {
                        Title = "Inspect Whiteboard",
                        Description = "Old notes... nothing useful."
                    },
                    new ActionOption
                    {
                        Title = "Interact with Vent",
                        Description = "The screws won't budge. You need a tool."
                    }
=======
                        Description = "Pick up the flashlight.",
                        ItemArray = new string[] { "Flashlight" }
                    },
                    new ActionOption { Title = "Inspect Whiteboard", Description = "Examine the faded notes." },
                    new ActionOption { Title = "Interact with Vent", Description = "Check the vent on the wall." }
>>>>>>> feature/quit-findme
                }
            },

            // CHIEF OFFICE
            new Room
            {
                Id = 5,
                Name = "Chief's Office",
<<<<<<< HEAD
                Description = "You used the screwdriver to unscrew the vent and crawled into the darkness.\nThe door is blocked by debris, but a huge hole in the ceiling lets in natural light.\nInside, a desk is buried under files. Behind the desk sits a Safe with a four-digit lock.",
                avaliableRooms = [6],
                IsLocked = true,
                ActionsArray = new ActionOption[]
                {
                    new ActionOption
                    {
                        Title = "Inspect Safe",
                        Description = "A four-digit lock stares back at you. You'll need the right code."
                    }
=======
                Description = "A locked administrative office.",
                avaliableRooms = [0,6],
                IsLocked = true,
                ActionsArray = new ActionOption[]
                {
                    new ActionOption { Title = "Inspect Safe", Description = "Try opening the locked safe." }
>>>>>>> feature/quit-findme
                }
            }
        };
    }
}