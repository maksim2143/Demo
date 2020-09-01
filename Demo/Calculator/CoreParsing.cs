using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Demo.Calculator
{
    class CoreParsing
    {
        public List<Info> Get(string text)
        {
            var result =   this.pars.Matches(text);
            List<Info> list = new List<Info>();
            foreach (Match item in result)
            {
                var number = item.Groups["number"].Value;
                var operat = item.Groups["value"].Value;
                var info = new Info(number, Info.CreateOperator(operat.ElementAtOrDefault(0)));
                list.Add(info);
            }
            var match = endRegexMath.Match(text);
            var info_two = new Info(match.Value,Operator.empty);
            list.Add(info_two);
            return list;
        }
        Regex pars;
        Regex endRegexMath;
        public CoreParsing()
        {
            this.pars = new Regex(@"(?<number>[0-9]+)(?<value>[+/*-])");
            this.endRegexMath = new Regex(@"[^+/*-]+$");
        }
    }
}
