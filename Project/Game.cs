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
            BuildRoom();
            GameLoop(AllRooms);
            CurrentRoom = AllRooms[0];
        }
        public void Reset()
        {

        }
        public void BuildRoom()
        {
            List<Room> roomBuilder = new List<Room>();
            Room room1 = new Room("Room 1", "This is Room 1");
            Room room2 = new Room("Room 2", "This is Room 2");
            Room room3 = new Room("Room 3", "This is Room 3");
            Room room4 = new Room("Room 4", "This is Room 4");

            room1.Exits.Add("E", room2);
            room2.Exits.Add("W", room1);
            room2.Exits.Add("E", room3);
            room3.Exits.Add("W", room2);
            room3.Exits.Add("E", room4);
            room4.Exits.Add("W", room3);

            AllRooms.Add(room1);
            AllRooms.Add(room2);
            AllRooms.Add(room3);
            AllRooms.Add(room4);



            // for (int i = 0; i < roomBuilder.Count; i++)
            // {

            // }

        }
        public void GameLoop(List<Room> rooms)
        {
            string input;
            bool running = true;

            System.Console.WriteLine("Sup, Dawg! Your adventure is starting!");

            for (int i = 0; i < AllRooms.Count; i++)
            {
                System.Console.Write(AllRooms[i].Name);
                System.Console.WriteLine(" " + AllRooms[i].Description);

            }
            // System.Console.WriteLine(rooms[0].Description);

            // while (running)
            // {

            //     input = Console.ReadLine();
            //     string[] inputArr = input.Split(" ");
            //     if (inputArr[0].ToLower() == "go")
            //     {
            //         Go(inputArr[1], CurrentRoom);
            //     }

            // }

        }

        // public void Go(string direction, Room curRoom)
        // {
        //     Room value;
        //     if(curRoom.Exits.ContainsKey(direction)){
        //         CurrentRoom = curRoom.Exits.TryGetValue(direction, out value);
        //     }

        // }
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