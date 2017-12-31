using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Build
    {
        public List<Item> BuildItems()
        {
            List<Item> ItemList = new List<Item>();
            #region Constructing items
            Item bronzeKey = new Item("Bronze Key", "It's a bronze key", "Key", " There is a bronze key on the floor.");
            Item pipBoy = new Item("PipBoy", "Your handy dandy PipBoy!", "Upgrade", " The light is coming from the other side of the cavern. As you walk closer you can see that it is coming from a PipBoy attached to the arm of a skeleton. The color is different with the green light shining on it, but you'd recognize it's clothes anywhere as a Vault suit. On closer inspection of the skull you see a hole on the right, lined up with another on it's left.");
            Item pistol = new Item("Pistol", "Large pistol that shoots 10mm bullets", "Weapon", " In it's hand, resting on the ground, you see it holding a bulky pistol.");
            Item ammo = new Item("Ammo", "It's Ammo", "Ammo", " Inside Vault Dweller's belongings you come across a box of ammo. This would come in handy.");
            Item rock = new Item("Rock","A baseball-sized rock.","Rock"," On the ground you see several baseball-sized rocks.");
            #endregion

            #region Assigning directions for keys to be associated with
            bronzeKey.Direction = "e";
            #endregion

            #region Adding items to list to pass as argument
            ItemList.Add(bronzeKey);
            ItemList.Add(pipBoy);
            ItemList.Add(pistol);
            ItemList.Add(ammo);
            ItemList.Add(rock);
            #endregion

            return ItemList;
        }
        public List<Enemy> BuildEnemies()
        {
            List<Enemy> EnemyList = new List<Enemy>();
            Enemy radscorpionRoom7 = new Enemy("Radscorpion", false, "As you move into the room you accidently kick a rock. The radscorpion turns your direction with a hiss, clicking it's claws, rushing toward you. You turn to run but before you get far you feel a sharp pain in each arm as the radscorpion's claws clamp down, their hooks sinking in and holding you firm. Next you feel as though several burning knives are stabbed in your back as the radscorpion stings you several times in the back with it's venomous stinger. Soon the hot pain begins to dull to a soft warmth as your body starts to numb and your conciousness fades.");
            EnemyList.Add(radscorpionRoom7);
            return EnemyList;
        }
        public List<Room> BuildRooms(List<Item> itemList, List<Enemy> enemyList)
        {
            List<Room> AllRooms = new List<Room>();
            #region Building rooms

            Room room1 = new Room("Vault Cave-in 1", "There is a cave-in on the west side of the cavern. Looking at it fills you with resolve to find a new home for your family.");
            Room room2 = new Room("Vault Cave-in 2", "There is a cave-in to the east. This was likely the way to the exit. You feel a sting of discouragement. You'll have to find another way.");
            Room room3 = new Room("Vault Cave-in 3", "You find yourself in a narrow corridor with just barely enough room for you to fit through. It's getting darker the further into the cave you go.");
            Room room4 = new Room("Vault Cave-in 4", "The cavern is almost pitch black here. You can see a light coming from the east.");
            Room room5 = new Room("Vault Cave-in 5", " ");
            Room room6 = new Room("Vault Cave-in 6", "Congrats! Room 6!");
            // Room room7 = new Room("Vault Cave-in 7",);

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
            #endregion

            #region Adding locks to rooms
            room2.Locked.Add("s", true);
            room4.Locked.Add("s", true);
            room4.Locked.Add("w", true);
            #endregion

            #region Creating lock messages
            room2.LockedMessage = "Go where?";
            room4.LockedMessage = "It's too dark to see anything in that direction.";
            #endregion

            #region Creating search descriptions
            room2.SearchDescription = " It's so small that you almost missed it, but you notice a narrow passageway to the south.";
            #endregion

            #region Assigning items from itemList by name for easier readability
            Item bronzeKey = itemList[0];
            Item pipBoy = itemList[1];
            Item pistol = itemList[2];
            Item ammo = itemList[3];
            Item rock = itemList[4];
            #endregion

            #region Assigning enemies from enemyList by name for easier readability
            Enemy radscorpionRoom7 = enemyList[0];
            #endregion

            #region Adding items to rooms
            // room2.AddItems(bronzeKey);
            room5.AddItems(pipBoy);
            room5.AddItems(pistol);
            #endregion

            #region Adding enemies to rooms
            #endregion

            #region Adding dictionaries to room searchable objects
            room1.SearchableObjects.Add("Room", rock);
            room5.SearchableObjects.Add("Skeleton", ammo);
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