using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;


namespace GameJam
{
    class MapGenerator
    {
        int tilesize = MapSettings.tilesize;
        bool[,] boolMap;
        int[,] intMap;
        Tile[,] tileMap;
        Random rnd;
        Texture mapTexture;
        Sprite mapSprite;



        public MapGenerator(int size)
        {

            tileMap = new Tile[size, size];
            intMap = new int[size, size];
            boolMap = new bool[size, size];
            GenerateMap();
        }

        public MapGenerator(int widht, int height)
        {
            tileMap = new Tile[widht, height];
            intMap = new int[widht, height];
            boolMap = new bool[widht, height];
            GenerateMap();
        }

        void GenerateMap()
        {
            rnd = new Random();
            RandomMap();
            CreateRessources(5);
            CollectRessources(10);
            CreateRiver(1);
            CreateTiles();
            UpdateMap();

        }

        void CreateRiver(int anzahl)
        {
            for (int i = 0; i < anzahl; ++i)
            {
                int x = 0, y = 0;
                if (rnd.Next(2) == 0)
                {
                    x = rnd.Next(0, intMap.GetLength(0));
                    y = 0;
                }
                else
                {
                    x = 0;
                    y = rnd.Next(0, intMap.GetLength(1));
                }

                int ausrichtung = rnd.Next(30, 70);
                while (x < intMap.GetLength(0) && y < intMap.GetLength(1))
                {
                    intMap[x, y] = 2;
                    if (ausrichtung < rnd.Next(30, 70))
                        ++x;
                    else
                        ++y;
                }

            }
        }

        void RandomMap()
        {
            for (int i = 0; i < intMap.GetLength(0); ++i)
                for (int l = 0; l < intMap.GetLength(1); ++l)
                {
                    boolMap[i, l] = true;
                    intMap[i, l] = 0;
                }
        }

        void CreateRessources(int abstand)
        {
            for (int i = 1; i < MapSettings.ressourcesWahrscheinlichkeit.Length; ++i)
                for (int l = 0; l < MapSettings.ressourcesWahrscheinlichkeit[i]; ++l)
                {
                    int x = rnd.Next(0, intMap.GetLength(0));
                    int y = rnd.Next(0, intMap.GetLength(1));
                    intMap[x, y] = i;
                    CreateRessourceField(x, y);
                }

        }

        bool CheckMapType(int x, int y, int type, int size)
        {
            for (int i = x - size; i < x + size; ++i)
                for (int l = y - size; l < y + size; ++l)
                    return true;
            return true;
        }

        void CreateRessourceField(int x, int y)
        {
            for (int i = x - 1; i <= x + 1; ++i)
                for (int l = y - 1; l <= y + 1; ++l)
                {
                    if (!InsideMap(i, l))
                        continue;
                    else if (intMap[i, l] == 0)
                    {
                        boolMap[i, l] = false;
                        intMap[i, l] = intMap[x, y];
                    }
                }
        }

        void CollectRessources(int radius)
        {

            for (int i = 0; i < intMap.Length; ++i)
            {
                int x = rnd.Next(0, intMap.GetLength(0));
                int y = rnd.Next(0, intMap.GetLength(1));
                if (intMap[x, y] != 0)
                {
                    int type = intMap[x, y];
                    for (int l = x - radius; l <= x + radius; ++l)
                        for (int k = y - radius; k <= y + radius; ++k)
                        {
                            if (!InsideMap(l, k))
                                continue;
                            if (intMap[l, k] == type)
                            {
                                int sx = l, sy = k;
                                int itt = 0;
                                while (intMap[sx, sy] != 0 && itt < 5)
                                {
                                    ++itt;
                                    for (int t = x - itt; t <= x + itt; ++t)
                                        for (int s = y - itt; s <= y + itt; ++s)
                                        {
                                            if (!InsideMap(t, s))
                                                continue;
                                            if (intMap[t, s] == 0 && intMap[sx, sy] != 0)
                                            {
                                                intMap[t, s] = type;
                                                intMap[sx, sy] = 0;
                                            }
                                        }
                                }
                            }
                        }
                }
            }

        }

        bool InsideMap(int x, int y)
        {
            if (x >= intMap.GetLength(0) || y >= intMap.GetLength(1) || x < 0 || y < 0)
                return false;
            else
                return true;
        }

        void CreateTiles()
        {
            for (int i = 0; i < intMap.GetLength(0); ++i)
                for (int l = 0; l < intMap.GetLength(1); ++l)
                {
                    tileMap[i, l] = new Tile(new Vector2f(i, l), intMap[i, l], tilesize);
                }


        }

        void UpdateMap()
        {
            Color[,] mapColor = new Color[intMap.GetLength(0), intMap.GetLength(1)];
            for (int i = 0; i < intMap.GetLength(0); ++i)
                for (int l = 0; l < intMap.GetLength(1); ++l)
                {
                    mapColor[i, l] = tileMap[i, l].tileColor;
                }

            Image mapImage = new Image(mapColor);
            mapTexture = new Texture(mapImage, new IntRect(0, 0, intMap.GetLength(0) * MapSettings.tilesize, intMap.GetLength(1) * MapSettings.tilesize));
            mapSprite = new Sprite(mapTexture);
            mapSprite.Scale = new Vector2f(MapSettings.tilesize, MapSettings.tilesize);
        }

        public void DrawMap(RenderWindow window)
        {
            window.Draw(mapSprite);
        }
    }
}
