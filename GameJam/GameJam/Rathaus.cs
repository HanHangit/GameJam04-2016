using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace GameJam
{
    class Rathaus
    {
        int gesamtBev;
        int arbeitBev;
        double realGesamtBev;
        double bevWachs;
        List<Ressource> ressources;
        List<Produkte> produkte;
        List<Building> buildings;
        List<CivilBuilding> civilBuildings;

        public Rathaus(int _gesamtBev, List<Ressource> _ressources, List<Produkte> _produkte)
        {
            gesamtBev = _gesamtBev;
            realGesamtBev = gesamtBev;
            arbeitBev = gesamtBev / 2;
            bevWachs = 0.001;
            buildings = new List<Building>();
            civilBuildings = new List<CivilBuilding>();
            WohnHaus firstWohnHaus = new WohnHaus(ressources, produkte);
            firstWohnHaus.currentBewohner = 20;
            civilBuildings.Add(firstWohnHaus);


            ressources = _ressources;
            produkte = _produkte;

        }

        public void Update(GameTime gTime)
        {
            gesamtBev = 0;
            foreach (CivilBuilding c in civilBuildings)
            {
                c.Update(gTime);
                gesamtBev += (int)c.currentBewohner;
            }
        }

        public void Draw(RenderWindow windowc)
        {
            
        }

        public int getGesamtBev()
        {
            return gesamtBev;
        }

        public int getArbeitBev()
        {
            return arbeitBev;
        }

        public int getGebäudeAnzahl()
        {
            return buildings.Count();
        }
    }
}
