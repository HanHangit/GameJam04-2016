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
        private List<Settlement> settleList;

        private Vector2i mousePosition;
        private TimeSpan totalTime;
        private String stringTime;
        private Sprite exampleSprite;

        public Hud()
        {
            textList = new List<HudText>();
            settleList = new List<Settlement>();
            standardFont = new Font("fonts/arial.ttf");
            exampleSprite = new Sprite();
            
            exampleSprite.Texture = new Texture(new Image("textures/Small_Village_Center.png"));
            

            textList.Add(new HudText("mousePos", "---", new Vector2f(0, 0)));
            textList.Add(new HudText("totalTime", "---", new Vector2f(0, 20)));

        }
       
        public void Update(RenderWindow window, GameTime gameTime)
        {
            mousePosition = Mouse.GetPosition(window);
            totalTime = gameTime.TotalTime;
            stringTime = totalTime.Minutes + ":" + totalTime.Seconds.ToString("00.") + ":" + totalTime.Milliseconds;
            
            exampleSprite.Position = new Vector2f(mousePosition.X - exampleSprite.TextureRect.Width, mousePosition.Y - exampleSprite.TextureRect.Height);

            if (Mouse.IsButtonPressed(Mouse.Button.Right))
            {
                settleList.Add(new Settlement(new Sprite(new Texture("textures/Small_Village_Center.png")), mousePosition));

            }

            // searches HudText mousPos and udpates the output
            textList.Find(i => i.textName.Equals("mousePos")).ChangeText("MousePos: X = " + mousePosition.X + "; Y = " + mousePosition.Y);
            // updates output of TotalTime
            textList.Find(i => i.textName.Equals("totalTime")).ChangeText("Time " + stringTime);


        }

        public void DrawHud(RenderWindow window)
        {
            window.Draw(exampleSprite);
            foreach( Settlement city in settleList)
            {
                Console.WriteLine(city.getSprite().Position.ToString());
                window.Draw(city.getSprite());
            }

            foreach (HudText text in textList)
            {
                window.Draw(text.getText());
            }
        }
    }
}
