using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Algorithm
{
    public class Combiner
    {
        private static int GetPriority(char action)
        {
            switch (action)
            {
                case 'D': return 4;
                case '^': return 3;
                case '*':
                case '/': return 2;
                case '+':
                case '-': return 1;                
            }
            return 0;
        }

        private static bool CanCombineCells(Cell left, Cell right)
        {
            return GetPriority(left.Action) >= GetPriority(right.Action);
        }

        private static void CombineCells(Cell left, Cell right)
        {
            switch (left.Action)
            {
                case '^':
                    left.Value = Math.Pow(left.Value, right.Value);
                    break;
                case '*':
                    left.Value *= right.Value;
                    break;
                case '/':
                    left.Value /= right.Value;
                    break;
                case '+':
                    left.Value += right.Value;
                    break;
                case '-':
                    left.Value -= right.Value;
                    break;
                case 'd':
                    left.Value = GetDiceResult(left.Value, right.Value);
                    break;
            }
            left.Action = right.Action;
        }

        public static double Combine(Cell current, ref int index, List<Cell> listToMerge, bool mergeOneOnly = false)
        {
            while(index < listToMerge.Count)
            {
                Cell next = listToMerge[index++];

                while(!CanCombineCells(current, next))
                {
                    Combine(next, ref index, listToMerge, true);
                }

                CombineCells(current, next);

                if (mergeOneOnly)
                    return current.Value;
            }
            return current.Value;
        }

        private static double GetDiceResult(double count, double maxValue)
        {
            if(maxValue <= 0)
            {
                throw new ArgumentException(
                  "Неверное количество граней [" + maxValue + "]");
            }

            Random rand = new Random();

            double result = 0;

            for (int i = 0; i < count; i++)
            {
                result += rand.Next(1, (int)maxValue);
            }


            return result;
        }
    }
}
