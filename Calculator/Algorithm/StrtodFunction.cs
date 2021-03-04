using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Algorithm
{
    public class StrtodFunction:ParserFunction
    {        
        protected override double Evaluate(string data, ref int from)
        {
            double num;
            if (!Double.TryParse(Item.Replace('.',','), out num))
            {
                throw new ArgumentException("Неверный формат [" + Item + "]");
            }
            return num;
        }
    }
}
