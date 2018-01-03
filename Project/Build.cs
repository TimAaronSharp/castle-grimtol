using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Build
    {
        public List<Item> BuildItems()
        {
            List<Item> ItemList = new List<Item>();
            #region Constructing items
            // Item bronzeKey = new Item("Bronze Key", "It's a bronze key", "Key", " There is a bronze key on the floor.", "", true);
            Item pipBoy = new Item("PipBoy", "Your handy dandy PipBoy!", "Upgrade", " The light is coming from the other side of the cavern. As you walk closer you can see that it is coming from a PipBoy attached to the arm of a skeleton. The color is different with the green light shining on it, but you'd recognize it's clothes anywhere as a Vault suit. On closer inspection of the skull you see a hole on the right, lined up with another on it's left.", "", true);
            Item pistol = new Item("Pistol", "Large pistol that shoots 10mm bullets", "Weapon", " In it's hand, resting on the ground, you see it holding a bulky pistol.", "You never had much experience with guns living in the Vault. You excitedly look it over, examining every part of it. You look down the barrel of the gun to see what it looks like inside. Your thumb accidently pulls the trigger. ", true);
            Item ammo = new Item("Ammo", "It's Ammo", "Ammo", " Inside Vault Dweller's belongings you come across a box of ammo. This would come in handy.", "", true);
            Item rock = new Item("Rock", "A baseball-sized rock.", "Rock", "On the ground you see several baseball-sized rocks.", "You threw the rock as hard as you could and it shattered against the wall.", true);
            Item terminal = new Item("Terminal", "A terminal that operates the Vault door", "Termimal", " Pipes and valves line the walls of the room. You see a command terminal to your right.", "", false);
            #endregion

            #region Adding items to list to pass as argument
            ItemList.Add(pipBoy);
            ItemList.Add(pistol);
            ItemList.Add(ammo);
            ItemList.Add(rock);
            ItemList.Add(terminal);
            #endregion

            return ItemList;
        }
        public List<Enemy> BuildEnemies()
        {
            List<Enemy> EnemyList = new List<Enemy>();
            //string NAME, bool PACIFIED, string DESCRIPTION, string KILLMESSAGE, string PACIFIEDMESSAGE, string DYINGMESSAGE, string DEADMESSAGE
            Enemy radscorpionRoom7 = new Enemy(/*NAME*/"Radscorpion",/*PACIFIED*/false, /*DESCRIPTION*/" You see something large in the distance moving around slowely. Your PipBoy identifies it as a radscorpion: a giant, mutated scorpion that is almost always larger than an adult human, with potent venom.",
            /*KILLMESSAGE*/" The radscorpion turns your direction with a hiss, clicking it's claws, rushing toward you. You turn to run but before you get far you feel a sharp pain in each arm as the radscorpion's claws clamp down, their hooks sinking in and holding you firm. Next you feel as though several burning knives are stabbed in your back as the radscorpion stings you several times in the back with it's venomous stinger. Soon the hot pain begins to dull to a soft warmth as your body starts to numb and your conciousness fades.",
            /*PACIFIEDMESSAGE*/"You throw the rock past the radscorpion. It bounces on the ground, the noise it makes is several times louder from the echo. The radscorpion turns it that direction with a hiss and charges off to invesitgate.",
            /*DYINGMESSAGE*/"You take aim at the radscorpion with the pistol and fire. It recoils, turns your way with an angry hiss, and charges you. You fire off several more shots, not all bullets finding their mark. Fear starts to overcome you as the radscorpion closes in on you, then finally it crumples in a heap on the ground, twitching violently, then slowely stills. You remember to start breathing again and start taking several deep gulps of air. You take a moment to let the adrenaline fade through your system and for your nerves to calm.",
            /*DEADMESSAGE*/" The radscorpion lies dead on the ground.");
            EnemyList.Add(radscorpionRoom7);
            return EnemyList;
        }
        public List<Room> BuildRooms(List<Item> itemList, List<Enemy> enemyList)
        {
            List<Room> AllRooms = new List<Room>();
            #region Building rooms

            Room room1 = new Room("Vault Cave-in 1", "There is a cave-in on the west side of the cavern. Looking at it fills you with resolve to find a new home for your family. The only way to go is east. Debris litters the floor.");
            Room room2 = new Room("Vault Cave-in 2", "There is a cave-in to the east. This was likely the way to the exit. You feel a sting of discouragement. You'll have to search for another way.");
            Room room3 = new Room("Vault Cave-in 3", "You find yourself in a narrow corridor with just barely enough room for you to fit through. It's getting darker the further into the cave you go. You can continue north or south.");
            Room room4 = new Room("Vault Cave-in 4", "The cavern is almost pitch black here. The sounds of various cave creatures scurrying around that you can't see makes you uneasy. You can see a light coming from the east.");
            Room room5 = new Room("Vault Cave-in 5", "");
            Room room6 = new Room("Vault Cave-in 6", "The passageway curves. Water slowely drips rhythmically from a stalactite hanging from the ceiling, the sound echoing loudly. There are paths to the north and east.");
            Room room7 = new Room("Vault Cave-in 7", "The passageway opens up to a large cavern. You see exits on the north and west.");
            Room room8 = new Room("Vault Cave-in 8", "There is a cave-in on the west side of the cavern. You think it is probably the cave-in that blocked your way when you started. You look at it with a mix of irritation for lengthening your escapse and putting you in more danger, and relief at knowing you've passed that obstacle. There are passageways south and east. Debris litters the floor.");
            Room room9 = new Room("Vault Cave-in 9", "You finally see it on the east side of the cavern. Looming over you is a giant, metal, gear shaped door. You can feel it. You're so close! You can go west to return further into the cave.");
            Room room10 = new Room("Surface", "");

            #endregion

            #region Adding exits to rooms
            room1.Exits.Add("e", room2);
            room2.Exits.Add("w", room1);
            room2.Exits.Add("s", room3);
            room3.Exits.Add("n", room2);
            room3.Exits.Add("s", room4);
            room4.Exits.Add("n", room3);
            room4.Exits.Add("e", room5);
            room4.Exits.Add("s", room6);
            room5.Exits.Add("w", room4);
            room6.Exits.Add("n", room4);
            room6.Exits.Add("e", room7);
            room7.Exits.Add("w", room6);
            room7.Exits.Add("n", room8);
            room8.Exits.Add("s", room7);
            room8.Exits.Add("e", room9);
            room9.Exits.Add("w", room8);
            room9.Exits.Add("e", room10);


            #endregion

            #region Adding locks to rooms
            room2.Locked.Add("s", true);
            room4.Locked.Add("s", true);
            room4.Locked.Add("w", true);
            room9.Locked.Add("e", true);
            #endregion

            #region Creating lock messages
            room2.LockedMessage = "Go where?";
            room4.LockedMessage = "It's too dark to see anything in that direction.";
            room9.LockedMessage = "The Vault door is still closed.";
            #endregion

            #region Creating search descriptions
            room2.SearchDescription = " It's so small that you almost missed it, but you notice a narrow passageway to the south.";
            room5.SearchDescription = "There is a skeleton leaning against the wall.";
            #endregion

            #region Assigning items from itemList by name for easier readability
            Item pipBoy = itemList[0];
            Item pistol = itemList[1];
            Item ammo = itemList[2];
            Item rock = itemList[3];
            Item terminal = itemList[4];
            #endregion

            #region Assigning enemies from enemyList by name for easier readability
            Enemy radscorpionRoom7 = enemyList[0];
            #endregion

            #region Adding items to rooms
            // room2.AddItems(bronzeKey);
            room5.AddItems(pipBoy);
            room5.AddItems(pistol);
            room9.AddItems(terminal);
            #endregion

            #region Adding enemies to rooms
            room7.AddEnemy(radscorpionRoom7);
            #endregion

            #region Adding dictionaries to room searchable objects
            room1.SearchableObjects.Add("Room", rock);
            room5.SearchableObjects.Add("Skeleton", ammo);
            room8.SearchableObjects.Add("Room", rock);
            #endregion

            #region Adding rooms to AllRooms list
            AllRooms.Add(room1);
            AllRooms.Add(room2);
            AllRooms.Add(room3);
            AllRooms.Add(room4);
            AllRooms.Add(room5);
            AllRooms.Add(room6);
            #endregion

            return AllRooms;
        }
    }
}