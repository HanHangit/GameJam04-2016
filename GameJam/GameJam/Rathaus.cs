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
        List<CivilBuilding> newHouseRequest;

        List<CivilRequest> requestList;

        WohnHaus newWohnHaus;

        public Rathaus(int _gesamtBev, List<Ressource> _ressources, List<Produkte> _produkte)
        {
            gesamtBev = _gesamtBev;
            realGesamtBev = gesamtBev;
            arbeitBev = gesamtBev / 2;
            bevWachs = 0.001;
            buildings = new List<Building>();
            civilBuildings = new List<CivilBuilding>();
            newHouseRequest = new List<CivilBuilding>();
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
                if(c.name == "WohnHaus" && c.status == 2)
                {
                    newHouseRequest.Add(c);
                }
                gesamtBev += (int)c.currentBewohner;
            }

            UpgradeHouses();
        }

        void UpgradeHouses()
        {
            while(newHouseRequest.Count > 0)
            {
                CivilBuilding c = newHouseRequest[0];
                float newBewohner = c.currentBewohner / 2;
                c.currentBewohner = newBewohner;
                newWohnHaus = new WohnHaus(ressources, produkte);
                newWohnHaus.currentBewohner = newBewohner;
                if (newWohnHaus.maxBewohner < newBewohner)
                {
                    c.currentBewohner += newBewohner - newWohnHaus.maxBewohner;
                    newWohnHaus.currentBewohner = newWohnHaus.maxBewohner;
                }
                civilBuildings.Add(newWohnHaus);
                c.status = 0;
                newHouseRequest.Remove(c);
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
            return civilBuildings.Count();
        }
    }
}
