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
        public int workers { get; set; }
        Vector2i position;
        
        public Lager(Vector2i pos, int _radius, List<Ressource> _ressources, List<Produkte> _produkte)
        {
            position = pos;
            ressources = new List<Ressource>();
            produkte = new List<Produkte>();
            ressources = _ressources;
            produkte = _produkte;
            radius = _radius;
            ressourceRef = new List<Ressource>();
            buildings = new List<Building>();
            CollectRessourceRef();
            buildings.Add(new Lumberjack(ressources, produkte, ressourceRef));
            buildings.Add(new Bauernhof(ressources, produkte, ressourceRef));
        }

        void CollectRessourceRef()
        {
            int x = (int)position.X / MapSettings.tilesize;
            int y = (int)position.Y / MapSettings.tilesize;
            for (int i = x - radius; i < x + radius; ++i)
                for(int l = y - radius; l < y + radius; ++l)
                {
                    if (Game.map.InsideMap(i,l))
                    {
                        Tile foundTile = Game.map.tileMap[i,l];
                        Ressource foundRessource = foundTile.GetRessource();
                        if (!foundRessource.name.Equals("None"))
                        {
                            ressourceRef.Add(foundRessource);
                        }
                    }
                }

        }

        public void Draw(RenderWindow window)
        {

        }

        public void Update(GameTime gTime)
        {
            WorkerVerteilung();

            if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
                foreach (Ressource r in ressources)
                    Console.WriteLine(r.ToString());
            foreach (Building b in buildings)
                b.Update(gTime);
        }

        void WorkerVerteilung()
        {
            float[] workerVerteilung = new float[buildings.Count];
            int neededWorkers = 0;
            for (int i = 0; i < buildings.Count; i++)
            {
                neededWorkers += buildings[i].maxWorkers;
                workerVerteilung[i] = buildings[i].maxWorkers;
            }
            if(neededWorkers <= workers)
            {
                for(int i = 0; i < buildings.Count; ++i)
                {
                    buildings[i].BindingWorker((int)workerVerteilung[i]);
                }
            }
            else
            {
                for(int i = 0; i < buildings.Count; ++i)
                {
                    workerVerteilung[i] = (workerVerteilung[i] / neededWorkers) * workers;
                    buildings[i].BindingWorker((int)workerVerteilung[i]);

                }
            }


        }

        public int getGebäudeAnzahl()
        {
            return buildings.Count();
        }

    }
}
