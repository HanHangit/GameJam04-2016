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
        RectangleShape shape;

        public Tile(Vector2f position, int type, int tilesize)
        {
            begehebar = true;
            SetRessource(type);
            
            //Create Tile Shape
            shape = new RectangleShape(new Vector2f(tilesize, tilesize));
            shape.FillColor = MapSettings.typeColor[type];
            shape.Position = position * tilesize;
        }

        void SetRessource(int type)
        {
            ressource = new Ressource(type);
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(shape);
        }
    }
}
