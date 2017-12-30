using System.Collections.Generic;
using CastleGrimtol;
namespace CastleGrimtol.Project
{
    public class Room : IRoom
    {
        // Item Key = new Item("Key", "It unlocks a door");
        public string Name { get; set; }
        public string Description { get; set; }
        public string LockedMessage { get; set; }
        public string SearchDescription { get; set; }
        public bool Searched { get; set; }
        public Dictionary<string, bool> Locked;
        public List<Item> Items { get; set; }
        public Dictionary<string, Room> Exits;
        public Dictionary<string, Item> SearchableObjects;



        public void UseItem(Item item)
        {

        }
        public void AddItems(Item addedItem)
        {
            Items.Add(addedItem);
        }
        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            SearchDescription = "";
            Searched = false;
            Items = new List<Item>();
            Exits = new Dictionary<string, Room>();
            Locked = new Dictionary<string, bool>();
            SearchableObjects = new Dictionary<string, Item>();
        }

    }
}