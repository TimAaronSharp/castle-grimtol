using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Enemy
    {

        public string Name { get; set; }
        public bool Pacified { get; set; }
        public string KillMessage { get; set; }

        public Enemy(string name, bool pacified, string killMessage)
        {
            Name = name;
            Pacified = pacified;
            KillMessage = killMessage;
        }
    }
}