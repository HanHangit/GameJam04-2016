using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace GameJam
{
    class Hochofen : Building
    {
        float produktionsGeschwindigkeit;
        List<string>[] neededRessources;
        List<float>[] amountRessources;
        List<string> production;

        public Hochofen(List<Ressource> _ressources, List<Produkte> _produkte, List<Ressource> _refRessources)
        {
            production = new List<string>();
            neededRessources = new List<string>[1];
            amountRessources = new List<float>[1];
            for(int i = 0; i < neededRessources.Length;++i)
            {
                neededRessources[i] = new List<string>();
                amountRessources[i] = new List<float>();
            }
            neededRessources[0].Add("Kohle");
            amountRessources[0].Add(0.003f);
            neededRessources[0].Add("Eisen");
            amountRessources[0].Add(0.002f);
            production.Add("Eisen");
            produktionsGeschwindigkeit = 0.001f;
            ressources = _ressources;
            produkte = _produkte;
            entwicklungsStufe = 1;
            maxWorkers = 25;
            auslastung = 0;
        }


        public override void Draw(RenderWindow window)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gTime)
        {
            auslastung = (float)currentWorkers / (float)maxWorkers;
            for (int i = 0; i < production.Count; ++i)
            {
                bool enoughRessources = true;
                List<float> checkRessource = new List<float>();
                for(int l = 0; l < neededRessources.Length; ++l)
                {
                    Produkte checkAmountRessource = produkte.Find(item => item.name.Equals(neededRessources[i][l]));
                    if (checkAmountRessource != null)
                    {
                        float menge = checkAmountRessource.Holen(amountRessources[i][l]);
                        if (menge == 0)
                        {
                            enoughRessources = false;

                        }
                        else
                        {
                            checkRessource.Add(menge);
                        }

                    }

                }
                if (enoughRessources)
                {
                    ressources.Find(item => item.name.Equals(production[i])).Add(auslastung * produktionsGeschwindigkeit * gTime.Ellapsed.Milliseconds);
                }
                else
                {
                    for (int l = 0; l < checkRessource.Count; ++l)
                    {
                        Produkte checkAmountRessource = produkte.Find(item => item.name.Equals(neededRessources[i][l]));
                        if (checkAmountRessource != null)
                        {
                            checkAmountRessource.Add(checkRessource[l]);
                        }
                    }
                }
            }
        }
    }
}
