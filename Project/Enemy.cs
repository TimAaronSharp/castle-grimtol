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
        public string DyingMessage { get; set; }
        public string DeadMessage { get; set; }

        public Enemy(string name, bool pacified, string description, string killMessage, string pacifiedMessage, string dyingMessage, string deadMessage)
        {
            Name = name;
            Pacified = pacified;
            Dead = false;
            Description = description;
            KillMessage = killMessage;
            PacifiedMessage = pacifiedMessage;
            DyingMessage = dyingMessage;
            DeadMessage = deadMessage;
        }
    }
}