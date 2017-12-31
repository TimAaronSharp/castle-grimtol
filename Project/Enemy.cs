using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Enemy
    {

        public string Name { get; set; }
        public bool Pacified { get; set; }
        public bool Dead { get; set; }
        public string Description { get; set; }
        public string PacifiedMessage { get; set; }
        public string KillMessage { get; set; }

        public Enemy(string name, bool pacified, string description, string pacifiedMessage, string killMessage)
        {
            Name = name;
            Pacified = pacified;
            Dead = false;
            Description = description;
            PacifiedMessage = pacifiedMessage;
            KillMessage = killMessage;

        }
    }
}