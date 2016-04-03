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

        public ErzMine(List<Ressource> _ressources, List<Produkte> _produkte, List<Ressource> _refRessources, List<KiTask> _kiList)
        {
            currentExp = 0;
            maxExp = 1400;
            zuwachsExp = 0.1f;
            kiList = _kiList;
            production = new List<string>();
            refRessources = new List<Ressource>();
            production.Add("Eisenerz");
            refRessources = _refRessources;
            abbaugeschwindigkeit = 0.003f;
            ressources = _ressources;
            produkte = _produkte;
            entwicklungsStufe = 1;
            maxWorkers = 40;
            auslastung = 0;
            name = "ErzMine";
        }


        public override void Draw(RenderWindow window)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gTime)
        {
            UpdateKiList();
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

        public void UpdateKiList()
        {
            if (entwicklungsStufe >= 3)
            {
                KiTask checkTask = kiList.Find(item => item.task.Equals("Eisen"));
                if (checkTask == null)
                {
                    kiList.Add(new KiTask("Eisen", 5));
                }
                else
                {
                    checkTask.AddValue(0);
                }
            }
        }

        public override void lvlUp()
        {
            entwicklungsStufe++;
            maxWorkers += 20;
            currentExp = 0;
            abbaugeschwindigkeit += 0.002f;
        }
    }
}
