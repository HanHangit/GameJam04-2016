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
        Vector2f pos;

        public Tile(Vector2f position, int type, int tilesize)
        {
            pos = position;
            begehebar = true;
            ressource = new Ressource(type);

            tileColor = MapSettings.typeColor[type];
        }

        public Ressource GetRessource()
        {
            return ressource;
        }
    }
}
