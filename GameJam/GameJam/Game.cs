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
        public static MapGenerator map;
        Economy eco;

        public Game()
        {
            hud = new Hud();
            window = new RenderWindow(new VideoMode(800, 500), "GameJam");
            window.Closed += (object sender, EventArgs e) => { (sender as Window).Close(); };

			int tilesize = MapSettings.tilesize;
            map = new MapGenerator((int)window.Size.X / tilesize, (int)window.Size.Y / tilesize);
            gameTime = new GameTime();
            eco = new Economy();

            while (window.IsOpen)
            {

                UpdateAll();
                if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                    map = new MapGenerator((int)window.Size.X / tilesize, (int)window.Size.Y / tilesize);
                    DrawAll();
                window.DispatchEvents();
            }
        }

        void UpdateAll()
        {
            gameTime.Update();
            hud.Update(window, gameTime);
            eco.Update(window, gameTime);
        }

        void DrawAll()
        {
            window.Clear();
            map.DrawMap(window);
            eco.Draw(window);
            hud.DrawHud(window);
            window.Display();
        }
    }
}
