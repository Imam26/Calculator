using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Algorithm
{
    public class IdentityFunction:ParserFunction
    {
        protected override double Evaluate(string data, ref int from)
        {
            return Parser.LoadAndCalculate(data, ref from, Parser.END_ARG);
        }
    }
}
