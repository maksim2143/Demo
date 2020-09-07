using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Demo.Calculator.Brackets
{
    class Pars
    {
        private Stack<string> GetQuery(string text)
        {
            Stack<string> query = new Stack<string>();
            while (this.regex.IsMatch(text))
            {
                var match = this.regex.Match(text).Groups["value"].Value;
                query.Push(match);
                text = match;
            }
            return query;
        }
        private double? MatchQuery(Stack<string> stack)
        {
            double? doubles = null;
            string demo = null;
            while (stack.Count > 0)
            {
                string element = stack.Pop();
                var copy_element = element;
                if (doubles != null)
                {
                    element = element.Replace("(" + demo + ")", doubles.ToString());
                }
                doubles = this.core.Start(element);
                demo = copy_element;
            }
            return doubles;
        }
        public double Start(string text)
        {
            var query = GetQuery(text);
            if (query.Count == 0)
            {
                return core.Start(text);
            }
            var result = MatchQuery(query);

            return result.Value;
        }
        Core core;
        Regex regex;
        public Pars()
        {
            this.regex = new Regex(@"\((?<value>.+)\)");
            this.core = new Core();
        }
    }
}
