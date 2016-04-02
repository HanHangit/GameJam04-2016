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
    abstract class CivilBuilding
    {
        public int entwicklungsStufe;
        public List<Ressource> ressources;
        public List<Produkte> produkte;
        public int maxBewohner { get; set; }
        public float currentBewohner { get; set; }
        public float auslastung { get; set; }
        public string name;
        public abstract override string ToString();
        public abstract void Update(GameTime gTime);


    }
}
