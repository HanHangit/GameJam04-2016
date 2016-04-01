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
    class Game
    {
        RenderWindow window;
        public Game()
        {
            window = new RenderWindow(new VideoMode(800, 600), "GameJam");
            window.Closed += (object sender, EventArgs e) => { (sender as Window).Close(); };
            MapGenerator map = new MapGenerator(200,150);

            while (window.IsOpen)
            {
                window.Clear(Color.Blue);
                map.DrawMap(window);
                window.Display();
                window.DispatchEvents();
            }
        }
    }
}
