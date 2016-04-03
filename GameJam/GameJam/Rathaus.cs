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
            requestList = new List<CivilRequest>();
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
                    requestList.Add(new CivilRequest(c, new WohnHaus(ressources, produkte), 5));
                }
                gesamtBev += (int)c.currentBewohner;
            }
            RequestHandler();
            arbeitBev = (int)(gesamtBev / 2);
        }


        void RequestHandler()
        {
            List<CivilRequest> removeRequests = new List<CivilRequest>(); 
            foreach(CivilRequest cr in requestList)
            {
                if(cr.requestingBuilding.status == 0)
                removeRequests.Add(cr);
            }
            foreach(CivilRequest rr in removeRequests)
            {
                requestList.Remove(rr);
            }

            foreach(CivilRequest cr in requestList)
            {
                if(RessourcesAvaiable(cr.BauStoffe))
                {
                    drainRessources(cr.BauStoffe);
                    if (cr.requestedBuilding.name == "WohnHaus")
                    {
                        CivilBuilding newWohnHaus = cr.requestedBuilding;
                        float newBewohner = cr.requestingBuilding.currentBewohner / 2;
                        cr.requestingBuilding.currentBewohner = newBewohner;
                        if (newWohnHaus.maxBewohner < newBewohner)
                        {
                            cr.requestingBuilding.currentBewohner += newBewohner - newWohnHaus.maxBewohner;
                            newWohnHaus.currentBewohner = newWohnHaus.maxBewohner;
                        }
                        civilBuildings.Add(newWohnHaus);
                        cr.requestingBuilding.status = 0;
                    }
                }
            }
        }

        bool RessourcesAvaiable(List<Ressource> needRessources)
        {
            foreach (Ressource r in needRessources)
            {
                Ressource lagerRes = ressources.Find(Item => Item.name.Equals(r.name));
                if(lagerRes.amount < r.amount)
                {
                    return false;
                }
            }
            return true;
        }

        void drainRessources(List<Ressource> needRessources)
        {
            foreach (Ressource r in needRessources)
            {
                Ressource lagerRes = ressources.Find(Item => Item.name.Equals(r.name));
                lagerRes.Holen(r.amount);
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
