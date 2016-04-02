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
    class Tile
    {
        bool begehebar;
        Ressource ressource;
       public Color tileColor { get; private set; }

        public Tile(Vector2f position, int type, int tilesize)
        {
            begehebar = true;
            SetRessource(type);
            
            //Create Tile Shape
            tileColor = MapSettings.typeColor[type];
        }

        void SetRessource(int type)
        {
            ressource = new Ressource(type);
        }
    }
}
