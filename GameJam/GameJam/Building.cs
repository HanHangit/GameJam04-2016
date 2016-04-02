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
    abstract class Building
    {
        public List<Ressource> ressources;
        public List<Produkte> produkte;
        public int entwicklungsStufe;
        public int maxWorkers { get; set; }
        public int currentWorkers { get; private set; }
        public float auslastung { get; set; }
        public string name;
        public int status;
        public abstract override string ToString();
        public abstract void Update(GameTime gTime);
        public abstract void Draw(RenderWindow window);

        public void BindingWorker(int Workers)
        {
            currentWorkers = Workers;
        }    }
}
