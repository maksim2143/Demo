using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Calculator
{
   public class Info
    {
        public double number { private set; get; }
        public Operator operato_r { private set; get; }
        public static Operator CreateOperator(char one_char)
        {
            if (array.TryGetValue(one_char, out var value)) return value;
            return Operator.empty;
        }
        static readonly Dictionary<char, Operator> array = new Dictionary<char, Operator>()
            {
                { '+',Operator.plus },
                { '-',Operator.minus },
                { '*',Operator.multiplication },
                { '/',Operator.dash }
            };
        public Info(double number, Operator _operator)
        {
            this.number = number;
            this.operato_r = _operator;
        }
        public Info(string number,Operator _operator)
        {
            if (!double.TryParse(number, out var res)) 
                throw new Exception("Not parse");
            this.number = res;
            this.operato_r = _operator;
        }
    }
}
