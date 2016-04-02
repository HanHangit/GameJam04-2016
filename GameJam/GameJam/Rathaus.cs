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


        public Rathaus(int _gesamtBev, List<Ressource> _ressources, List<Produkte> _produkte)
        {
            gesamtBev = _gesamtBev;
            realGesamtBev = gesamtBev;
            arbeitBev = gesamtBev / 2;
            bevWachs = 0.000001;

            
            ressources = _ressources;
            produkte = _produkte;

        }

        public void Update(GameTime gTime)
        {
            // bevWachs muss von Bevölkerung selber und Zufriedenheut abhängig sein;


            //int foodPerPerson = 
            
            realGesamtBev += bevWachs * gTime.Ellapsed.Milliseconds; 
            gesamtBev = (int) realGesamtBev;
        }

        public void Draw(RenderWindow window)
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
    }
}
