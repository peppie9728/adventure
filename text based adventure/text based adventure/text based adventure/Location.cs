using System;
using System.Collections.Generic;
using System.Text;

namespace text_based_adventure
{
    class Location
    {
        public int roomKeyID;
        public string roomName;
        public string roomDescription;
        public bool locked;
        private List<Location> exits;
        private List<Item> inventory;

        public Location()
        {
            // Blank out the title and description at start
            roomName = "";
            roomDescription= "";
            exits = new List<Location>();
            inventory = new List<Item>();
        }

        public Location(string title, string description,bool locked1,int ID)
        {
            roomKeyID = ID;
            roomName = title;
            roomDescription = description;
            locked = locked1;
            exits = new List<Location>();
            inventory = new List<Item>();

        }
        public string Name
        {
            get { return roomName; }
        }
        
        public string RoomDescription
        {
            get { return roomDescription; }
        }
        
        public bool Locked
        {
            get { return locked; }
        }

        public int RoomKeyID
        {
            get { return roomKeyID; }
        }
        public void AddExit(Location exit)
        {
            exits.Add(exit);
        }
        public void removeExit(Location exit)
        {
            if (exits.Contains(exit))
            {
                exits.Remove(exit);
            }
        }
        public List<Location> getExits()
        {
            return new List<Location>(exits);
        }

        public List<Item> getInventory()
        {
            return new List<Item>(inventory);
        }

        public void AddItem(Item item) 
        {
            inventory.Add(item);
        }

        public Item takeItem(string name)
        {
            foreach (Item _item in inventory)
            {
                if (_item.Name.ToLower() == name)
                {
                    Item temp = _item;
                    inventory.Remove(temp);
                    return temp;
                }
            }

            return null;
        }
    }
}
