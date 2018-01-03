using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }
        public List<Room> AllRooms = new List<Room>();
        public void Setup()
        {
            List<Item> inventory = new List<Item>();
            List<Item> itemList = new List<Item>();
            List<Enemy> enemyList = new List<Enemy>();
            Build Build = new Build();

            CharacterCreation(inventory);

            itemList = Build.BuildItems();
            enemyList = Build.BuildEnemies();
            AllRooms = Build.BuildRooms(itemList, enemyList);
            CurrentRoom = AllRooms[0];
        }
        public void Reset()
        {
            Setup();
        }
        public void GameLoop()
        {
            string input;
            bool running = true;
            var defaultBackgroundColor = Console.BackgroundColor;
            var defaultForegroundColor = Console.ForegroundColor;
            Event Event = new Event("event", true);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            System.Console.WriteLine("WELCOME TO FALLOUT: PILGRIMAGE\n\n\n");
            EnterToContinue();
            Setup();

            Intro();

            while (running)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine("Type help at any time to see a list of possible commands.\n\n\n");
                Event.EnemyCheck(CurrentRoom, CurrentPlayer);
                Event.InventoryCheck(CurrentPlayer, CurrentRoom);
                Event.RoomSearchCheck(CurrentRoom);
                Event.RoomItemCheck(CurrentPlayer, CurrentRoom);

                #region Test code
                // if (CurrentPlayer.Inventory.Count != 0)
                // {
                //     System.Console.WriteLine("Inventory:");
                //     for (int i = 0; i < CurrentPlayer.Inventory.Count; i++)
                //     {
                //         System.Console.WriteLine($@"
                // Item Name: {CurrentPlayer.Inventory[i].Name}
                // Item Description: {CurrentPlayer.Inventory[i].Description}");
                //     }
                // }
                // if (CurrentRoom.Items.Count != 0)
                // {
                //     System.Console.WriteLine("Room Items: ");
                //     for (int i = 0; i < CurrentRoom.Items.Count; i++)
                //     {
                //         System.Console.WriteLine($@"
                // Item Name: {CurrentRoom.Items[i].Name}
                // Is Room Item: {i}
                // Item Description: {CurrentRoom.Items[i].Description}");
                //     }
                // }
                // if (CurrentRoom.SearchableObjects.Count > 0)
                // {
                //     foreach (var searchable in CurrentRoom.SearchableObjects)
                //     {
                //         System.Console.WriteLine($@"Searchable Objects: {searchable.Key}");
                //     }
                // }
                #endregion

                System.Console.Write("\nWhat would you like to do?: ");
                input = Console.ReadLine();
                string[] inputArr = input.Split(' ');
                string command = inputArr[0];
                string option = "";
                for (int i = 1; i < inputArr.Length; i++)
                {
                    option += inputArr[i];
                    if (i < inputArr.Length - 1)
                    {
                        option += " ";
                    }
                }
                command.ToLower();
                option.ToLower();
                switch (command)
                {
                    case "go":
                        Console.Clear();
                        CurrentRoom = CurrentPlayer.Go(CurrentPlayer, CurrentRoom, option);
                        break;
                    case "take":
                        Console.Clear();
                        CurrentPlayer.Take(CurrentRoom, option, CurrentPlayer);
                        break;
                    case "use":
                        Console.Clear();
                        UseItem(option);
                        break;
                    case "look":
                        Console.Clear();
                        break;
                    case "search":
                        Console.Clear();
                        CurrentPlayer.Search(CurrentRoom, option);
                        break;
                    case "inventory":
                        Console.Clear();
                        CurrentPlayer.Items(CurrentPlayer);
                        break;
                    case "give":
                        Console.Clear();
                        CurrentPlayer.GiveUp(CurrentPlayer, option);
                        break;
                    case "help":
                        Console.Clear();
                        CurrentPlayer.Help();
                        break;
                    case "quit":
                        Console.Clear();
                        Console.ForegroundColor = defaultForegroundColor;
                        Console.BackgroundColor = defaultBackgroundColor;
                        return;
                    default:
                        Console.Clear();
                        System.Console.WriteLine("I didn't understand that.");
                        break;
                }
                running = Event.AliveCheck(CurrentPlayer, running);
                running = WinCheck(CurrentRoom, running);
                if (running == true && CurrentPlayer.Alive)
                {
                    continue;
                }
                else if (running == false && CurrentPlayer.Alive == false)
                {
                    Console.ForegroundColor = defaultForegroundColor;
                    return;
                }
                else if (running == true && CurrentPlayer.Alive == false)
                {
                    Reset();
                }
            }
            Console.ForegroundColor = defaultForegroundColor;
            Console.BackgroundColor = defaultBackgroundColor;
        }
        public void UseItem(string itemName)
        {
            // if (CurrentPlayer.Inventory.Count > 0)
            // {
            for (int i = 0; i < CurrentPlayer.Inventory.Count; i++)
            {
                Item item = CurrentPlayer.Inventory[i];
                if (item.Name.ToLower() == itemName)
                {
                    CurrentPlayer.UseItem(CurrentPlayer, CurrentRoom, item);
                    return;
                }
            }
            for (int i = 0; i < CurrentRoom.Items.Count; i++)
            {
                Item item = CurrentRoom.Items[i];
                if (item.Name.ToLower() == itemName)
                {
                    CurrentRoom.UseItem(item);
                    return;
                }
            }
            System.Console.WriteLine("Use what?");
            EnterToContinue();
            // }
        }
        public void EnterToContinue()
        {
            System.Console.WriteLine("\nPress Enter to continue.");
            System.Console.ReadLine();
        }
        public void CharacterCreation(List<Item> inventory)
        {
            string firstName;
            string lastName;
            string gender;
            bool genderSet = false;
            System.Console.Write("What is your first name?: ");
            firstName = Console.ReadLine();

            System.Console.Write("What is your last name?: ");
            lastName = Console.ReadLine();

            while (genderSet == false)
            {
                System.Console.Write("Are you male or female? (M/F): ");
                gender = Console.ReadLine();

                switch (gender.ToLower())
                {
                    case "m":
                    case "male":
                        gender = "Male";
                        genderSet = true;
                        break;
                    case "f":
                    case "female":
                        gender = "Female";
                        genderSet = true;
                        break;
                    default:
                        continue;
                }
                CurrentPlayer = new Player(firstName, lastName, gender, inventory, true);
            }
        }
        public bool WinCheck(Room currentRoom, bool running)
        {
            if (currentRoom.Name == "Surface")
            {
                System.Console.WriteLine("You made it to the surface! Finally you can really start your journey to find a new home for your family. Thanks for completing the shareware version of this game! Purchase the full game to continue your adventure! Purchase the season pass to get access to the 3 expansion DLC when they release for $59.99! Purchase the Stylin' Vault Dweller packs for $9.99 each to show the denizens of the wasteland that just because the world has gone to hell, that doesn't mean you can't still look good! Thanks for playing!");
                EnterToContinue();
                running = false;
                return running;
            }
            return running;
        }
        public void Intro()
        {
            Console.Clear();
            System.Console.WriteLine("War. War never changes.");
            EnterToContinue();
            System.Console.WriteLine("The world was destroyed in nuclear fire on October 23, 2077. It took less than two hours for civilization to completely crumble across the globe. A small portion of the population in America was able to take shelter in one of VaultTec's underground Vaults. Those remaining on the surface were left to fend for themselves. Those that died in the initial blasts were the lucky ones. Those that didn't had the hellish task of trying to survive in the irradiated wasteland, or worse, were mutated by the fallout into horrific creatures.");
            EnterToContinue();
            System.Console.WriteLine("Your ancestors were fortunate enough to secure a spot in Vault 847. You've lived there your entire life. It's been a comfortable life, but unlike war, that is changing. Many of your fellow Vault Dwellers have grown bigotted and violent after the previous Overseer died and was replaced. Your parents don't feel it's safe to live in the Vault anymore, but know your family would likely be killed if they tried to leave. Luckily, they have a plan.");
            EnterToContinue();
            System.Console.WriteLine("Your mother knows of a secret second entrance to the vault. Your father will fake your death so the others don't become suspicious and your family will be safe. You will then leave your home and search for another place that your family can be safe.");
            EnterToContinue();
            System.Console.WriteLine("After a quick, tearful goodbye with your family you set out with only a baseball bat and some rations. Your father collapsed the tunnel leading to the second exit behind you, taking with him your PipBoy arm computer as evidence of your death. You turn away from the rubble with new resolve. You don't know very much about the outside world. But there is one thing you know from your time in school.");
            EnterToContinue();
            System.Console.WriteLine("War. War never changes.");
            EnterToContinue();
            Console.Clear();
        }
    }
}