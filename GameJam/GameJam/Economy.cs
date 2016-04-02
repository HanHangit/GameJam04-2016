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

        public Economy()
        {
            settleList = new List<Settlement>();
        }

        public void Update(RenderWindow window)
        {
            Vector2i mousePosition = Mouse.GetPosition(window);
            if (Mouse.IsButtonPressed(Mouse.Button.Right))
            {
                settleList.Add(new Settlement(new Sprite(new Texture("textures/Small_Village_Center.png")), mousePosition));

            }
        }
        
        public void Draw(RenderWindow window)
        {
            foreach (Settlement city in settleList)
            {
                Console.WriteLine(city.getSprite().Position.ToString());
                window.Draw(city.getSprite());
            }
        }
    }
}
