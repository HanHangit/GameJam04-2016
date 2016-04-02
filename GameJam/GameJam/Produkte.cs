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

        public Produkte(string _name,Ressource[] _ressources, Produkte[] _produkte, int _cost)
        {
            amount = 0;
            name = _name;
            ressources = _ressources;
            produkte = _produkte;
            cost = _cost;
        }
    }
}
