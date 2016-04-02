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
        private Sprite exampleSprite;
        int fps;

        public Hud()
        {
            textList = new List<HudText>();
            
            standardFont = new Font("fonts/arial.ttf");
            exampleSprite = new Sprite();
            
            exampleSprite.Texture = new Texture(new Image("textures/Small_Village_Center.png"));
            

            textList.Add(new HudText("mousePos", "---", new Vector2f(0, 0)));
            textList.Add(new HudText("totalTime", "---", new Vector2f(0, 20)));
            textList.Add(new HudText("fps", "---", new Vector2f(0, 40)));

            textList.Add(new HudText("stadtAusgewählt", "---", new Vector2f(0, 200)));
            textList.Add(new HudText("gesamtBev", "---", new Vector2f(0, 220)));
            textList.Add(new HudText("gebäudeAnzahl", "---", new Vector2f(0, 240)));
            textList.Add(new HudText("bla", "---", new Vector2f(0, 260)));
        }
       
        public void Update(RenderWindow window, GameTime gameTime, Settlement selectedCity)
        {
            mousePosition = Mouse.GetPosition(window);
            totalTime = gameTime.TotalTime;
            stringTime = totalTime.Minutes + ":" + totalTime.Seconds.ToString("00.") + ":" + totalTime.Milliseconds;
            fps = (int)(1000 / gameTime.Ellapsed.Milliseconds);

            exampleSprite.Position = new Vector2f(mousePosition.X - exampleSprite.TextureRect.Width, mousePosition.Y - exampleSprite.TextureRect.Height);

           // searches HudText mousPos and udpates the output
            textList.Find(i => i.textName.Equals("mousePos")).ChangeText("MousePos: X = " + mousePosition.X + "; Y = " + mousePosition.Y);
            // updates output of TotalTime
            textList.Find(i => i.textName.Equals("totalTime")).ChangeText("Time " + stringTime);
            // updates output of Frames
            textList.Find(i => i.textName.Equals("fps")).ChangeText("FPS: " + fps);

            updateStadtInfo(selectedCity);
        }

        void updateStadtInfo(Settlement selectedCity)
        {
            if (selectedCity == null)
            {
                textList.Find(i => i.textName.Equals("stadtAusgewählt")).ChangeText("No City Selected");
                textList.Find(i => i.textName.Equals("gesamtBev")).RemoveText();
                textList.Find(i => i.textName.Equals("gebäudeAnzahl")).RemoveText();
                return;
            }
            else
            {
                textList.Find(i => i.textName.Equals("stadtAusgewählt")).ChangeText("City Selected");
                textList.Find(i => i.textName.Equals("gesamtBev")).ChangeText("Bevölkerung: " + selectedCity.gesamtBev);
                textList.Find(i => i.textName.Equals("gebäudeAnzahl")).ChangeText("Gebäudeanzahl: " + selectedCity.gebäudeAnzahl);
            }
        }

        public void DrawHud(RenderWindow window)
        {

            window.Draw(exampleSprite);
            foreach (HudText text in textList)
            {
                window.Draw(text.getText());
            }
        }
    }
}
