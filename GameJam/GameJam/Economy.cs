using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace GameJam
{
    class Economy
    {
        private List<Settlement> settleList;
        int anzahl = 1;
        public Economy()
        {
            settleList = new List<Settlement>();
            //settleList.Add(new Settlement(new Sprite(new Texture("textures/Small_Village_Center.png")), new Vector2i(500,500), 20));
        }

        public void Update(RenderWindow window, GameTime gTime)
        {
            //TODO: Stadt update
            Vector2i mousePosition = Mouse.GetPosition(window);
            if (Mouse.IsButtonPressed(Mouse.Button.Right) && anzahl == 1)
            {
                --anzahl;
                settleList.Add(new Settlement(new Sprite(new Texture("textures/Small_Village_Center.png")), mousePosition, 20));

            }

            foreach (Settlement city in settleList)
                city.Update(gTime);
        }
        
        public void Draw(RenderWindow window)
        {
            foreach (Settlement city in settleList)
            {
                city.Draw(window);
            }
        }
    }
}
