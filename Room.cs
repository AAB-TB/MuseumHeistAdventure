using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum_Heist_Adventure
{
    internal class Room : GameObject
    {
        public Dictionary<Direction, List<GameObject>> DirectionToObjects { get; } = new Dictionary<Direction, List<GameObject>>();
        //as all the class inherit from gameobject class thats why list<Gameobject> can stor all of its derived class objects, like item, exitdoors
        public Room(string name, string roomDescription)
        {
            this.Name = name;
            this.Description = roomDescription;
        }

        public void AddExitDoor(Direction direction, ExitDoor exitDoor)
        {
            if (!DirectionToObjects.ContainsKey(direction))
            {
                DirectionToObjects[direction] = new List<GameObject>();
            }

            DirectionToObjects[direction].Add(exitDoor);
        }

        public void AddItem(Direction direction, Item item)
        {
            if (!DirectionToObjects.ContainsKey(direction))
            {
                DirectionToObjects[direction] = new List<GameObject>();
            }

            DirectionToObjects[direction].Add(item);
        }

        public void DisplayObjectsInDirection(Direction direction)
        {
            if (DirectionToObjects.ContainsKey(direction))
            {
                var objects = DirectionToObjects[direction];

                Console.WriteLine($"In the {direction} direction, you have:");

                for (int i = 0; i < objects.Count; i++)
                {
                    if (objects[i] is Item item)
                    {
                        Console.WriteLine($"{i + 1}. {item.Name}: {item.Description}");
                    }
                    else if (objects[i] is ExitDoor exitDoor)
                    {
                        Console.WriteLine($"{i + 1}. {exitDoor.Name}: {exitDoor.Description}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"There are no valuable objects in the {direction} direction.");
            }
        }

    }
}
