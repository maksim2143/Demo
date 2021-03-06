﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo.Calculator
{
    class Calc
    {
        public double Get(List<Info> list)
        {
            while (list.Count > 1)
            {
                int index = GetIndex(list);
                if (index == -1) break;
                var one = list.ElementAt(index);
                var two = list.ElementAtOrDefault(index+1);
                if (two == null) return two.number;
                Info value_res = one.Create(two);
                list.RemoveAt(index+1);
                list[index] = value_res;
            }
            return list.ElementAt(0).number;
        }
        private int GetIndex(in List<Info> list)
        {
            foreach (var item in operators)
            {
                var res = list.FindIndex(x => x.operato_r == item);
                if (res != -1) return res;
            }
            return -1;
           
        }
        readonly Operator[] operators = new[]{
               Operator.multiplication 
               ,Operator.dash 
               ,Operator.plus
               ,Operator.minus
            };
    }
}
