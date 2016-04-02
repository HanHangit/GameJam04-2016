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
        float zufriedenHeit;
        float wachstum;

        public WohnHaus(List<Ressource> _ressources, List<Produkte> _produkte)
        {
            ressources = _ressources;
            produkte = _produkte;
            entwicklungsStufe = 1;
            maxBewohner = 50;
            currentBewohner = 0;
            auslastung = 0f;
            name = "WohnHaus";
            zufriedenHeit = 1; // Wert von -10 bis 10 z.B.
        }

        public override string ToString()
        {
            return name;
        }

        public override void Update(GameTime gTime)
        {
            wachstum = zufriedenHeit * gTime.Ellapsed.Milliseconds / 100;
            //Console.WriteLine(wachstum);
            currentBewohner += wachstum;
            auslastung = (float)currentBewohner / (float)maxBewohner;
            if(auslastung >= 1)
            {
                auslastung = 1;
                currentBewohner = maxBewohner;
            }
        }
    }
}
