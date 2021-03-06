﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace GameJam
{
    class Lumberjack : Building
    {
        float abbaugeschwindigkeit;
        List<Ressource> refRessources;
        List<string> production;

        public Lumberjack(List<Ressource> _ressources, List<Produkte> _produkte, List<Ressource> _refRessources, List<KiTask> _kiList)
        {
            currentExp = 0;
            maxExp = 600;
            zuwachsExp = 0.1f;
            kiList = _kiList;
            production = new List<string>();
            refRessources = new List<Ressource>();
            production.Add("Holz");
            refRessources = _refRessources;
            abbaugeschwindigkeit = 0.004f;
            ressources = _ressources;
            produkte = _produkte;
            entwicklungsStufe = 1;
            maxWorkers = 32;
            auslastung = 0;
            name = "Lumberjack";
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
                KiTask checkTask = kiList.Find(item => item.task.Equals("Bretter"));
                if (checkTask == null)
                {
                    kiList.Add(new KiTask("Bretter", 5));
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
            maxExp += 300;
            currentExp = 0;
            abbaugeschwindigkeit += 0.004f;
            maxWorkers += 10;
        }
    }
}
