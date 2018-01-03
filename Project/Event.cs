using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Event
    {
        public string Name { get; set; }
        public bool Events { get; set; }
        public int MyProperty { get; set; }
        public Event(string name, bool events)
        {
            Name = name;
            Events = events;
        }

        public void RoomItemCheck(Player currentPlayer, Room currentRoom)
        {
            List<Item> roomItems = new List<Item>();
            //Checks if there are any items in the room and displays their DescriptionInRoom after the room description, else just displays the room description.
            if (currentRoom.Items.Count > 0)
            {
                currentPlayer.Look(currentRoom);

                for (int i = 0; i < currentRoom.Items.Count; i++)
                {
                    if (i == currentRoom.Items.Count - 1)
                    {
                        System.Console.WriteLine(currentRoom.Items[i].DescriptionInRoom);
                    }
                    else
                    {
                        System.Console.Write(currentRoom.Items[i].DescriptionInRoom);
                    }
                }
            }
            else
            {
                currentPlayer.Look(currentRoom);
            }
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
                                room.Description = "You find yourself in a narrow corridor with just barely enough room for you to fit through. You can continue north or south.";
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
                                room.Description = "The cavern, now illuminated, reveals the narrow passage to the north, a passage to the east, and a passage to the south. The small creatures that occupied the room flee in the presence of the light of your PipBoy.";
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
        }
        public void EnemyCheck(Room room, Player currentPlayer)
        {
            if (room.Enemies.Count > 0)
            {
                for (int i = 0; i < room.Enemies.Count; i++)
                {
                    Enemy enemy = room.Enemies[i];
                    if (room.Name == "Vault Cave-in 7" && enemy.Dead == false)
                    {
                        room.EnemyDescribed = true;
                        if (enemy.Pacified)
                        {
                            room.Description = room.DefaultDescription;
                        }
                        else
                        {
                            room.Description = room.DefaultDescription + enemy.Description;
                        }
                    }
                    else if (room.EnemyDescribed == false && enemy.Dead == false)
                    {
                        room.EnemyDescribed = true;
                        if (enemy.Pacified == false)
                        {
                            room.Description += enemy.Description;
                        }
                    }
                    else if (enemy.Dead)
                    {
                        room.Description = room.DefaultDescription + enemy.DeadMessage;
                    }
                    else
                    {
                        room.Description = room.DefaultDescription;
                    }
                }
            }
        }
        public bool DangerCheck(Player currentPlayer, Room room, string direction)
        {
            switch (room.Name)
            {
                case "Vault Cave-in 7":
                    if ((currentPlayer.PreviousRoom.Name == "Vault Cave-in 6" && direction != "w") || (currentPlayer.PreviousRoom.Name == "Vault Cave-in 8" && direction != "n"))
                    {
                        for (int i = 0; i < room.Enemies.Count; i++)
                        {
                            Enemy enemy = room.Enemies[i];
                            switch (enemy.Pacified)
                            {
                                case false:
                                    System.Console.WriteLine("As you move into the room you accidently kick a rock." + enemy.KillMessage);
                                    EnterToContinue();
                                    currentPlayer.Alive = false;
                                    return currentPlayer.Alive;
                                default:
                                    break;
                            }
                        }
                    }
                    return currentPlayer.Alive;
                default:
                    return currentPlayer.Alive;
            }
        }
        public bool AliveCheck(Player currentPlayer, bool running)
        {
            bool playAgainCheck = true;
            string input = "";
            // System.Console.WriteLine("Are you alive?: " + currentPlayer.Alive);
            if (currentPlayer.Alive == false)
            {
                while (playAgainCheck)
                {
                    System.Console.Write(currentPlayer.RestartText);
                    input = System.Console.ReadLine().ToLower();

                    switch (input)
                    {
                        case "y":
                            playAgainCheck = false;
                            return running;
                        case "n":
                            playAgainCheck = false;
                            running = false;
                            return running;
                        default:
                            continue;
                    }
                }
            }
            return running;
        }
        public bool RunReset()
        {
            return true;
        }
        public void EnterToContinue()
        {
            System.Console.WriteLine("\nPress Enter to continue.");
            System.Console.ReadLine();
        }
    }
}