using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam
{
    class KiTask
    {

        public string task { get; private set; }
        public float value { get;  private set; }

        public KiTask(string _task, float _value)
        {
            task = _task;
            value = _value;
        }

        public void AddValue(float menge)
        {
            value += menge;
        }
    }
}
