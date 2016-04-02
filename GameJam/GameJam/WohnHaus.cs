using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace GameJam
{
    class WohnHaus : CivilBuilding
    {
        public WohnHaus(List<Ressource> _ressources, List<Produkte> _produkte)
        {
            ressources = _ressources;
            produkte = _produkte;
            entwicklungsStufe = 1;
            maxBewohner = 50;
            currentBewohner = 0;
            auslastung = 0f;
            name = "WohnHaus";
        }

        public override string ToString()
        {
            return name;
        }

        public override void Update(GameTime gTime)
        {
            auslastung = (float)maxBewohner / (float)currentBewohner;
        }
    }
}
