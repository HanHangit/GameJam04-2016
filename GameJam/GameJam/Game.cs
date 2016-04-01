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
    class Game
    {
        RenderWindow window;
        Hud hud;
        GameTime gameTime;
        MapGenerator map;

        public Game()
        {
            hud = new Hud();
            window = new RenderWindow(new VideoMode(800, 600), "GameJam");
            window.Closed += (object sender, EventArgs e) => { (sender as Window).Close(); };

            MapGenerator map = new MapGenerator(200,150);
            gameTime = new GameTime();

            while (window.IsOpen)
            {
                window.Clear(Color.Blue);
                UpdateAll();
                DrawAll();

                window.Display();
                window.DispatchEvents();
            }
        }

        void UpdateAll()
        {
            gameTime.Update();
            hud.Update(window, gameTime);
        }

        void DrawAll()
        {
			map.DrawMap(window);
            hud.DrawHud(window);
        }
    }
}
