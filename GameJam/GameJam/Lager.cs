using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace GameJam
{
    class Lager 
    {
        List<Ressource> ressourceRef;
        List<Ressource> ressources;
        List<Produkte> produkte;
        List<Building> buildings;
        int radius;
        int arbeiter;
        Vector2i position;
        
        public Lager(Vector2i pos, int _radius, int gesamtBev, List<Ressource> _ressources, List<Produkte> _produkte)
        {
            position = pos;
            ressources = new List<Ressource>();
            produkte = new List<Produkte>();
            ressources = _ressources;
            produkte = _produkte;
            radius = _radius;
            arbeiter = gesamtBev / 2;
            ressourceRef = new List<Ressource>();
            buildings = new List<Building>();
            CollectRessourceRef();
            buildings.Add(new Lumberjack(ressources, produkte, ressourceRef));
        }

        void CollectRessourceRef()
        {
            int x = (int)position.X / MapSettings.tilesize;
            int y = (int)position.Y / MapSettings.tilesize;
            for(int i = x- radius; i < x + radius; ++i)
                for(int l = y - radius; l < y + radius; ++l)
                {
                    if(Game.map.InsideMap(i,l))
                    {
                        Tile foundTile = Game.map.tileMap[i,l];
                        Ressource foundRessource = foundTile.GetRessource();
                        if (!foundRessource.name.Equals("None"))
                        {
                            ressourceRef.Add(foundRessource);
                            Console.WriteLine(foundRessource.ToString());
                        }
                    }
                }

        }

        public void Draw(RenderWindow window)
        {

        }

        public void Update(GameTime gTime)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
                foreach (Ressource r in ressources)
                    Console.WriteLine(r.ToString());
            foreach (Building b in buildings)
                b.Update(gTime);
        }



    }
}
