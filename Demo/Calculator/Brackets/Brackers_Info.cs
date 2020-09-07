using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Calculator.Brackets
{
    class Brackers_Info
    {
        public List<List<Info>> infos { get; private set; }
        CoreParsing core;
        public void Set(string value)
        {
            infos.Add(core.Get(value));
        }
        public Brackers_Info()
        {
            this.core = new CoreParsing();
        }
    }
}
