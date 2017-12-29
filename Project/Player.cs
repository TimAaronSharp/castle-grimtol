using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Health { get; set; }
        public int Score { get; set; }
        public string Gender { get; set; }
        public List<Item> Inventory { get; set; }

        public Player(string name, string lastName, string gender)
        {
            Name = name;
            LastName = lastName;
            Inventory = new List<Item>();
            Health = 100;
            Gender = "NA";
            Gender = gender;
        }
        public Room Go(Room currentRoom, string direction)
        {
            //given a string direction...
            //check if the currentroom.exits contains a key for direction

            if (currentRoom.Locked.ContainsKey(direction))
            {
                System.Console.WriteLine(currentRoom.LockedMessage);
                return currentRoom;
            }
            else if (currentRoom.Exits.ContainsKey(direction))
            {
                System.Console.Clear();
                currentRoom = currentRoom.Exits[direction];
                return currentRoom;
            }
            else
            {
                System.Console.Clear();
                System.Console.WriteLine("There is no exit in that direction....dummy...");
                return currentRoom;
            }
        }
        public void Take(Room currentRoom, string item, Player currentPlayer)
        {
            for (int i = 0; i < currentRoom.Items.Count; i++)
            {
                if (currentRoom.Items[i].Name == item || currentRoom.Items[i].Name.ToLower() == item)
                {
                    System.Console.Clear();
                    currentPlayer.Inventory.Add(currentRoom.Items[i]);
                    currentRoom.Items.Remove(currentRoom.Items[i]);
                }
            }
        }
        public void Look(Room currentRoom)
        {
            System.Console.Clear();
        }
        public void Help()
        {
            System.Console.WriteLine(@"
    go - Go to a room through an exit in the direction that you specify.
    take - Take an item from the current room.
    use - Use an item from your inventory.
    quit - Quit the game.");
        }

    }
}