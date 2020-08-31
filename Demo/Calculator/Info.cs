using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Calculator
{
    class Info
    {
        public static Info operator +(Info one,Info two)
        {
            double result = 0;
            switch (one.operators)
            {
                case Operators.dileny:
                    {
                        result = one.number / two.number;
                        break;
                    }
                case Operators.minus:
                    {
                        result = one.number - two.number;
                        break;
                    }
                case Operators.mnojeny:
                    {
                        result = one.number * two.number;
                        break;
                    }
                case Operators.plus:
                    {
                        result = one.number + two.number;
                        break;
                    }
                default:
                    {
                        return null;
                    }

            }
            return new Info(result,two.operators,0);
        }
        public double number { private set; get; }
        public Operators operators { private set; get; }
        public int Id {private set; get; }
        public static Operators CreateOperator(char one_char)
        {
            Dictionary<char, Operators> array = new Dictionary<char, Operators>()
            {
                { '+',Operators.plus },
                { '-',Operators.minus },
                { '*',Operators.mnojeny},
                { '/',Operators.dileny}
            };
            if (array.TryGetValue(one_char, out var value)) return value;
            return Operators.nulls;
        }
        public Info(double number, Operators operators, int id)
        {
            this.number = number;
            this.operators = operators;
            this.Id = id;
        }
        public Info(string number,Operators operators, int id)
        {
            if (!double.TryParse(number, out var res)) 
                throw new Exception("Not parse double");
            this.number = res;
            this.operators = operators;
            this.Id = id;
        }
    }
}
