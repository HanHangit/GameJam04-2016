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
        public Settlement selectedCity;

        Texture settlementTexture;
        
        public Economy()
        {
            settleList = new List<Settlement>();
            selectedCity = null;

            settlementTexture = new Texture(("textures/Small_Village_Center.png"));
        }

        public void Update(RenderWindow window, GameTime gTime)
        {
            //TODO: Stadt update
            Vector2i mousePosition = Mouse.GetPosition(window);

            if (Mouse.IsButtonPressed(Mouse.Button.Right))
            {
                if (noCityInRadius(mousePosition))
                {
                    settleList.Add(new Settlement(new Sprite(settlementTexture), mousePosition, 20));
                }
                else
                {
                }
            }

            foreach (Settlement city in settleList)
            {
                city.Update(gTime);
                if(city.MouseHoversHere(mousePosition) == true)
                {
                    selectedCity = city;
                    break;
                }
                else
                {
                    selectedCity = null;
                }
            }
        }

        bool noCityInRadius(Vector2i mouseposition)
        {
            Settlement fakeCity = new Settlement(mouseposition, 5);
            double minimalDistance = 128;
            double currentDistance;
            Vector2i distanceVector;
            foreach (Settlement city in settleList)
            {
                
                distanceVector = fakeCity.realPosition - city.realPosition;
                currentDistance = Math.Sqrt(distanceVector.X * distanceVector.X + distanceVector.Y * distanceVector.Y);
                if (currentDistance < minimalDistance)
                {
                    return false;
                }
            } 
            return true;
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
