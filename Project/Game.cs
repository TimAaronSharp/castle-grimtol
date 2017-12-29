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
            Console.Clear();
            string input;
            string lastName;
            string gender;
            bool genderSet = false;
            Build Build = new Build();
            //Create rooms and set current room
            System.Console.Write("What is your first name?: ");

            input = Console.ReadLine();
            System.Console.WriteLine("What is your last name?");
            lastName = Console.ReadLine();
            while (genderSet == false)
            {
                System.Console.WriteLine("Are you male or female? (M/F)");
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
                        System.Console.WriteLine("Are you male or female? (M/F)");
                        break;
                }
                CurrentPlayer = new Player(input, lastName, gender);
            }
            List<Item> itemList = Build.BuildItems();
            AllRooms = Build.BuildRooms(itemList);
            CurrentRoom = AllRooms[0];
        }
        public void Reset()
        {
            Setup();
        }
        // public void BuildRooms(List<Item> itemList)
        // {
        //     //Declaring rooms
        //     Room room1 = new Room("Vault Cave-in 1", "There is a cave-in on the west side of the cavern. Looking at it fills you with resolve to find a new home for your family.");
        //     Room room2 = new Room("Vault Cave-in 2", "There is a cave-in to the east. This was likely the way to the exit. You feel a sting of discouragement. You'll have to find another way.");
        //     Room room3 = new Room("Vault Cave-in 3", "You find yourself in a narrow corridor with just barely enough room for you to fit through. It's getting darker the further into the cave you go.");
        //     Room room4 = new Room("Vault Cave-in 4", "The cavern is almost pitch black here. You can see a light coming from the east.");
        //     Room room5 = new Room("Vault Cave-in 5", " ");
        //     Room room6 = new Room("Vault Cave-in 6", "Congrats! Room 6!");
        //     //Adding exits to rooms
        //     room1.Exits.Add("e", room2);
        //     room2.Exits.Add("w", room1);
        //     room2.Exits.Add("s", room3);
        //     room3.Exits.Add("n", room2);
        //     room3.Exits.Add("s", room4);

        //     room4.Exits.Add("n", room3);
        //     room4.Exits.Add("e", room5);
        //     room4.Exits.Add("s", room6);

        //     room5.Exits.Add("w", room4);

        //     room6.Exits.Add("n", room4);

        //     room4.Locked.Add("s", true);
        //     room4.Locked.Add("w", true);

        //     room4.LockedMessage = "It's too dark to see anything in that direction.";

        //     //Might be better to throw these in events or something.

        //     //Adding items to rooms
        //     Item bronzeKey = itemList[0];
        //     Item pipBoy = itemList[1];
        //     Item pistol = itemList[2];

        //     // room2.AddItems(bronzeKey);
        //     room5.AddItems(pipBoy);
        //     room5.AddItems(pistol);
        //     //Adding rooms to AllRooms list
        //     AllRooms.Add(room1);
        //     AllRooms.Add(room2);
        //     AllRooms.Add(room3);
        //     AllRooms.Add(room4);
        //     AllRooms.Add(room5);
        //     AllRooms.Add(room6);
        // }
        // public void BuildItems()
        // {
        // List<Item> ItemList = new List<Item>();
        // //Declaring and defining items
        // Item bronzeKey = new Item("Bronze Key", "It's a bronze key", "Key", " There is a bronze key on the floor.");
        // Item pipBoy = new Item("PipBoy", "Your handy dandy PipBoy!", "Upgrade", " The light is coming from the other side of the cavern. As you walk closer you can see that it is coming from a PipBoy attached to the arm of a skeleton. The color is different with the green light shining on it, but you'd recognize it's clothes anywhere as a Vault suit. On closer inspection of the skull you see a hole on the right, lined up with another on it's left.");
        // Item pistol = new Item("Pistol", "Large pistol that shoots 10mm bullets", "Weapon", " In it's hand, resting on the ground, you see it holding a bulky pistol.");

        // bronzeKey.Direction = "e";
        // //Adding items to list to pass as argument
        // ItemList.Add(bronzeKey);
        // ItemList.Add(pipBoy);
        // ItemList.Add(pistol);

        // BuildRooms(ItemList);

        // }
        public void GameLoop()
        {
            Setup();
            string input;
            bool running = true;
            Event Event = new Event("event", true);

            System.Console.WriteLine(@"
            
             War. War never changes. 
             
             The world was destroyed in nuclear fire on October 23, 2077. It took less than two hours for civilization to completely crumble across the globe. A small portion of the population in America was able to take shelter in one of VaultTec's underground Vaults. Those remaining on the surface were left to fend for themselves. Those that died in the initial blasts were the lucky ones. Those that didn't had the hellish task of trying to survive in the irradiated wasteland, or worse, were mutated by the fallout into horrific creatures.

             Your ancestors were fortunate enough to secure a spot in Vault 847. You lived there your entire life. It's been a comfortable life, but unlike war, that is changing. Many of your fellow Vault Dwellers have grown bigotted and violent after the previous Overseer died and was replaced. Your parents don't feel it's safe to live in the Vault anymore, but know your family would likely be killed if they tried to leave. Luckily, they have a plan.

             Your mother knows of a secret second entrance to the vault. Your father will fake your death so the others don't become suspicious and your family will be safe. You will then leave your home and search for another place that your family can be safe.

             After a quick, tearful goodbye with your family you set out with only a baseball bat and some rations. Your father collapsed the tunnel leading to the second exit behind you, taking with him your PipBoy arm computer as evidence of your death. You turn away from the rubble with new resolve. You don't know very much about the outside world. But there is one thing you know from your time in school.

             War. War never changes.
            ");
            // System.Console.WriteLine("Score: " + CurrentPlayer.Score);
            while (running)
            {
                Event.RoomItemCheck(CurrentRoom); //Keep working on this.
                Event.InventoryCheck(CurrentPlayer, CurrentRoom);

                System.Console.WriteLine(CurrentRoom.Name);
                if (CurrentRoom.Items.Count > 0)
                {
                    System.Console.Write(CurrentRoom.Description);
                    for (int i = 0; i < CurrentRoom.Items.Count; i++)
                    {
                        if (i == CurrentRoom.Items.Count - 1)
                        {
                            System.Console.WriteLine(CurrentRoom.Items[i].DescriptionInRoom);
                        }
                        else
                        {
                            System.Console.Write(CurrentRoom.Items[i].DescriptionInRoom);
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine(CurrentRoom.Description);
                }
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
                if (CurrentRoom.Items.Count != 0)
                {
                    System.Console.WriteLine("Room Items: ");
                    for (int i = 0; i < CurrentRoom.Items.Count; i++)
                    {
                        System.Console.WriteLine($@"
                Item Name: {CurrentRoom.Items[i].Name}
                Item Description: {CurrentRoom.Items[i].Description}");
                    }
                }
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
                switch (command.ToLower())
                {
                    case "go":
                        CurrentRoom = CurrentPlayer.Go(CurrentRoom, option);
                        break;
                    case "take":
                        CurrentPlayer.Take(CurrentRoom, option, CurrentPlayer);
                        break;
                    case "use":
                        UseItem(option);
                        break;
                    case "look":
                        CurrentPlayer.Look(CurrentRoom);
                        break;
                    case "help":
                        CurrentPlayer.Help();
                        break;
                    case "quit":
                        running = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public void UseItem(string itemName)
        {
            for (int i = 0; i < CurrentPlayer.Inventory.Count; i++)
            {
                Item item = CurrentPlayer.Inventory[i];
                if (item.Name.ToLower() == itemName.ToLower())
                {
                    switch (item.Type)
                    {
                        case "Key":
                            System.Console.WriteLine("Hey you used a key brah!");

                            CurrentRoom.Locked.Remove(item.Direction);
                            CurrentPlayer.Inventory.Remove(item);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}