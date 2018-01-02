using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<Item> Inventory { get; set; }
        public bool Alive { get; set; }
        public int Score { get; set; }
        public string Gender { get; set; }
        public Room PreviousRoom { get; set; }
        public string RestartText { get; set; }

        public Player(string name, string lastName, string gender, List<Item> inventory, bool alive)
        {
            Name = name;
            LastName = lastName;
            Inventory = inventory;
            Alive = alive;
            Gender = "NA";
            Gender = gender;
            PreviousRoom = new Room("", "");
            RestartText = "You have died. Would you like to play again? (Y/N): ";
        }
        public Room Go(Player currentPlayer, Room currentRoom, string direction)
        {
            bool isAlive = true;
            Event Event = new Event("event", true);
            //given a string direction...
            //check if the currentroom.exits contains a key for direction

            switch (direction)
            {
                case "north":
                    direction = "n";
                    break;
                case "south":
                    direction = "s";
                    break;
                case "east":
                    direction = "e";
                    break;
                case "west":
                    direction = "w";
                    break;
                default:
                    break;
            }

            if (currentRoom.Locked.ContainsKey(direction))
            {
                System.Console.WriteLine(currentRoom.LockedMessage);
                return currentRoom;
            }
            else if (currentRoom.Exits.ContainsKey(direction))
            {
                System.Console.Clear();
                isAlive = Event.DangerCheck(currentPlayer, currentRoom, direction);
                if (isAlive)
                {
                    switch (currentRoom.Name)
                    {
                        case "Vault Cave-in 7":
                            currentRoom.Description = currentRoom.DefaultDescription;
                            for (int i = 0; i < currentRoom.Enemies.Count; i++)
                            {
                                Enemy enemy = currentRoom.Enemies[i];
                                if (enemy.Dead == false)
                                {
                                    enemy.Pacified = false;
                                    currentRoom.EnemyDescribed = false;
                                }
                                else
                                {
                                    currentRoom.Description += enemy.DeadMessage;
                                }
                            }
                            break;
                        case "Surface":

                            return currentRoom;
                        default:
                            break;
                    }
                    currentPlayer.PreviousRoom = currentRoom;
                    currentRoom = currentRoom.Exits[direction];
                    return currentRoom;
                }
                return currentRoom;
            }
            else
            {
                System.Console.Clear();
                System.Console.WriteLine("Go where?");
                return currentRoom;
            }
        }
        public void Take(Room currentRoom, string item, Player currentPlayer)
        {
            if (currentRoom.Items.Count > 0)
            {
                for (int i = 0; i < currentRoom.Items.Count; i++)
                {
                    for (int j = 0; j < currentPlayer.Inventory.Count; j++)
                    {
                        if (item == currentPlayer.Inventory[i].Name.ToLower())
                        {
                            System.Console.WriteLine("You already have one of those. Why would you want another?");
                            EnterToContinue();
                            return;
                        }

                    }
                    if (currentRoom.Items[i].Takeable == false)
                    {
                        System.Console.WriteLine("You can't take that.");
                        return;
                    }
                    else if (item == currentRoom.Items[i].Name.ToLower())
                    {
                        currentPlayer.Inventory.Add(currentRoom.Items[i]);
                        if (item == "rock")
                        {
                            System.Console.WriteLine("You took the " + item + "\n\n\n");
                            return;
                        }
                        currentRoom.Items.Remove(currentRoom.Items[i]);
                        System.Console.WriteLine("You took the " + item + "\n\n\n");
                    }

                    else
                    {
                        System.Console.WriteLine("Take what?");
                    }
                }
            }
            else
            {
                System.Console.WriteLine("Take what?");
            }
        }
        public void Look(Room currentRoom)
        {
            System.Console.WriteLine($@"
 {currentRoom.Name}

 {currentRoom.Description}");
        }
        public void Items(Player currentPlayer)
        {
            if (currentPlayer.Inventory.Count > 0)
            {

                for (int i = 0; i < currentPlayer.Inventory.Count; i++)
                {
                    Item item = currentPlayer.Inventory[i];
                    System.Console.ForegroundColor = System.ConsoleColor.DarkYellow;
                    System.Console.WriteLine("      " + item.Name + "\n");
                    System.Console.ForegroundColor = System.ConsoleColor.Green;
                    System.Console.WriteLine("----------------------------------------------------\n");
                    System.Console.ForegroundColor = System.ConsoleColor.Cyan;
                    System.Console.WriteLine("      " + item.Description + "\n"); System.Console.ForegroundColor = System.ConsoleColor.Green;
                    System.Console.WriteLine("----------------------------------------------------\n");
                }
                System.Console.ForegroundColor = System.ConsoleColor.Green;
                EnterToContinue();
            }
            else
            {
                System.Console.WriteLine("You are not carrying any items.");
                EnterToContinue();
            }
        }
        public void Search(Room currentRoom, string option)
        {
            if (currentRoom.SearchableObjects.Count > 0)
            {
                foreach (var keyword in currentRoom.SearchableObjects)
                {
                    string searchable = keyword.Key.ToLower();
                    if (searchable == option && currentRoom.Searched == false)
                    {
                        currentRoom.Searched = true;
                        currentRoom.Items.Add(currentRoom.SearchableObjects[keyword.Key]);
                        // currentRoom.SearchableObjects.Remove(keyword.Key);
                        System.Console.WriteLine(keyword.Value.DescriptionInRoom);
                        EnterToContinue();
                        return;
                    }
                    else if (searchable == option && currentRoom.Searched)
                    {
                        System.Console.WriteLine("You've already searched the " + searchable);
                        EnterToContinue();
                    }
                    else if (option == "room")
                    {
                        // currentRoom.Searched = true;
                        if (currentRoom.Name == "Vault Cave-in 5")
                        {
                            System.Console.WriteLine("There is a skeleton leaning against the wall.");
                            EnterToContinue();
                            return;
                        }
                        System.Console.WriteLine("You've already searched the " + searchable);
                        EnterToContinue();
                        currentRoom.Searched = true;
                    }
                    else
                    {
                        System.Console.WriteLine("Search what?");
                        EnterToContinue();
                        System.Console.Clear();
                    }
                }
            }
            else
            {
                switch (option)
                {
                    case "room":
                        if (currentRoom.Searched == true)
                        {
                            System.Console.WriteLine("You've already searched this room.");
                            EnterToContinue();
                            System.Console.Clear();
                        }
                        else if (currentRoom.SearchDescription == "")
                        {
                            System.Console.WriteLine("There is nothing notable in this room.");
                            EnterToContinue();
                            System.Console.Clear();
                        }
                        else if (currentRoom.Searched == false)
                        {
                            currentRoom.Searched = true;
                            currentRoom.Description += currentRoom.SearchDescription;
                            System.Console.WriteLine(currentRoom.SearchDescription);
                            EnterToContinue();
                            System.Console.Clear();
                        }
                        break;
                    default:
                        System.Console.WriteLine("Search what?");
                        EnterToContinue();
                        System.Console.Clear();
                        break;
                }
            }
        }
        public void GiveUp(Player currentPlayer, string option)
        {
            string giveUpMessage = "You can't take it anymore. The madness of this world. The isolation of this horrible, lonely existence. You've failed your family. You can't bear to go on.";
            string pistolMessage = " You look at the pistol in your hand. A defeated chuckle escapes your throat. This pistol now feels like your best friend, helping you escape from this place. You bring it up to your temple. Your hand is trembling but you're resolved to end it. You whince as you pull the tigger...";
            bool hasPistol = false;
            bool hasAmmo = false;
            if (option == "up")
            {
                for (int i = 0; i < currentPlayer.Inventory.Count; i++)
                {
                    Item item = currentPlayer.Inventory[i];
                    switch (item.Name)
                    {
                        case "Pistol":
                            hasPistol = true;
                            break;
                        case "Ammo":
                            hasAmmo = true;
                            break;
                        default:
                            break;
                    }
                }
                switch (hasPistol)
                {
                    case true:
                        switch (hasAmmo)
                        {
                            case true:
                                System.Console.WriteLine(giveUpMessage + pistolMessage);
                                EnterToContinue();
                                System.Console.WriteLine("Bang.");
                                EnterToContinue();
                                currentPlayer.Alive = false;
                                break;
                            default:
                                System.Console.WriteLine(giveUpMessage + pistolMessage);
                                EnterToContinue();
                                System.Console.WriteLine("Click...... Click, click, click..... The pistol isn't loaded.... You look at the gun in disbelief, pulling the trigger over and over. No! This can't be happening! You can't take any more of this! You let out a maddened shriek as you bash your head against the cave wall over and over until finally passing out.");
                                EnterToContinue();
                                currentPlayer.Alive = false;
                                break;
                        }
                        break;
                    default:
                        System.Console.WriteLine(giveUpMessage + " Having no weapons, you look around the cavern for anything you can use. You find a rock as big as your upper body and a rather large stick. You set the rock up so it's being held up by the stick against the wall above the ground. You lay down, positioning your head underneath it. You're just going to take a nap, that's all. A nice, long nap. Steeling yourself you knock the stick away and let the rock fall.");
                        currentPlayer.Alive = false;
                        EnterToContinue();
                        break;
                }
            }
            else
            {
                System.Console.WriteLine("I don't understand that.");
                EnterToContinue();
            }
        }
        public void UseItem(Player currentPlayer, Room currentRoom, Item item)
        {
            Enemy enemy = new Enemy("", false, "", "", "", "", "");
            Item inventoryItem = new Item("", "", "", "", "", true);
            switch (item.Name.ToLower())
            {
                case "rock":
                    switch (currentRoom.Name)
                    {
                        case "Vault Cave-in 7":
                            for (int i = 0; i < currentRoom.Enemies.Count; i++)
                            {
                                enemy = currentRoom.Enemies[i];
                                enemy.Pacified = true;
                                System.Console.WriteLine(enemy.PacifiedMessage);
                                currentPlayer.Inventory.Remove(item);
                                EnterToContinue();
                            }
                            return;
                        default:
                            System.Console.WriteLine(item.BadUse);
                            currentPlayer.Inventory.Remove(item);
                            EnterToContinue();
                            break;
                    }
                    break;
                case "pistol":
                    bool hasAmmo = false;
                    for (int i = 0; i < currentPlayer.Inventory.Count; i++)
                    {
                        inventoryItem = currentPlayer.Inventory[i];
                        switch (inventoryItem.Name)
                        {
                            case "Ammo":
                                hasAmmo = true;
                                break;
                            default:
                                break;
                        }
                    }
                    switch (currentRoom.Name)
                    {
                        case "Vault Cave-in 7":
                            for (int j = 0; j < currentRoom.Enemies.Count; j++)
                            {
                                enemy = currentRoom.Enemies[j];
                                switch (hasAmmo)
                                {
                                    case true:
                                        System.Console.WriteLine(enemy.DyingMessage);
                                        enemy.Pacified = true;
                                        enemy.Dead = true;
                                        EnterToContinue();
                                        return;
                                    default:
                                        System.Console.WriteLine("You take aim at the radscorpion with the pistol and fire. Click...... Click, click, click..... The pistol isn't loaded...." + enemy.KillMessage);
                                        EnterToContinue();
                                        currentPlayer.Alive = false;
                                        break;
                                }
                            }
                            break;
                        default:
                            switch (hasAmmo)
                            {
                                case true:
                                    System.Console.WriteLine(item.BadUse + "The last thing you hear is a loud bang. You shot your eye out. And your brains.");
                                    currentPlayer.Alive = false;
                                    EnterToContinue();
                                    break;
                                default:
                                    System.Console.WriteLine(item.BadUse + "You hear a click. Good thing it wasn't loaded. You cautiously put the gun away.");
                                    EnterToContinue();
                                    break;
                            }
                            break;
                    }
                    break;
                default:
                    // System.Console.WriteLine("Use what?");
                    // EnterToContinue();
                    break;
            }
        }
        public void EnterToContinue()
        {
            System.Console.WriteLine("Press Enter to continue.");
            System.Console.ReadLine();
        }

        public void Help()
        {
            System.Console.WriteLine(@"


            
        Go - Go to a room through an exit in the direction that you specify.
        Take - Take an item from the current room.
        Use - Use an item from your inventory or an item that is in the room.
        Look - Look around the room to get your bearings.
        Inventory - See what items you have in your inventory.
        Give Up - End it all.
        Search - Inspect an object/area for more detailed information, ie. search desk.
        quit - Quit the game.
        
        
        ");
        }

    }
}