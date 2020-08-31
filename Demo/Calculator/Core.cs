using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Calculator
{
    class Core
    {
        public double Start(string text)
        {
           return  calc.Get(core.Get(text));
        }
        CoreParsing core;
        Calc calc;
        public Core()
        {
            this.core = new CoreParsing();
            this.calc = new Calc();
        }
    }
}
