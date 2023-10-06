using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum_Heist_Adventure
{
    internal class Game
    {
        private Character player;
        private Dictionary<string, Room> rooms;
        private Room currentRoom;
        private Dictionary<string, Item> items;
        private Dictionary<string, ExitDoor> exitDoors;

        public Game()
        {
            player = new Character("Agent Smith");
            rooms = new Dictionary<string, Room>();
            items = new Dictionary<string, Item>();
            exitDoors = new Dictionary<string, ExitDoor>();
            InitializeRooms();
        }

        private void InitializeRooms()
        {
            Room Hall = new Room("Hall",
                        @"
            ╔══════════════════════════════════════════════════════════════════════════════════════════╗
            ║                                      Museum Hall                                         ║
            ║                                                                                          ║
            ║ You're inside the Museum Hall, where moonlight softly illuminates the grand space.       ║
            ║ Marble floors stretch out before you, leading to the heart of this intriguing place.     ║
            ║ Your quest for the priceless treasures of the museum begins here.                        ║
            ║                                                                                          ║
            ║ However, there's an obstacle - an imposing 'Iron Door.' Guards stationed around it,      ║
            ║ armed with sniper guns, stand watchful. Their vigilant eyes lock on to your every move.  ║
            ║ You must be stealthy and find the 'Vault Key' to unlock the path to the                  ║
            ║ Secret Vault. Your adventure unfolds as you navigate this  precarious hall, dodging the  ║
            ║ guards, searching for the key that leads to priceless treasures.                         ║             
            ║                                                                                          ║
            ╚══════════════════════════════════════════════════════════════════════════════════════════╝   
                            ");

            Room Vault = new Room("Vault",
                    @"
            ╔═══════════════════════════════════════════════════════════════════════════════════════════╗
            ║                                    Museum Secret Vault                                    ║
            ║                                                                                           ║
            ║ You have successfully entered the Museum Secret Vault, a chamber filled with awe-inspiring║
            ║treasures. Moonlight filters through a grand window, casting an ethereal glow on the       ║
            ║ vault's contents.In this room, you find two masterpieces. One, an exquisite 'Artwork,'    ║
            ║ hangs on the wall, capturing your attention with its beauty and mystery.                  ║
            ║                                                                                           ║
            ║ In the center of the room lies the true gem, a priceless 'Diamond.' It glistens, radiating║
            ║ a sense of wonder. But, your journey is not complete. You must find the elusive           ║             
            ║ 'Golden Key' that promises freedom. Guards stand watchful here as well,so tread carefully.║
            ║ The 'Opulent Door' in this vault promises an exit to the outside world, but it requires   ║
            ║ the 'Golden Key' for access.                                                              ║
            ╚═══════════════════════════════════════════════════════════════════════════════════════════╝ 
                                ");


            rooms.Add(Hall.Name, Hall);
            rooms.Add(Vault.Name, Vault);
           
          
            Item Guard = new Item("Vigilant Guard", "A guard is Monitoring the whole place and the enterance!");
            Item SnipperGun = new Item("Sniper Gun", "Powerful sniper Gun,Nr.1 Barrett M82 (United States) ");
            Item painting = new Item("Painting", "The 'Painting' is an invaluable work of art, a masterpiece that captures the essence of creativity and beauty. Its intricate details and vibrant colors make it a true treasure in the world of art.");
            Item diamond = new Item("Diamond", "The 'Diamond' is the crown jewel of your mission, a priceless gem that has sparked the desires of many. Its flawless facets and dazzling brilliance make it a treasure worth the risks.");

            
            Item VaultKey = new Item("Vault Key", "The 'Vault Key' is a simple yet vital tool, unlocking the entrance to the grand Vault. Its unassuming appearance belies its significance in your journey.");
            Item goldenKey = new Item("Golden Key", "The 'Golden Key' is a symbol of access to the art gallery, a world of elegance and treasures. Its gleaming exterior hints at the wonders it can unlock.");


            items.Add(painting.Name, painting);
            items.Add(VaultKey.Name, VaultKey);
            items.Add(goldenKey.Name, goldenKey);
            items.Add(diamond.Name, diamond);
            items.Add(SnipperGun.Name, SnipperGun);
            items.Add(Guard.Name, Guard);

   
            ExitDoor VaultExit = new ExitDoor("Vault Key", "Iron Door");
            ExitDoor vaultExit = new ExitDoor("Golden Key", "Opulent Door");

            exitDoors.Add(VaultExit.Name, VaultExit);
            exitDoors.Add(vaultExit.Name, vaultExit);

         
            Hall.AddItem(Direction.North, VaultKey);
            Hall.AddItem(Direction.South, SnipperGun);
            Hall.AddItem(Direction.East, Guard);
            Hall.AddExitDoor(Direction.East, VaultExit);


            Vault.AddItem(Direction.North, painting);
            Vault.AddItem(Direction.South, goldenKey);
            Vault.AddExitDoor(Direction.East, vaultExit);
            Vault.AddItem(Direction.West, Guard);
            Vault.AddItem(Direction.Middle, diamond);


        }

       

        public void StartGame()
        {
  
            Console.WriteLine($"            ╔════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine($"            ║                       Welcome to the Museum Heist Adventure!                           ║");
            Console.WriteLine($"            ║You are Agent Alvin, a skilled operative on a mission to retrieve a priceless diamond.  ║");
            Console.WriteLine($"            ║                    Use´help´ to see all the ávailable commands                         ║");
            Console.WriteLine($"            ╚════════════════════════════════════════════════════════════════════════════════════════╝");

            Console.WriteLine(rooms["Hall"].Description);
            Console.WriteLine();


            void Displayhelp()
            {
                Console.WriteLine($"            ╔════════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine($"            ║ Available commands: Use go [direction] (t.x go north, east, west, south, (middle)),    ║");
                Console.WriteLine($"            ║ take [item], use [item] on [item], inspect, inventory, shoot, quit                     ║");
                Console.WriteLine($"            ╚════════════════════════════════════════════════════════════════════════════════════════╝");

            }

            string playerCommand;
            Room currentRoom = rooms["Hall"];


            

            bool iskeyTaken = false;
            bool isGoldenkeyTaken = false;
            bool isGunTaken = false;
            bool isPaintingTaken = false;
            bool isDiamondTaken = false;
            bool isGuardShooted = false;
            bool isVGuardShooted =false;
            bool hasGoneEast = false;
            bool hasVGoneEast = false;
            bool hasGoneNorth = false;
            bool hasVGoneNorth = false;
            bool hasGoneSouth = false;
            bool hasVGoneSouth = false;
            bool hasGoneWest = false;
            bool hasVGoneWest = false;
            bool hasGoneMiddle = false;


            while (currentRoom == rooms["Hall"])
            {

                Console.Write("> ");
                playerCommand = Console.ReadLine().ToLower();
                Console.WriteLine();
                switch (playerCommand)
                {
                    
                    case "help":

                        Displayhelp();
                        break;

                    case "go north":

                        if (hasGoneNorth == false && iskeyTaken == false && currentRoom.DirectionToObjects.ContainsKey(Direction.North))
                        {
                            currentRoom.DisplayObjectsInDirection(Direction.North);
                            hasGoneNorth = true;
                            Console.WriteLine();

                        }
                        else if ((hasGoneNorth == false && iskeyTaken == true || hasGoneNorth == true && iskeyTaken == true) && currentRoom.DirectionToObjects.ContainsKey(Direction.North))
                        {
                            currentRoom.DisplayObjectsInDirection(Direction.North);
                            Console.WriteLine($"But it seems the key named {items["Vault Key"].Name} is already taken.check your inventory");
                            Console.WriteLine();
                        }

                        hasGoneSouth = false;
                        hasGoneEast = false;
                        hasGoneWest = false;
                        break;

                    case "go south":

                        if (hasGoneSouth == false && isGunTaken==false && currentRoom.DirectionToObjects.ContainsKey(Direction.South))
                        {
                            currentRoom.DisplayObjectsInDirection(Direction.South);
                            hasGoneSouth = true;
                            Console.WriteLine();

                        }
                        else if ((hasGoneSouth == false && isGunTaken == true || hasGoneSouth == true && isGunTaken == true) && currentRoom.DirectionToObjects.ContainsKey(Direction.South))
                        {
                            currentRoom.DisplayObjectsInDirection(Direction.South);
                            Console.WriteLine($"But it seems the {items["Sniper Gun"].Name} is already taken.check your inventory");
                            Console.WriteLine();
                        }

                        hasGoneWest = false;
                        hasGoneNorth = false;
                        hasGoneEast = false;
                        break;

                    case "go east":
                        if (hasGoneEast == false && isGuardShooted == false && currentRoom.DirectionToObjects.ContainsKey(Direction.East))
                        {
                            currentRoom.DisplayObjectsInDirection(Direction.East);
                            Console.WriteLine("If you have the sniper gun then shoot the guard.");
                            hasGoneEast = true;
                            Console.WriteLine();

                        }
                        else if (hasGoneEast == false && isGuardShooted == true || hasGoneEast == true && isGuardShooted == true && currentRoom.DirectionToObjects.ContainsKey(Direction.South))
                        {
                            currentRoom.DisplayObjectsInDirection(Direction.East);
                            Console.WriteLine($"You have already killed the guard. the path is clear.");
                            hasGoneEast = true;
                            Console.WriteLine();
                        }

                        hasGoneSouth = false;
                        hasGoneWest = false;
                        hasGoneNorth = false;
                        break;

                    case "go west":

                        currentRoom.DisplayObjectsInDirection(Direction.West);
                        hasGoneSouth = false;
                        hasGoneEast = false;
                        hasGoneNorth = false;
                        Console.WriteLine();
                        break;

                    case "take sniper gun":
                        if (hasGoneSouth == true)
                        {
                            Console.WriteLine($"Well done. SniperGun is yours now!.");
                            player.Inventory.Add(items["Sniper Gun"]);
                            isGunTaken = true;
                            Console.WriteLine();
                        }else if (hasGoneSouth == false && isGunTaken == true)
                        {
                            Console.WriteLine("Sniper gun is already taken!");
                        }
                        else
                        {
                            Console.WriteLine("To get the Sniper Gun you have to go to the place where did you see.");
                            isGunTaken = false;
                            Console.WriteLine();
                        }

                        hasGoneEast = false;
                        hasGoneWest = false;
                        hasGoneNorth = false;
                        break;

                    case "take vault key":

                        if (hasGoneNorth == true)
                        {
                            Console.WriteLine($"Well done. Vault key is taken!.");
                            player.Inventory.Add(items["Vault Key"]);
                            iskeyTaken = true;
                            Console.WriteLine();
                        }else if (hasGoneNorth == false && iskeyTaken == true)
                        {
                            Console.WriteLine("Vault key is already taken!");
                        }
                        else
                        {
                            Console.WriteLine("To get the Vault Key you have to go to the place where did you see.");
                            iskeyTaken = false;
                            Console.WriteLine();
                        }

                        hasGoneEast = false;
                        hasGoneSouth = false;
                        hasGoneWest = false;
                        
                        break;

                    case "use vault key on iron door":

                        if (hasGoneEast == true && iskeyTaken == true && exitDoors["Iron Door"].Unlock(player.Inventory))
                        {
                            Console.WriteLine($"Congratulations! you unlocked the door\n.You have entered in tho the Vault room\n.");
                            player.Inventory.Remove(items["Vault Key"]);
                            currentRoom = rooms["Vault"];

                            if (currentRoom == rooms["Vault"])
                            {
                                
                                VaultRoom(currentRoom, player.Inventory);
                            }
                            else
                            {
                                currentRoom = rooms["Hall"];
                            }

                        }else if (iskeyTaken == false)
                        {
                            Console.WriteLine("You need to find the Key!");
                        }
                        else if (hasGoneEast == false)
                        {
                            Console.WriteLine("you need to find the door.");
                            Console.WriteLine();

                        }

                        break;

                    case "shoot":

                        if (hasGoneEast == true && isGunTaken == true && isGuardShooted == false && player.Inventory.Any(item => item.Name == items["Sniper Gun"].Name))
                        {
                            Console.WriteLine("Shoooooooooooot. The guard is down. well done. Go ahead.");
                            isGuardShooted = true;
                            Console.WriteLine();
                        }
                        else if (isGunTaken == true && isGuardShooted == true && hasGoneEast == true)
                        {
                            Console.WriteLine("You have already killed the guard.");
                        }
                        else
                        {
                            Console.WriteLine("At first take the gun and then Find your target to shoot.");
                            isGuardShooted = false;
                            Console.WriteLine();
                        }

                       
                        hasGoneSouth = false;
                        hasGoneWest = false;
                        hasGoneNorth = false;
                        break;

                    case "inspect":

                        Console.WriteLine(rooms["Hall"].Description);
                        Console.WriteLine();
                        break;

                    case "inventory":

                        player.ListInventory();
                        Console.WriteLine();
                        break;

                    case "quit":

                        Console.WriteLine("Are you sure you want to quit the game? (yes/no)");
                        playerCommand = Console.ReadLine().ToLower();

                        if (playerCommand == "yes")
                        {
                            return;
                        }
                        break;

                    default:

                        Console.WriteLine("wrong command, use help to see the commands");
                        Console.WriteLine();
                        break;

                }

            }




            void VaultRoom(Room room, List<Item> Inventory)
            {

                while (currentRoom == room)
                {
                    Console.Write("> ");
                    playerCommand = Console.ReadLine().ToLower();
                    Console.WriteLine();

                    switch (playerCommand)
                    {
                        case "help":

                            Displayhelp();
                            break;

                        case "go north":

                            if (hasVGoneNorth == false && isPaintingTaken == false && currentRoom.DirectionToObjects.ContainsKey(Direction.North))
                            {
                                currentRoom.DisplayObjectsInDirection(Direction.North);
                                hasVGoneNorth = true;
                                Console.WriteLine();

                            }
                            else if ((hasVGoneNorth == false && isPaintingTaken == true || hasVGoneNorth == true && isPaintingTaken == true) && currentRoom.DirectionToObjects.ContainsKey(Direction.North))
                            {
                                currentRoom.DisplayObjectsInDirection(Direction.North);
                                Console.WriteLine($"But it seems the key named {items["Painting"].Name} is already taken.check your inventory");
                                Console.WriteLine();
                            }

                            hasVGoneSouth = false;
                            hasVGoneEast = false;
                            hasVGoneWest = false;
                            hasGoneMiddle = false;
                            break;

                        case "go south":
                            if (hasVGoneSouth == false && isGoldenkeyTaken == false && currentRoom.DirectionToObjects.ContainsKey(Direction.South))
                            {
                                currentRoom.DisplayObjectsInDirection(Direction.South);
                                hasVGoneSouth = true;
                                Console.WriteLine();

                            }
                            else if ((hasVGoneSouth == false && isGoldenkeyTaken == true || hasVGoneSouth == true && isGoldenkeyTaken == true) && currentRoom.DirectionToObjects.ContainsKey(Direction.South))
                            {
                                currentRoom.DisplayObjectsInDirection(Direction.South);
                                Console.WriteLine($"But it seems the {items["Golden Key"].Name} is already taken.check your inventory");
                                Console.WriteLine();
                            }

                            hasVGoneWest = false;
                            hasVGoneNorth = false;
                            hasVGoneEast = false;
                            hasGoneMiddle = false;
                            break;

                        case "go east":

                            if (currentRoom.DirectionToObjects.ContainsKey(Direction.East))
                            {
                                currentRoom.DisplayObjectsInDirection(Direction.East);
                                hasVGoneEast = true;
                                Console.WriteLine();

                            }
                            

                            hasVGoneSouth = false;
                            hasVGoneWest = false;
                            hasVGoneNorth = false;
                            hasGoneMiddle = false;
                            break;

                        case "go west":

                            if (hasVGoneWest == false  && currentRoom.DirectionToObjects.ContainsKey(Direction.West) && player.Inventory.Any(item => item.Name == "Sniper Gun"))
                            {
                                currentRoom.DisplayObjectsInDirection(Direction.West);
                                Console.WriteLine();
                                Console.WriteLine("Use your Sniper gun and shoot the guard to make your mission risk free. or take the chance!");
                                hasVGoneWest = true;

                            }
                            else if ((hasVGoneWest == true && isVGuardShooted == true || hasVGoneWest == false && isVGuardShooted == true) && currentRoom.DirectionToObjects.ContainsKey(Direction.West))
                            {
                                currentRoom.DisplayObjectsInDirection(Direction.West);
                                Console.WriteLine() ;
                                Console.WriteLine($"You have already killed the guard. the path is clear.");
                            }

                            hasVGoneSouth = false;
                            hasVGoneEast = false;
                            hasVGoneNorth = false;
                            hasGoneMiddle = false;
                            break;

                        case "go middle":

                            if(hasGoneMiddle == false && isDiamondTaken == false && currentRoom.DirectionToObjects.ContainsKey(Direction.Middle))
                            {
                                currentRoom.DisplayObjectsInDirection(Direction.Middle);
                                Console.WriteLine() ;
                                hasGoneMiddle= true;
                            }else if ((hasGoneMiddle == false && isDiamondTaken == true || hasGoneMiddle == true && isDiamondTaken == true) && currentRoom.DirectionToObjects.ContainsKey(Direction.Middle))
                            {
                                Console.WriteLine("You have already go the Diamond. check your inventory!");

                            }
                          
                            hasVGoneSouth = false;
                            hasVGoneEast = false;
                            hasVGoneNorth = false;
                            hasVGoneWest = false;
                            break;

                        case "take painting":
                            if (hasVGoneNorth == true)
                            {
                                Console.WriteLine($"Well done. Painting is yours now!.");
                                player.Inventory.Add(items["Painting"]);
                                isPaintingTaken = true;
                                Console.WriteLine();
                            }
                            else if (hasVGoneNorth == false && isPaintingTaken == true)
                            {
                                Console.WriteLine("Painting is already taken!");
                            }
                            else
                            {
                                Console.WriteLine("To get the painting you have to go to the place where did you see.");
                                isPaintingTaken = false;
                                Console.WriteLine();
                            }

                            hasVGoneEast = false;
                            hasVGoneSouth = false;
                            hasVGoneWest = false;
                            hasGoneMiddle = false;

                            break;

                        case "take golden key":

                            if (hasVGoneSouth == true)
                            {
                                Console.WriteLine($"Well done. Golden key is taken!.");
                                player.Inventory.Add(items["Golden Key"]);
                                isGoldenkeyTaken = true;
                                Console.WriteLine();
                            }
                            else if (hasVGoneSouth == false && isGoldenkeyTaken == true)
                            {
                                Console.WriteLine("Golden key is already taken!");
                            }
                            else
                            {
                                Console.WriteLine("To get the golden Key you have to go to the place where did you see.");
                                isGoldenkeyTaken = false;
                                Console.WriteLine();
                            }

                            hasVGoneEast = false;//
                            hasVGoneWest = false;
                            hasVGoneNorth = false;
                            hasGoneMiddle = false;
                            break;


                        case "use golden key on opulent door":

                            if(hasVGoneEast == true && isGoldenkeyTaken == true && exitDoors["Opulent Door"].Unlock(player.Inventory) && isDiamondTaken == true)
                            {
                                Console.WriteLine((
                                      @"
                                        ════════════════════════════════════════════════════════
                                        ║ Congratulation!You have successfully finished        ║
                                        ║ the mission by finding the final exit and            ║
                                        ║ by having a priceless diamond in your ownership      ║
                                        ║ It was a memorable                                   ║
                                        ║ journey.                                             ║
                                        ════════════════════════════════════════════════════════
                                        "));
                                Console.WriteLine();
                                player.Inventory.Remove(items["Golden Key"]);
                                Console.WriteLine();
                                player.ListInventory();
                                Console.ReadKey();
                                return;
                                

                            }
                            else if (hasVGoneEast == true && isGoldenkeyTaken == true && exitDoors["Opulent Door"].Unlock(player.Inventory))
                            {
                                                    Console.WriteLine((
                                        @"
                                        ═════════════════════════════════════════════════════
                                        ║ You've found the exit. But you failed the mission ║
                                        ║ for not having the Diamond in your ownnership.    ║       
                                        ║ Congratulations! The journey has                  ║
                                        ║ brought you to the final exit - the               ║
                                        ║ ultimate destination.It's a memorable             ║
                                        ║ journey.                                          ║
                                        ══════════════════════════════════════════════════════
                                        "));
                                Console.WriteLine();
                                player.Inventory.Remove(items["Golden Key"]);
                                Console.WriteLine();
                                player.ListInventory();
                                Console.ReadKey();
                                return;
                                
                                
                            } else if (hasVGoneEast == true && isGoldenkeyTaken == false)
                            {
                                Console.WriteLine("You need to find the key!");
                            }
                            else if(hasVGoneEast == false)
                            {
                                Console.WriteLine("you need to find the door.");
                                Console.WriteLine();

                            }
                            break;

                        case "take diamond":

                            if (hasGoneMiddle == true)
                            {
                                Console.WriteLine($"Well done. You got the Diamond!.");
                                player.Inventory.Add(items["Diamond"]);
                                isDiamondTaken = true;
                                Console.WriteLine();
                            }
                            else if (hasGoneMiddle == false && isDiamondTaken == true)
                            {
                                Console.WriteLine("Diamond is already taken!");
                            }
                            else
                            {
                                Console.WriteLine("To get the Diamond you have to go to the place where did you see.");
                                isDiamondTaken = false;
                                Console.WriteLine();
                            }

                            hasVGoneSouth = false;
                            hasVGoneWest = false;
                            hasVGoneNorth = false;
                            
                            break;
                            
                        case "shoot":
                            
                            if (hasVGoneWest == true  && isVGuardShooted == false && player.Inventory.Any(item => item.Name == items["Sniper Gun"].Name))
                            {
                                Console.WriteLine("Shoooooooooooot. The guard is down. well done. Go ahead.");
                                isVGuardShooted = true;
                                Console.WriteLine();
                            }
                            else if (isVGuardShooted == true && hasVGoneWest == true)
                            {
                                Console.WriteLine("You have already killed the guard.");
                            }
                            else
                            {
                                Console.WriteLine("At first take the gun and then Find your target to shoot.");
                                isVGuardShooted = false;
                                Console.WriteLine();
                            }


                            hasVGoneEast = false;
                            hasVGoneSouth = false;
                            hasVGoneNorth = false;
                            hasGoneMiddle = false;
                            break;

                        case "inspect":

                            Console.WriteLine(rooms["Vault"].Description);
                            Console.WriteLine();
                            break;

                        case "inventory":

                            player.ListInventory();
                            Console.WriteLine();
                            break;

                        case "quit":

                            Console.WriteLine("Are you sure you want to quit the game? (yes/no)");
                            playerCommand = Console.ReadLine().ToLower();
                            Console.WriteLine();

                            if (playerCommand == "yes")
                            {
                                return;
                            }
                            break;

                        default:

                            Console.WriteLine("wrong command, use help to see the commands");
                            Console.WriteLine();
                            break;

                    }

                }

            }

        }
            
    }
}
