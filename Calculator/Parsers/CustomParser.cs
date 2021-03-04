using Calculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculator.Algorithm;

namespace Calculator.Parsers
{
    public class CustomParser : iParser
    {
        public double Parse(string data, Dictionary<string, string> param)
        {
            int from = 0;

            ParserFunction.ClearParameters();

            if (param.ContainsKey("x"))
                ParserFunction.AddParameter("x", param["x"]);

            if (param.ContainsKey("y"))
                ParserFunction.AddParameter("y", param["y"]);

            if (param.ContainsKey("z"))
                ParserFunction.AddParameter("z", param["z"]);

            ParserFunction.AddFunction("sqrt", new SqrtFunction());
            ParserFunction.AddFunction("ru", new RuFunction());
            ParserFunction.AddFunction("rd", new RdFunction());
            ParserFunction.AddFunction("!", new FactFunction());

            return Parser.LoadAndCalculate(data, ref from);
        }
    }
}
