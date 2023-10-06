using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum_Heist_Adventure
{
    internal class Character : GameObject
    {
        public List<Item> Inventory { get; } = new List<Item>();


        public Character(string name)
        {
            this.Name = name;
        }

        public void AddItem(Item item)
        {
            Inventory.Add(item);
        }

        public void RemoveItem(Item item)
        {
            Inventory.Remove(item);
        }

        public void ListInventory()
        {
            Console.WriteLine("Inventory:");

            for (int i = 0; i < Inventory.Count; i++)
            {
                if (Inventory[i] is Item item)
                {
                    Console.WriteLine($"{i + 1}. {item.Name}");
                }
            }
        }




    }
}
