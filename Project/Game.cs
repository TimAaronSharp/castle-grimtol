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
            BuildItems();
            CurrentRoom = AllRooms[0];
            GameLoop(AllRooms);
        }
        public void Reset()
        {
            Setup();
        }
        public void BuildRooms(List<Item> itemList)
        {
            //Declaring rooms
            Room room1 = new Room("Room 1", "This is Room 1");
            Room room2 = new Room("Room 2", "This is Room 2");
            Room room3 = new Room("Room 3", "This is Room 3");
            Room room4 = new Room("Room 4", "This is Room 4");
            //Adding exits to rooms
            room1.Exits.Add("e", room2);
            room2.Exits.Add("w", room1);
            room2.Exits.Add("e", room3);
            room3.Exits.Add("w", room2);
            room3.Exits.Add("e", room4);
            room4.Exits.Add("w", room3);
            //Adding items to rooms
            room2.AddItems(itemList[0]);
            //Adding rooms to AllRooms list
            AllRooms.Add(room1);
            AllRooms.Add(room2);
            AllRooms.Add(room3);
            AllRooms.Add(room4);
        }
        public void BuildItems()
        {
            List<Item> ItemList = new List<Item>();
            //Declaring and defining items
            Item bronzeKey = new Item("Key", "It's a bronze key");
            //Adding items to list to pass as argument
            ItemList.Add(bronzeKey);

            BuildRooms(ItemList);

        }
        public void GameLoop(List<Room> rooms)
        {
            string input;
            bool running = true;

            System.Console.Write("Sup, Dawg! Your adventure is starting! What's your name?: ");

            input = Console.ReadLine();
            Player CurrentPlayer = new Player(input);

            System.Console.WriteLine($"Nice to meet you, {CurrentPlayer.Name}! Where would you like to go?");
            // for (int i = 0; i < CurrentPlayer.Inventory.Count; i++)
            // {
            // System.Console.WriteLine("Inventory: " + CurrentPlayer.Inventory[i]);

            // }
            System.Console.WriteLine("Score: " + CurrentPlayer.Score);
            while (running)
            {
                System.Console.WriteLine(CurrentRoom.Name);
                System.Console.WriteLine(CurrentRoom.Description);
                if (CurrentPlayer.Inventory.Count != 0)
                {
                    System.Console.WriteLine("Inventory:");
                    for (int i = 0; i < CurrentPlayer.Inventory.Count; i++)
                    {
                        System.Console.WriteLine(CurrentPlayer.Inventory[i].Name);
                    }
                }
                if (CurrentRoom.Items.Count != 0)
                {
                    for (int i = 0; i < CurrentRoom.Items.Count; i++)
                    {
                        System.Console.WriteLine(CurrentRoom.Items[i].Name);
                        System.Console.WriteLine(CurrentRoom.Items[i].Description);
                    }
                }

                input = Console.ReadLine();
                string[] inputArr = input.Split(" ");
                // System.Console.WriteLine(inputArr.Length);
                // for (int i = 0; i < inputArr.Length; i++)
                // {
                //     System.Console.WriteLine($"inputArr[{i}]: " + inputArr[i]);
                // }
                if (inputArr[0].ToLower() == "go")
                {
                    Go(inputArr[1]);
                }
                else if (inputArr[0].ToLower() == "take")
                {
                    // System.Console.WriteLine("TESTING 1 2 3    " + inputArr[1]);
                    Take(inputArr[1]);
                }
                else if (inputArr[0].ToLower() == "quit")
                {
                    running = false;
                }
            }
        }
        public void Go(string direction)
        {
            if (CurrentRoom.Exits.ContainsKey(direction))
            {
                Console.Clear();
                CurrentRoom = CurrentRoom.Exits[direction];
            }
            else
            {
                Console.Clear();
                System.Console.WriteLine("There is no exit in that direction....dummy...");
            }
        }
        public void Take(string item)
        {
            for (int i = 0; i < CurrentRoom.Items.Count; i++)
            {
                System.Console.WriteLine("TESTING 1 2 3    " + CurrentPlayer.Inventory + " WHY DOESN'T THIS WORK?!?!?");
                System.Console.WriteLine("TESTING 1 2 3    " + CurrentRoom.Items[i].Name + " WHY DOESN'T THIS WORK?!?!?");
                if (CurrentRoom.Items[i].Name == item)
                {
                    CurrentPlayer.Inventory.Add(CurrentRoom.Items[i]);
                    CurrentRoom.Items.Remove(CurrentRoom.Items[i]);
                }
            }
        }
        public void Look(List<Room> rooms)
        {
            System.Console.WriteLine(CurrentRoom.Description);
        }
        // public void AddRoom(){
        //     // AllRooms.Add(room1);
        // }
        public void UseItem(string itemName)
        {

        }
    }
}