using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum_Heist_Adventure
{
    internal class Item : GameObject
    {
        public Item(string name, string description)
        {

            this.Name = name;
            this.Description = description;
        }
    }
}
