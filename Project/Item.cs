using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Item : IItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string DescriptionInRoom { get; set; }
        public bool Takeable { get; set; }
        public string Direction { get; set; }

        public Item(string name, string description, string type, string descriptionInRoom, bool takeable)
        {
            Name = name;
            Description = description;
            Type = type;
            DescriptionInRoom = descriptionInRoom;
            Takeable = takeable;
        }

    }
}