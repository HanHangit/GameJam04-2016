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
        string name;
        float amount;

        public Ressource(int type)
        {
            Random rnd = new Random();
            name = MapSettings.ressourcesName[type];
            amount = rnd.Next(100, 500);
        }
    }
}
