using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace GameJam
{
    class ErzMine : Building
    {

        float abbaugeschwindigkeit;
        List<Ressource> refRessources;
        List<string> production;

        public ErzMine(List<Ressource> _ressources, List<Produkte> _produkte, List<Ressource> _refRessources)
        {
            production = new List<string>();
            refRessources = new List<Ressource>();
            production.Add("Eisenerz");
            refRessources = _refRessources;
            abbaugeschwindigkeit = 0.001f;
            ressources = _ressources;
            produkte = _produkte;
            entwicklungsStufe = 1;
            maxWorkers = 25;
            auslastung = 0;
            name = "ErzMine";
        }


        public override void Draw(RenderWindow window)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gTime)
        {
            auslastung = (float)currentWorkers / (float)maxWorkers;
            for (int i = 0; i < production.Count; ++i)
            {
                Ressource foundRes = refRessources.Find(item => item.name.Equals(production[i]));
                if (foundRes != null)
                {
                    float menge = foundRes.Holen(abbaugeschwindigkeit * auslastung * gTime.Ellapsed.Milliseconds);
                    ressources.Find(item => item.name.Equals(production[i])).Add(menge);
                }
            }
        }
    }
}
