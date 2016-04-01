using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Diagnostics;

namespace GameJam
{
    class GameTime
    {
        Stopwatch watch;
        public TimeSpan TotalTime { get; private set; }
        // time ellapsed since last frame
        public TimeSpan Ellapsed { get; private set; }

        public GameTime()
        {
            watch = new Stopwatch();
            TotalTime = new TimeSpan();
            Ellapsed = new TimeSpan();

            watch.Start();
        }

        public void ResetTime()
        {
            watch.Reset();
            watch.Start();
        }

        public void Update()
        {
            if (watch.ElapsedMilliseconds == 0)
                Ellapsed = TimeSpan.FromMilliseconds(1);
            else
                Ellapsed = watch.Elapsed - TotalTime;
            TotalTime = watch.Elapsed;
        }
    }
}
