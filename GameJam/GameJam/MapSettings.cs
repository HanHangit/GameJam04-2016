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
    class MapSettings
    {
        public static int tilesize = 4;

        public static Color[] typeColor =
        {
           new Color(182,140,100),  //Kahles Land
           new Color(114,169,5),    //Normales Land
           new Color(22,154,152),   //Wasser Land
           new Color(83,54,0),      //Wald Land
           new Color(117,117,117),  //Eisen Land
           new Color(255,220,0),     //Gold Land
           new Color(0,0,0)
        };

        public static string[] ressourcesName =
        {
            "None",
            "Food",
            "Fische",
            "Holz",
            "Eisenerz",
            "Gold",
            "Kohle"
        };

        public static int[] ressourcesWahrscheinlichkeit =
        {
            99999,
            75,
            50,
            40,
            30,
            10,
            40

        };
    }
}
