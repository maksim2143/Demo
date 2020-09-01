using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Calculator
{
   public static class expansion_method
    {
        public static Info Create(this Info one,Info two)
        {
            double result = 0;
            switch (one.operato_r)
            {
                case Operator.dash:
                    {
                        result = one.number / two.number;
                        break;
                    }
                case Operator.minus:
                    {
                        result = one.number - two.number;
                        break;
                    }
                case Operator.multiplication:
                    {
                        result = one.number * two.number;
                        break;
                    }
                case Operator.plus:
                    {
                        result = one.number + two.number;
                        break;
                    }
                default:
                    {
                        return null;
                    }

            }
            return new Info(result, two.operato_r);
        }
    }
}
