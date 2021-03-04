using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Algorithm
{
    public class RdFunction:ParserFunction
    {
        protected override double Evaluate(string data, ref int from)
        {
            double arg = Parser.LoadAndCalculate(data, ref from, Parser.END_ARG);
            return Math.Floor(arg);
        }
    }
}
