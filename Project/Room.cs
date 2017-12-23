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
        public Dictionary<string, bool> Locked;
        public List<Item> Items { get; set; }
        public List<Event> Events { get; set; }
        public Dictionary<string, Room> Exits;
        public Dictionary<string, Room> LockedExits;


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
            Items = new List<Item>();
            Exits = new Dictionary<string, Room>();
            LockedExits = new Dictionary<string, Room>();
            Events = new List<Event>();
            Locked = new Dictionary<string, bool>();
            
        }

    }
}