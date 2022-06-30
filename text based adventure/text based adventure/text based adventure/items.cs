using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_based_adventure
{
    class Item
    {
        public int id;
        public string name;
        private bool useable;
        private string description;
        private int type;
        private int consumeable;
        private int consumeStrength;

        public Item(int _id, string _name, bool canUse, string _description, int _type)
        {
            id = _id;
            name = _name;
            useable = canUse;
            description = _description;
            type = _type;
            consumeable = 0;
        }

        public void ChangeName(string input, string input1)
        {
            name = input;
            description = input1;
        }

        public void ChangeConsume(int input,int input1)
        {
            consumeable = input;
            consumeStrength = input1;
        }

        public int Consume
        {
            get { return consumeable; }
        }

        public int ConsumeStrength
        {
            get { return consumeStrength; }
        }

        public int Id
        {
            get { return id; }
        }
        
        public string Name
        {
            get { return name; }
        }

        public bool Useable
        {
            get { return useable; }
        }

        public string Description
        {
            get { return description; }
        }
        public int Type
        {
            get { return type;}
        }
    }
}