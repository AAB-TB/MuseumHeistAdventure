using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum_Heist_Adventure
{
    internal class ExitDoor: GameObject
    {
        private string requiredKey;


        public ExitDoor(string key, string name)
        {
            requiredKey = key;
            this.Name = name;
        }

        public bool Unlock(List<Item> inventory)
        {
            return inventory.Any(item => item.Name == requiredKey);
        }
    }
}
