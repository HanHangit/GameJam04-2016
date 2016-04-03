using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam
{
    class Produkte
    {
        public string name { get; private set; }
        int cost;
        float amount;

        public Produkte(string _name, int _cost)
        {
            amount = 0;
            name = _name;
            cost = _cost;
        }

        public float Holen(float menge)
        {
            if (menge < amount)
            {
                amount -= menge;
                return menge;
            }
            else if (amount > 0)
            {
                amount = 0;
                return amount;

            }
            else
                return 0;
        }

        public override string ToString()
        {
            return name + ": " + (int)amount;
        }

        public void Add(float menge)
        {
            amount += menge;
        }
    }
}
