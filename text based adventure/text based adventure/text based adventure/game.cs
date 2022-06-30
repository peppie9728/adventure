using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_based_adventure
{
    class game
    {
        Location currentLocation;
        public bool isRunning = true;
        private bool _gameOver = false;
        private List<Item> inventory;
        private int health = 40;
        private int strength = 40;
        private int intel = 30;

        public game()
        {

            Console.WriteLine("phone:'You better get back with the diamond or you are in big trouble'");
            Console.WriteLine("*phone call ends*");
            Console.WriteLine();
            Console.WriteLine("f*ck now i have to get those diamonds. imma get ready real quick");
            Console.WriteLine();
            Console.WriteLine("Press 'h' or type 'help' for help.");
            Console.WriteLine();

            inventory = new List<Item>();
            
            //make locations and items
            Location l1 = new Location("street","thorpelane 313, enfront of a small appartment complex",false,0);
            
            Item pistol = new Item(1,"pistol",true, "boem grote gannoe neef",1);
            Item key = new Item(1909,"key",true,"just an ordinary key",2);
            Item bandage = new Item(5,"bandage",true,"this can be used to heal yourself",4);
            Item Lockpick = new Item(9,"lockpick",true,"a lockpick used to crack safes",5);
            Item jonko = new Item(10,"jonko",true,"Baap",4);
            jonko.ChangeConsume(1,100); 
            bandage.ChangeConsume(1,70);
            Item smakois = new Item(6,"smakois",true,"a bag of smakois, cheeseflavoured chips",4);
            
            Location l2 = new Location("De punt","wacke plek",true,1909);
            
            Item mafioso = new Item(3,"ids",false, "een fries persoon uit haren",1);

            Item safe = new Item(8, "safe", true, "a small safe probably containing the diamond.",5);

            Location l3 = new Location("living room","its a small room barely any windows",true,2000);

            
            

            currentLocation = l1;
            l1.AddExit(l2);
            inventory.Add(bandage);
            inventory.Add(pistol);
            inventory.Add(key);
            l2.AddExit(l1);
            l2.AddItem(mafioso);
            l3.AddItem(safe);
            l2.AddExit(l3);
            l3.AddExit(l2);

            showLocation();
        }

        public void showLocation()
        {
            Console.WriteLine("You're at");
            Console.WriteLine("\n" + currentLocation.Name + "\n");
            Console.WriteLine(currentLocation.roomDescription);

            if (currentLocation.getInventory().Count > 0)
            {
                Console.WriteLine("\nThe room contains the following:\n");

                for (int i = 0; i < currentLocation.getInventory().Count; i++)
                {
                    Console.WriteLine(currentLocation.getInventory()[i].Name);
                }
            }

            Console.WriteLine("\nAvailable Exits: \n");

            foreach (Location exit in currentLocation.getExits())
            {
                Console.WriteLine(exit.Name);
            }

            Console.WriteLine();
        }

        public void ShowStats()
        {
            Console.WriteLine("");
            Console.WriteLine("your health is currently: "+ health);
            Console.WriteLine("your strength is currently: " + strength);
            Console.WriteLine("your intelligence is currently: " + intel);

        }




        public void doAction(string command)
        {
            //Help command is NEW
            if (command == "help" || command == "h")
            {
                Console.WriteLine("Welcome to this Text Adventure!");
                Console.WriteLine("");
                Console.WriteLine("'go Location':       attempts to go to specified location.");
                Console.WriteLine("'use x':             attempts to use an item where x is the item youre using.");
                Console.WriteLine("'pick up x':         Attempts to pick up an item, where X is the items name.");
                Console.WriteLine("'inspect x':         Attempts to inspect an item, where x is the items name");
                Console.WriteLine("'look':              Looks around the room.");
                Console.WriteLine("'stats':             Shows your health, strength and inteligence.");
                Console.WriteLine("'i' / 'inventory':   Allows you to see the items in your inventory.");
                Console.WriteLine("'q' / 'quit':        Quits the game.");
                Console.WriteLine();
                return;
            }

            if (command == "look")
            {
                showLocation();
                Console.WriteLine();
            }

            if (command == "stats")
            {
                ShowStats();
            }

            if (command.Length >= 2 && command.Substring(0, 3) == "go ")
            {
                Console.WriteLine("");
                foreach (Location loc in currentLocation.getExits())
                {

                    if (loc.Name.ToLower() == command.Substring(3) && loc.Locked == false)
                    {
                        currentLocation = loc;
                        showLocation();
                    }
                    else if (loc.Name.ToLower() == command.Substring(3) && loc.Locked == true)
                    {
                        Console.WriteLine("It looks like the door is locked.");
                        if (inventory.Count > 0)
                        {
                            int o = 0;
                            foreach (Item y in inventory)
                            {
                                if (y.Type == 2)
                                {
                                    o++;
                                }
                            }
                            if (o > 0)
                            {
                                Console.WriteLine("Maybe i have something in my bag that can open the door.");
                                showInventory();
                                string input = Console.ReadLine();
                                foreach (Item y in inventory)
                                {
                                    if (input == y.Name)
                                    {
                                        if (loc.RoomKeyID == y.Id)
                                        {
                                            Console.WriteLine("The lock opens, you enter " + loc.Name);
                                            currentLocation = loc;
                                            showLocation();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("maybe there's something that can open this");
                            }
                        }
                        else
                        {
                            Console.WriteLine("maybe there's something that can open this");
                        }
                    }
                }
            }
            
            if (command.Length >= 3 && command.Substring(0, 3) == "use")
            {
                Console.WriteLine("");
                string[] reader = command.Split(" ");
                
                if (command == "use")
                {
                    Console.WriteLine("please specify what you want to use");
                }
                else if ( reader.Length > 1)  {
                    
                    foreach (Item i in inventory)
                    {
                        if (i.Name.ToLower() == command.Substring(4).ToLower()) 
                        {
                            switch (i.Type)
                            {
                                case 1:
                                    
                                    Console.WriteLine("What do you want to use "+ i.Name +" on?");
                                    Console.WriteLine("");
                                    foreach (Item item in currentLocation.getInventory())
                                    {
                                        if (item.Type == i.Type)
                                        {
                                            Console.WriteLine(item.Name);
                                            Console.WriteLine("");
                                        }
                                    }

                                    string input = Console.ReadLine();

                                    
                            
                                    foreach (Item i1 in currentLocation.getInventory())
                                    {
                                        if (i1.Name == input)
                                        {
                                            if (i.Type == i1.Type)
                                            {
                                                Console.WriteLine("good job you killed " + i1.Name+ ".");
                                                i1.ChangeName("a dead "  + i1.Name ,i1.Description + " but dead.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("u cant attack " + i1.Name);
                                            }
                                        }
                                    }

                                    break;

                                case 2:

                                    Console.WriteLine("Maybe i can use this on a door.");
                                    break;

                                case 3:

                                    foreach (Item i1 in currentLocation.getInventory())
                                    {
                                        if (i1.Name == command.Substring(4).ToLower())
                                        {
                                            if (i.Type == i1.Type)
                                            {
                                                Console.WriteLine("good job you killed ids");
                                            }
                                        }
                                    }

                                    break;

                                case 4:

                                    
                                        if (i.Name.ToLower() == command.Substring(4).ToLower())
                                        {
                                            switch (i.Consume)
                                            {
                                                
                                            case 0:

                                                Console.WriteLine("this item is useless!");
                                                    
                                                break;
                                                
                                            case 1:

                                                if (health + i.ConsumeStrength <= 100)
                                                {
                                                    health = health + i.ConsumeStrength;
                                                    currentLocation.takeItem(i.Name);
                                                    Console.WriteLine("you've consumed a " + i.name);
                                                    ShowStats();
                                                }
                                                else if (health + i.ConsumeStrength > 100)
                                                {
                                                    Console.WriteLine("If you use this item it won't be used fully");
                                                    Console.WriteLine("Because your health is already high.");
                                                    Console.WriteLine("Do you still want to use it?(y/n)");
                                                    string input1 = Console.ReadLine();
                                                    if (input1 == "y")
                                                    {
                                                        health = 100;
                                                        currentLocation.takeItem(i.Name);
                                                        Console.WriteLine("you've consumed a " + i.name);
                                                        ShowStats();
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("you put your "+ i.Name + " back in your bag");
                                                    }
                                                }

                                                    
                                                break;
                                            case 2:

                                                if (health + i.ConsumeStrength <= 100)
                                                {
                                                    health = health + i.ConsumeStrength;
                                                    currentLocation.takeItem(i.Name);
                                                    Console.WriteLine("you've consumed a " + i.name);
                                                    ShowStats();
                                                }
                                                else if (health + i.ConsumeStrength > 100)
                                                {
                                                    Console.WriteLine("If you use this item it won't be used fully");
                                                    Console.WriteLine("Because your health is already high.");
                                                    Console.WriteLine("Do you still want to use it?(y/n)");
                                                    string input1 = Console.ReadLine();
                                                    if (input1 == "y")
                                                    {
                                                        health = 100;
                                                        currentLocation.takeItem(i.Name);
                                                        Console.WriteLine("you've consumed a " + i.name);
                                                        ShowStats();
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("you put your " + i.Name + " back in your bag");
                                                    }
                                                }


                                                break;

                                            case 3:

                                                if (intel + i.ConsumeStrength <= 100)
                                                {
                                                    intel = intel + i.ConsumeStrength;
                                                    currentLocation.takeItem(i.Name);
                                                    Console.WriteLine("you've consumed a " + i.name);
                                                    ShowStats();
                                                }
                                                else if (intel + i.ConsumeStrength > 100)
                                                {
                                                    Console.WriteLine("If you use this item it won't be used fully");
                                                    Console.WriteLine("Because your health is already high.");
                                                    Console.WriteLine("Do you still want to use it?(y/n)");
                                                    string input1 = Console.ReadLine();
                                                    if (input1 == "y")
                                                    {
                                                        intel = 100;
                                                        currentLocation.takeItem(i.Name);
                                                        Console.WriteLine("you've consumed a " + i.name);
                                                        ShowStats();
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("you put your " + i.Name + " back in your bag");
                                                    }
                                                }


                                                break;

                                        }

                                                
                                        
                                        }
                                    

                                    break;


                                case 5:

                                    Console.WriteLine("What do you want to use " + i.Name + " on?");
                                    Console.WriteLine("");
                                    foreach (Item item in currentLocation.getInventory())
                                    {
                                        if (item.Type == i.Type)
                                        {
                                            Console.WriteLine(item.Name);
                                            Console.WriteLine("");
                                        }
                                    }

                                    string input2 = Console.ReadLine();



                                    foreach (Item i1 in currentLocation.getInventory())
                                    {
                                        if (i1.Name == input2)
                                        {
                                            if (i.Type == i1.Type)
                                            {
                                                Console.WriteLine("good job you stole the diamond now run!");
                                                
                                            }
                                            else
                                            {
                                                Console.WriteLine("u cant attack " + i1.Name);
                                            }
                                        }
                                    }


                                    break;
                            }
                        }
                    }
                    





                }
 }
            
            if (command == "inventory" || command == "i")
            {
                Console.WriteLine();
                showInventory();
                
                return;
            }
            
            if (command.Length >= 7 && command.Substring(0, 7) == "pick up")
            {
                Console.WriteLine();
                string i = command.Substring(8);
                
                
                foreach (Item i1 in currentLocation.getInventory())
                {
                    
                    if (i1.name == i && i1.Useable == true)
                    {
                        inventory.Add(currentLocation.takeItem(i));
                        Console.WriteLine("you picked up " + i1.name + ".");
                    }
                    else if (i1.name == i && i1.Useable == false) 
                    {
                        Console.WriteLine("You cant pick this item up.");
                    }
                }
            }
        
            if (command.Length >= 7 && command.Substring(0, 7) == "inspect")
            {
                Console.WriteLine();
                if (command == "inspect")
                {
                    
                    Console.WriteLine("Please specify what you would like to use?");
                }
            }
        }
        public void showInventory()
        {
            if (inventory.Count > 0)
            {
                Console.WriteLine("\nA quick look in your bag reveals the following:\n");

                foreach (Item item in inventory)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else
            {
                Console.WriteLine("\nYour bag is empty.\n");
            }
        }

        
        public void Update()
        {
            string currentCommand = Console.ReadLine().ToLower();

            // instantly check for a quit
            if (currentCommand == "quit" || currentCommand == "q")
            {
                isRunning = false;
                return;
            }


            if (!_gameOver)
            {
                // otherwise, process commands.
                doAction(currentCommand);
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("\nNope. Time to quit.\n");
            }
        }
    }
}