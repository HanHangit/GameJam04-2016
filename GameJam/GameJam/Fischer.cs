using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace GameJam
{
    class Fischer : Building
    {

        float abbaugeschwindigkeit;
        List<Ressource> refRessources;
        List<string> production;

        public Fischer(List<Ressource> _ressources, List<Produkte> _produkte, List<Ressource> _refRessources, List<KiTask> _kiList)
        {
            currentExp = 0;
            maxExp = 1500;
            zuwachsExp = 0.1f;
            kiList = _kiList;
            production = new List<string>();
            refRessources = new List<Ressource>();
            production.Add("Fische");
            refRessources = _refRessources;
            abbaugeschwindigkeit = 0.007f;
            ressources = _ressources;
            produkte = _produkte;
            entwicklungsStufe = 1;
            maxWorkers = 10;
            auslastung = 0;
            name = "Fischer";
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

        public override void lvlUp()
        {
            entwicklungsStufe++;
            maxWorkers += 5;
            abbaugeschwindigkeit += 0.001f;
            currentExp = 0;
            maxExp += 200;
        }
    }
}
