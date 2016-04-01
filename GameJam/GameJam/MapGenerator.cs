﻿using System;
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
        int tilesize = 4;
        bool[,] boolMap;
        int[,] intMap;
        Tile[,] tileMap;
        Random rnd;

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
            CreateRessources();
            CreateRiver(1);
            CreateTiles();

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


                while (x < intMap.GetLength(0) && y < intMap.GetLength(1))
                {
                    intMap[x, y] = 2;
                    if (rnd.Next(2) == 0)
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

        void CreateRessources()
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

        void CreateRessourceField(int x, int y)
        {
            for (int i = x - 1; i <= x + 1; ++i)
                for (int l = y - 1; l <= y + 1; ++l)
                {
                    if (i >= intMap.GetLength(0) || l >= intMap.GetLength(1) || i < 0 || l < 0)
                        continue;
                    else if (intMap[i, l] == 0)
                    {
                        boolMap[i, l] = false;
                        intMap[i, l] = intMap[x, y];
                    }
                }
        }

        void CreateTiles()
        {
            for (int i = 0; i < intMap.GetLength(0); ++i)
                for (int l = 0; l < intMap.GetLength(1); ++l)
                {
                    tileMap[i, l] = new Tile(new Vector2f(i, l), intMap[i, l], tilesize);
                }
        }

        public void DrawMap(RenderWindow window)
        {
            foreach (Tile t in tileMap)
                t.Draw(window);
        }
    }
}
