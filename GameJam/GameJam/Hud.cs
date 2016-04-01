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
    class Hud
    {
        private Font standardFont;

        private List<HudText> textList;

        private Vector2i mousePosition;
        private TimeSpan totalTime;
        private String stringTime;

        public Hud()
        {
            textList = new List<HudText>();
            standardFont = new Font("fonts/arial.ttf");

            textList.Add(new HudText("mousePos", "---", new Vector2f(0, 0)));
            textList.Add(new HudText("totalTime", "---", new Vector2f(0, 20)));
        }
        
        public void Update(RenderWindow window, GameTime gameTime)
        {
            mousePosition = Mouse.GetPosition(window);
            totalTime = gameTime.TotalTime;
            stringTime = totalTime.Minutes + ":" + totalTime.Seconds.ToString("00.") + ":" + totalTime.Milliseconds;


            // searches HudText mousPos and udpates the output
            textList.Find(i => i.textName.Equals("mousePos")).ChangeText("MousePos: X = " + mousePosition.X + "; Y = " + mousePosition.Y);
            // updates output of TotalTime
            textList.Find(i => i.textName.Equals("totalTime")).ChangeText("Time " + stringTime);
        }

        public void DrawHud(RenderWindow window)
        {
            foreach (HudText text in textList)
            {
                window.Draw(text.getText());
            }
        }
    }
}
