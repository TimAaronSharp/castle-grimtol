using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Enemy
    {
        Random rnd = new Random();

        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }

        public Enemy(string name, int health, int damageMin, int damageMax)
        {
            Name = name;
            Health = health;
            Damage = rnd.Next(damageMin, damageMax);
        }
    }
}