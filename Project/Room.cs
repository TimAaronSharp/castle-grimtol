using System.Collections.Generic;
using CastleGrimtol;
namespace CastleGrimtol.Project
{
    public class Room : IRoom
    {
        // Item Key = new Item("Key", "It unlocks a door");
        public string Name { get; set; }
        public string Description { get; set; }
        public string DefaultDescription { get; set; }
        public string LockedMessage { get; set; }
        public string SearchDescription { get; set; }
        public bool Searched { get; set; }
        public bool EnemyDescribed { get; set; }
        public List<Item> Items { get; set; }
        public List<Enemy> Enemies { get; set; }
        public Dictionary<string, bool> Locked;
        public Dictionary<string, Room> Exits;
        public Dictionary<string, Item> SearchableObjects;



        public void UseItem(Item item)
        {
            Game Game = new Game();
            switch (Name)
            {
                case "Vault Cave-in 9":
                    switch (item.Name)
                    {
                        case "Terminal":
                            System.Console.WriteLine("Using a cable from the console, you connect your PipBoy and begin to navigate the menus. You eventually find an option to \"Break seal and open Vault door\". You select it with some trepidation. You'll be completely on your own in a brand new world. Your brain is flooded with a mixture of excitement and fear. The cavern is filled with the thunderous chorus of machines coming to life for the first time in centuries. Claxons firing off warnings as machinery moves around. A large mechanical arm descends from the ceiling and inserts itself in to a socket in the middle of the door. You hear some thuds as it clamps itself to the door. Your ears are assaulted by metallic shrieks as the arm starts to pull the door inward and then rolls to the side. You are forced to shield your eyes from the sudden rush of light into the cavern. After a moment they start to adjust and you can make out some features outside. What was that giant blue thing in the sky called? Sky? Living in the vault your whole life you've never seen it before except in books and videos.\n\n\n");
                            Game.EnterToContinue();
                            Description = "Your future awaits you outside the vault to the east. You can also go back west to go further into the cave.\n\n\n";
                            Locked.Remove("e");
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
        public void AddItems(Item addedItem)
        {
            Items.Add(addedItem);
        }
        public void AddEnemy(Enemy addedEnemy)
        {
            Enemies.Add(addedEnemy);
        }
        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            DefaultDescription = Description;
            SearchDescription = "";
            Searched = false;
            EnemyDescribed = false;
            Items = new List<Item>();
            Enemies = new List<Enemy>();
            Exits = new Dictionary<string, Room>();
            Locked = new Dictionary<string, bool>();
            SearchableObjects = new Dictionary<string, Item>();
        }

    }
}