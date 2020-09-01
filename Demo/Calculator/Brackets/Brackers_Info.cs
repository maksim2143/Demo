using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Calculator.Brackets
{
    class Brackers_Info: Info
    {
        //private new string  number { set; get; }
       
        public Brackers_Info():base()
        {

        }
        private Brackers_Info(double number, Operator _operator) : base(number, Operator.empty)
        {
        }
        private Brackers_Info(string number, Operator _operator) : base(number, Operator.empty)
        {
        }
    }
}
