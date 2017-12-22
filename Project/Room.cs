using System.Collections.Generic;
using CastleGrimtol;
namespace CastleGrimtol.Project
{
    public class Room : IRoom
    {
        Item Key = new Item("Key", "It unlocks a door");
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }
        public Dictionary<string, Room> Exits;
        
        
        public void UseItem(Item item)
        {

        }
        public void AddItems(Item addedItem){
            Items.Add(addedItem);
        }
        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            Items = new List<Item>();
            Exits = new Dictionary<string, Room>();

        }

    }
}