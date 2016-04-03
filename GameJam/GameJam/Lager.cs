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
        List<KiTask> kiList;
        float kiUpdateTime;
        float timer;
        int radius;
        int maxBuildings;
        public int workers { get; set; }
        Vector2i position;

        public Lager(Vector2i pos, int _radius, List<Ressource> _ressources, List<Produkte> _produkte, List<KiTask> _kiList)
        {
            kiList = _kiList;
            kiUpdateTime = 5000;
            timer = 0;
            position = pos;
            ressources = new List<Ressource>();
            produkte = new List<Produkte>();
            ressources = _ressources;
            produkte = _produkte;
            radius = _radius;
            ressourceRef = new List<Ressource>();
            buildings = new List<Building>();
            CollectRessourceRef();
            maxBuildings = 1;
        }

        void CollectRessourceRef()
        {
            int x = (int)position.X / MapSettings.tilesize;
            int y = (int)position.Y / MapSettings.tilesize;
            for (int i = x - radius; i < x + radius; ++i)
                for (int l = y - radius; l < y + radius; ++l)
                {
                    if (Game.map.InsideMap(i, l))
                    {
                        Tile foundTile = Game.map.tileMap[i, l];
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
            timer += gTime.Ellapsed.Milliseconds;
            WorkerVerteilung();
            KiUpdate();

            foreach (Building b in buildings)
                b.Update(gTime);


        }

        void KiUpdate()
        {
            if (timer > kiUpdateTime)
            {
                timer = 0;
                for (int i = 0; i < ressourceRef.Count; i++)
                {
                    if (!ressourceRef[i].name.Equals("None"))
                    {
                        Building chooseBuilding = ChooseRessourceBuilding(ressourceRef[i].name);
                        if (buildings.Find(item => item.name.Equals(chooseBuilding.name)) == null)
                        {
                            KiTask task = new KiTask(ressourceRef[i].name, 1);
                            KiTask checkTask = kiList.Find(item => item.task.Equals(task.task));
                            if (checkTask == null)
                                kiList.Add(task);
                            else
                                checkTask.AddValue(1);

                        }
                    }
                }
                if (buildings.Count < maxBuildings)
                {
                    for(int i = 0; i < kiList.Count; ++i)
                    {
                        Building ToBuild = ChooseRessourceBuilding(kiList[i].task);
                        if (ToBuild != null)
                            buildings.Add(ToBuild);
                    }
                }
            }
        }

        Building ChooseRessourceBuilding(string name)
        {
            switch (name)
            {
                case "Holz": return new Lumberjack(ressources, produkte, ressourceRef);
                case "Food": return new Bauernhof(ressources, produkte, ressourceRef);
                case "Eisenerz": return new ErzMine(ressources, produkte, ressourceRef);
                case "Kohle": return new KohleMine(ressources, produkte, ressourceRef);
                case "Fische": return new Fischer(ressources, produkte, ressourceRef);
                case "Gold": return new GoldMine(ressources, produkte, ressourceRef);
                default:
                    return null;
            }
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
            if (neededWorkers <= workers)
            {
                for (int i = 0; i < buildings.Count; ++i)
                {
                    buildings[i].BindingWorker((int)workerVerteilung[i]);
                }
            }
            else
            {
                for (int i = 0; i < buildings.Count; ++i)
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
