using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool Alive { get; set; }
        public int Score { get; set; }
        public string Gender { get; set; }
        public List<Item> Inventory { get; set; }
        public string RestartText { get; set; }

        public Player(string name, string lastName, string gender, List<Item> inventory, bool alive)
        {
            Name = name;
            LastName = lastName;
            Inventory = inventory;
            Alive = alive;
            Gender = "NA";
            Gender = gender;
            RestartText = "You have died. Would you like to play again? (Y/N): ";
        }
        public Room Go(Player currentPlayer, Room currentRoom, string direction)
        {
            bool isAlive = true;
            Event Event = new Event("event", true);
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
                isAlive = Event.DangerCheck(currentPlayer, currentRoom);
                if (isAlive)
                {
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
            for (int i = 0; i < currentRoom.Items.Count; i++)
            {
                if (currentRoom.Items[i].Name.ToLower() == item)
                {
                    System.Console.Clear();
                    currentPlayer.Inventory.Add(currentRoom.Items[i]);
                    currentRoom.Items.Remove(currentRoom.Items[i]);
                }
            }
        }
        public void Look(Room currentRoom)
        {
            System.Console.WriteLine(currentRoom.Name);
            System.Console.WriteLine(currentRoom.Description);
        }
        public void Search(Room currentRoom, string option)
        {
            if (currentRoom.SearchableObjects.Count > 0)
            {
                foreach (var keyword in currentRoom.SearchableObjects)
                {
                    string searchable = keyword.Key.ToLower();
                    if (searchable == option)
                    {
                        currentRoom.Items.Add(currentRoom.SearchableObjects[keyword.Key]);
                        currentRoom.SearchableObjects.Remove(keyword.Key);
                        if (option == "room")
                        {
                            currentRoom.Searched = true;
                        }
                        return;
                    }
                }
            }
            if (option != "" || option != " ")
            {
                switch (option)
                {
                    case "room":
                        if (currentRoom.Searched == true)
                        {
                            System.Console.WriteLine("You've already searched this room.");
                        }
                        else if (currentRoom.Searched == false)
                        {
                            currentRoom.Description += currentRoom.SearchDescription;
                            currentRoom.Searched = true;
                        }
                        else if (currentRoom.SearchDescription == "")
                        {
                            System.Console.WriteLine("There is nothing notable in this room.");
                        }
                        return;
                }
            }
            else
            {
                System.Console.WriteLine("Search what?");
            }
        }
        public void UseItem(Player currentPlayer, Room currentRoom, Item item)
        {
            switch (item.Type)
            {
                case "Key":
                    System.Console.WriteLine("Hey you used a key brah!");

                    currentRoom.Locked.Remove(item.Direction);
                    currentPlayer.Inventory.Remove(item);
                    break;
                default:
                    break;
            }
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