using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Algorithm
{
    public class Cell
    {
        public Cell(double value, char action)
        {
            Value = value;
            Action = action;
        }

        public double Value { get; set; }
        public char Action { get; set; }
    }
}
