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
        Rathaus rathaus;
        Lager lager;
        List<Ressource> ressources;
        List<Produkte> produkte;

        int gesamtBev;
        int arbeitBev;

        // Economy Variables;

        public Settlement(Vector2i mousePosition, int newBev)
        {
            Sprite defaultSprite = new Sprite(new Texture("textures/Small_Village_Center.png"));
            sprite = defaultSprite;
            sprite.Position = new Vector2f(mousePosition.X - sprite.TextureRect.Width, mousePosition.Y - sprite.TextureRect.Height);
            realPosition = new Vector2i(mousePosition.X - sprite.TextureRect.Width / 2, mousePosition.Y - sprite.TextureRect.Height / 2);

            InitializeBev(newBev);
        }

        public Settlement(Sprite _sprite, Vector2i mousePosition, int newBev)
        {
            sprite = _sprite;
            sprite.Position = new Vector2f(mousePosition.X - sprite.TextureRect.Width, mousePosition.Y - sprite.TextureRect.Height);
            realPosition = new Vector2i(mousePosition.X - sprite.TextureRect.Width / 2, mousePosition.Y - sprite.TextureRect.Height / 2);

            InitializeBev(newBev);
        }

        /// <summary>
        /// this constructor is only for creating Objects manually
        /// </summary>
        /// <param name="_sprite"></param>
        /// <param name="_realPosition">this is only because i wanted a different constructor</param>
        public Settlement(Sprite _sprite, Vector2f _realPosition, int newBev)
        {
            sprite = _sprite;
            realPosition = new Vector2i((int)_realPosition.X, (int)_realPosition.Y);

            InitializeBev(newBev);
        }

        void InitializeBev(int newBev)
        {
            InitializeResPro();
            rathaus = new Rathaus(newBev);
            lager = new Lager(realPosition, 10, gesamtBev, ressources, produkte);
        }

        void InitializeResPro()
        {
            for (int i = 0; i < MapSettings.ressourcesName.Length; ++i)
                ressources.Add(new Ressource(i));
            for (int i = 0; i < ProduktSettings.produktName.Length; ++i)
                produkte.Add(new Produkte(ProduktSettings.produktName[i], ProduktSettings.produktCost[i]));
        }

        public void Update(GameTime gTime)
        {

            rathaus.Update(gTime);
            gesamtBev = rathaus.getGesamtBev();
            gesamtBev = rathaus.getArbeitBev();
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(sprite);
            
        }
        
        
    }
}
