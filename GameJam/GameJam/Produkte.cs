using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam
{
    class Produkte
    {
        string name;
        Ressource[] ressources;
        Produkte[] produkte;
        int cost;
        float amount;

        public Produkte(string _name, int _cost)
        {
            amount = 0;
            name = _name;
            cost = _cost;
        }

        public override string ToString()
        {
            return name + ": " + amount;
        }
    }
}
