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
        Economy eco;

        public Game()
        {
            hud = new Hud();
            window = new RenderWindow(new VideoMode(1800, 1000), "GameJam");
            window.Closed += (object sender, EventArgs e) => { (sender as Window).Close(); };

			int tilesize = MapSettings.tilesize;
            map = new MapGenerator((int)window.Size.X / tilesize, (int)window.Size.Y / tilesize);
            gameTime = new GameTime();
            eco = new Economy();

            //Draw TImer Update
            float fixedDrawTime = 0;
            float currentDrawTimer = 0;

            while (window.IsOpen)
            {

                UpdateAll();
                if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                    map = new MapGenerator((int)window.Size.X / tilesize, (int)window.Size.Y / tilesize);


                currentDrawTimer += gameTime.Ellapsed.Milliseconds;
                    currentDrawTimer = 0;
                    DrawAll();

                Console.WriteLine(1000f / gameTime.Ellapsed.Milliseconds);
                window.DispatchEvents();
            }
        }

        void UpdateAll()
        {
            gameTime.Update();
            hud.Update(window, gameTime);
            eco.Update(window);
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
