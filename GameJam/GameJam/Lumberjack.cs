using System;
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
        int currentWorkers;
        float abbaugeschwindigkeit;
        List<Ressource> refRessources;
        List<string> production;

        public Lumberjack(List<Ressource> _ressources, List<Produkte> _produkte, List<Ressource> _refRessources)
        {
            production.Add("Wood");
            refRessources = _refRessources;
            abbaugeschwindigkeit = 1;
            ressources = _ressources;
            produkte = _produkte;
            currentWorkers = 0;
            entwicklungsStufe = 1;
            maxWorkers = 6;
        }

        public override void Draw(RenderWindow window)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gTime)
        {
            for(int i = 0; i < production.Count;++i)
            {
                
            }
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
