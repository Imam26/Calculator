using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Algorithm
{
    public class ParserFunction
    {
        private ParserFunction _implementation;
        private static IdentityFunction _idFunction = new IdentityFunction();
        private static StrtodFunction _strtodFunction = new StrtodFunction();
        private static Dictionary<string, ParserFunction> _functions = new Dictionary<string, ParserFunction>();
        private static Dictionary<string, string> _parameters = new Dictionary<string, string>();

        public ParserFunction()
        {
            _implementation = this;
        }

        public string Item { protected get; set; }

        public ParserFunction(string data, ref int from, string item, char ch)
        {
            if (item.Length == 0 && ch == Parser.START_ARG)
            {
                _implementation = _idFunction;
                return;
            }

            if (item.Length > 0 && _functions.TryGetValue(item.Substring(item.Length - 1), out _implementation))
            {
                _implementation.Item = item;
                return;
            }  
            
            if (_functions.TryGetValue(item, out _implementation))            
                return;

            string value;
            if (_parameters.TryGetValue(item, out value) && value != null)
                _strtodFunction.Item = value;
            else
                _strtodFunction.Item = item;

            _implementation = _strtodFunction;
        }

        public static void AddFunction(string name, ParserFunction function)
        {
            _functions[name] = function;
        }

        public static void AddParameter(string name, string value)
        {
            _parameters[name] = value;
        }

        public double GetValue(string data, ref int from)
        {
            return _implementation.Evaluate(data, ref from);
        }

        protected virtual double Evaluate(string data, ref int from)
        {            
            return 0;
        }

        public static void ClearParameters()
        {
            _parameters.Clear();
        }
    }
}
