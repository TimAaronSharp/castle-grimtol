using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Event
    {
        public string Name { get; set; }

        public bool Events { get; set; }


        public Event(string name, bool events)
        {
            Name = name;
            Events = events;
        }

    }
}