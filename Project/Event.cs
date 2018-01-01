using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Event
    {
        public string Name { get; set; }

        public bool Events { get; set; }
        Game Game = new Game();


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
        }
        public void EnemyCheck(Room room)
        {
            if (room.Enemies.Count > 0)
            {
                for (int i = 0; i < room.Enemies.Count; i++)
                {
                    Enemy enemy = room.Enemies[i];
                    if (room.EnemyDescribed == false && enemy.Dead == false)
                    {
                        room.EnemyDescribed = true;
                        if (enemy.Pacified == false)
                        {
                            room.Description += enemy.Description;
                            // System.Console.WriteLine("THIS IS THE DEFAULT DESCRIPTION: " + room.DefaultDescription);
                        }
                    }
                    else if (enemy.Dead)
                    {
                        room.Description += enemy.DeadMessage;
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
                                    System.Console.Write(Game.EnterKey);
                                    System.Console.ReadLine();
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

            string input = "";
            if (currentPlayer.Alive == false)
            {
                while (running)
                {
                    System.Console.Write(currentPlayer.RestartText);
                    input = System.Console.ReadLine().ToLower();

                    switch (input)
                    {
                        case "y":
                            Game.Reset();
                            return running;
                        case "n":
                            running = false;
                            return running;
                        default:
                            continue;
                    }
                }
            }
            return running;
        }
    }
}