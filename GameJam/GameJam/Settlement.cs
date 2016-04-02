using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace GameJam
{
    class Settlement
    {
        // Overall Variables
        public Vector2i realPosition; // realPosition = centered on the Sprite
        Sprite sprite;


        // Economy Variables;

        public Settlement(Vector2i mousePosition)
        {
            Sprite defaultSprite = new Sprite(new Texture("textures/Small_Village_Center.png"));
            sprite = defaultSprite;
            sprite.Position = new Vector2f(mousePosition.X - sprite.TextureRect.Width, mousePosition.Y - sprite.TextureRect.Height);
            realPosition = new Vector2i(mousePosition.X - sprite.TextureRect.Width / 2, mousePosition.Y - sprite.TextureRect.Height / 2);
        }

        public Settlement(Sprite _sprite, Vector2i mousePosition)
        {
            sprite = _sprite;
            sprite.Position = new Vector2f(mousePosition.X - sprite.TextureRect.Width, mousePosition.Y - sprite.TextureRect.Height);
            realPosition = new Vector2i(mousePosition.X - sprite.TextureRect.Width / 2, mousePosition.Y - sprite.TextureRect.Height / 2);
        }

        /// <summary>
        /// this constructor is only for creating Objects manually
        /// </summary>
        /// <param name="_sprite"></param>
        /// <param name="_realPosition">this is only because i wanted a different constructor</param>
        public Settlement(Sprite _sprite, Vector2f _realPosition)
        {
            sprite = _sprite;
            realPosition = new Vector2i((int)_realPosition.X, (int)_realPosition.Y);
        }

        public void Update(GameTime gTime)
        {

        }

        public void Draw(RenderWindow window)
        {
            window.Draw(sprite);
            
        }
        

    }
}
