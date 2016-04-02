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
        public Vector2i realPosition { get; private set; } // realPosition = centered on the Sprite
        Sprite sprite;
        Rathaus rathaus;
        Lager lager;
        List<Ressource> ressources;
        List<Produkte> produkte;

        int gebäudeAnzahl;
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
            rathaus = new Rathaus(newBev,ressources,produkte);
            lager = new Lager(realPosition, 10, ressources, produkte);
        }

        void InitializeResPro()
        {
            
            ressources = new List<Ressource>();
            produkte = new List<Produkte>();
            for (int i = 0; i < MapSettings.ressourcesName.Length; ++i)
                ressources.Add(new Ressource(i));
            for (int i = 0; i < ProduktSettings.produktName.Length; ++i)
                produkte.Add(new Produkte(ProduktSettings.produktName[i], ProduktSettings.produktCost[i]));
        }

        public void Update(GameTime gTime)
        {
            gesamtBev = rathaus.getGesamtBev();
            arbeitBev = rathaus.getArbeitBev();
            lager.workers = arbeitBev;
            lager.Update(gTime);
            gebäudeAnzahl = 30;
            rathaus.Update(gTime);
            if (Keyboard.IsKeyPressed(Keyboard.Key.B))
                Console.WriteLine(ressources[3].ToString());
        }

        public void Draw(RenderWindow window)
        {
            Sprite background = new Sprite(new Texture(new Image((uint)(sprite.TextureRect.Width + (int)(gebäudeAnzahl / 10 * 2)), (uint)(sprite.TextureRect.Height + (int)(gebäudeAnzahl / 10 * 2)), Color.Magenta)));
            background.Position = new Vector2f(realPosition.X - (int)(background.TextureRect.Width / 2), realPosition.Y - (int)(background.TextureRect.Height / 2));
            window.Draw(background);
            window.Draw(sprite);
            lager.Draw(window);
            rathaus.Draw(window);
        }
        
        public bool MouseHoversHere(Vector2i mousePosition)
        {
            Vector2i distanceVector = mousePosition - realPosition;
            if(distanceVector.X >= -16 && distanceVector.X <=16)
            {
                if(distanceVector.Y >= -16 && distanceVector.Y <= 16)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
