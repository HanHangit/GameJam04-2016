using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam
{
    class MapGenerator
    {
        int[,] map;
        public MapGenerator(int size)
        {
            map = new int[size, size];
            GenerateMap();
        }

        public MapGenerator(int widht, int height)
        {
            map = new int[widht, height];
            GenerateMap();
        }

        void GenerateMap()
        {

        }
    }
}
