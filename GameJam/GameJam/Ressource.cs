using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace GameJam
{
    class Ressource
    {
        public string name { get; private set; }
        float amount;
        static Random rnd = new Random();

        public Ressource(int type)
        {
            name = MapSettings.ressourcesName[type];
            amount = rnd.Next(100, 500);
        }

        public override string ToString()
        {
            return name + ": " + amount;
        }

        public float Holen(float menge)
        {
            if (menge < amount)
            {
                amount -= menge;
                return menge;
            }
            else if (amount > 0)
                return amount;
            else
                return 0;
        }

        public void Add(float menge)
        {
            amount += menge;
        }
    }
}
