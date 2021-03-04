using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Algorithm
{
    public class FactFunction:ParserFunction
    {
        protected override double Evaluate(string data, ref int from)
        {
            int num;
            string strNum = Item.Substring(0, Item.Length - 1);

            if(!int.TryParse(strNum, out num)){
                throw new ArgumentException("Неверный формат [" + Item + "]");                
            }
            return FactTree(num);
        }

        private double ProdTree(int l, int r)
        {
            if (l > r)
                return 1;
            if (l == r)
                return l;
            if (r - l == 1)
                return (double)l * r;
            int m = (l + r) / 2;
            return ProdTree(l, m) * ProdTree(m + 1, r);
        }

        private double FactTree(int n)
        {
            if (n < 0)
                return 0;
            if (n == 0)
                return 1;
            if (n == 1 || n == 2)
                return n;
            return ProdTree(2, n);
        }
    }
}
