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
        private Text exampleText;
        private List<HudText> textList;
        private Vector2i mousePosition;

        public Hud()
        {
            
            textList = new List<HudText>();
            exampleText = new Text();
            standardFont = new Font("fonts/arial.ttf");
            textList.Add(new HudText("mousePos", "---", new Vector2f(0, 0)));
        }
        
        void UpdateHud(RenderWindow window)
        {
            mousePosition = Mouse.GetPosition(window);
            // searches HudText mousPos and udpates the output
            textList.Find(i => i.textName.Equals("mousePos")).ChangeText("MousePos: X = " + mousePosition.X + "; Y = " + mousePosition.Y);
        }

        public void DrawHud(RenderWindow window)
        {
            UpdateHud(window);
            foreach (HudText text in textList)
            {
                window.Draw(text.getText());
            }
        }
    }
}
