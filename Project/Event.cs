using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Event
    {
        public string Name { get; set; }

        public bool Events { get; set; }


        public Event(string name, bool events)
        {
            Name = name;
            Events = events;
            // Item pipboy = allItems[0];
            // Item pistol = allItems[1];
        }

        public void RoomItemCheck(Room room)
        {
            List<Item> roomItems = new List<Item>();
        }
        public void RoomSearchCheck(Room room)
        {
            switch (room.Name)
            {
                case "Vault Cave-in 2":
                    if (room.Searched)
                    {
                        room.Locked.Remove("s");
                    }
                    break;
                default:
                    break;
            }

        }
        public void InventoryCheck(Player currentPlayer, Room room)
        {
            for (int i = 0; i < currentPlayer.Inventory.Count; i++)
            {
                Item item = currentPlayer.Inventory[i];
                switch (room.Name)
                {
                    case "Vault Cave-in 3":
                        switch (item.Name)
                        {
                            case "PipBoy":
                                room.Description = "You find yourself in a narrow corridor with just barely enough room for you to fit through.";
                                break;
                            default:
                                break;
                        }
                        break;
                    case "Vault Cave-in 4":
                        switch (item.Name)
                        {
                            case "PipBoy":
                                room.Locked.Remove("s");
                                room.Locked.Remove("w");
                                room.Description = "The cavern, now illuminated, reveals the narrow passage to the north, a passage to the east, and a passage to the south.";
                                break;
                            default:
                                break;
                        }
                        break;
                    case "Vault Cave-in 5":
                        switch (item.Name)
                        {
                            case "PipBoy":
                                room.Description = "You see the skeleton of the Vault Dweller on the ground leaning against the wall. On closer inspection of the skull you see a hole on the right, lined up with another on it's left.";
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
            // if (!currentPlayer.Inventory.Contains(itemList[1]))
            // {
            //     room.Description += "You can see a green light coming from the east.";
            // }
            // else if (currentPlayer.Inventory.Contains(itemList[1]))
            // {
            //     room.Description = "You see a narrow corridor to the north, a passage to the east, and a passage to the south.";
            // }
            // if (!currentPlayer.Inventory.Contains(itemList[1]))
            // {
            //     room.Description = "The light is coming from the other side of the cavern. As you walk closer you can see that it is coming from a PipBoy attached to the arm of a skeleton. The color is different with the green light shining on it, but you'd recognize it's clothes anywhere as a Vault suit." + room.Description;
            // }
            // else if (currentPlayer.Inventory.Contains(itemList[1]))
            // {
            //     room.Description = "You see the skeleton of the Vault Dweller on the ground leaning against the wall. In it's hand, resting on the ground, you see it holding a bulky pistol. On closer inspection of the skull you see a hole on the right, lined up with another on it's left. ";
            // }
            // else if (currentPlayer.Inventory.Contains(itemList[1]) && currentPlayer.Inventory.Contains(itemList[2]))
            // {
            //     room.Description = "You see the skeleton of the Vault Dweller on the ground leaning against the wall. On closer inspection of the skull you see a hole on the right, lined up with another on it's left.";
            // }
        }
    }
}