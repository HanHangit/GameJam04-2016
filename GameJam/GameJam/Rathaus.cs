using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam
{
    class Rathaus
    {
        int gesamtBev;
        int arbeitBev;
        double realGesamtBev;
        double bevWachs;

        public Rathaus(int _gesamtBev)
        {
            gesamtBev = _gesamtBev;
            realGesamtBev = gesamtBev;
            arbeitBev = gesamtBev / 2;
            bevWachs = 0.000001;
        }

        public void Update(GameTime gTime)
        {
            // bevWachs muss von Bevölkerung selber und Zufriedenheut abhängig sein;
            realGesamtBev += bevWachs * gTime.Ellapsed.Milliseconds; 
            gesamtBev = (int) realGesamtBev;
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
