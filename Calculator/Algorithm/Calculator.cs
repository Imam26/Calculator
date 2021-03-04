using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Algorithm
{
    public class Parser
    {
        public const char END_ARG = ')';
        public const char START_ARG = '(';
        public const char END_LINE = '\n';

        public static double LoadAndCalculate(string data,ref int from, char to = END_LINE)
        {
            if (from >= data.Length || data[from] == to)
            {
                throw new ArgumentException(
                  "Неверный формат [" + data + "]");
            }
            List<Cell> listToMerge = new List<Cell>();
            StringBuilder item = new StringBuilder();

            do 
            {
                char ch = data[from++];
                if (StillCollecting(item.ToString(), ch, to))
                {
                    item.Append(ch);
                    if (from < data.Length && data[from] != to)
                    {
                        continue;
                    }
                }

                ParserFunction func = new ParserFunction(data, ref from, item.ToString(), ch);
                double value = func.GetValue(data, ref from);
                
                char action = ValidAction(ch) ? ch : UpdateAction(data, ref from, ch, to);

                listToMerge.Add(new Cell(value, action));
                item.Clear();

            } while (from < data.Length && data[from] != to);

            if (from < data.Length && (data[from] == END_ARG || data[from] == to))
            { 
                from++;
            }

            Cell baseCell = listToMerge[0];
            int index = 1;

            return Combiner.Combine(baseCell, ref index, listToMerge);
        }

        private static bool StillCollecting(string item, char ch, char to)
        {
            char stopCollecting = (to == END_ARG || to == END_LINE) ? END_ARG : to;
            return (item.Length == 0 && (ch == '+' || ch == '-' || ch == END_ARG)) || !(ValidAction(ch) || ch == START_ARG || ch == stopCollecting);
        }
        private static bool ValidAction(char ch)
        {
            return ch == '*' || ch == '/' || ch == '+' || ch == '-' || ch == '^' || ch == 'D';
        }

        private static char UpdateAction(string item, ref int from, char ch, char to)
        {
            if (from >= item.Length || item[from] == END_ARG || item[from] == to)
            {
                return END_ARG;
            }

            int index = from;
            char res = ch;
            while (!ValidAction(res) && index < item.Length)
            { 
                res = item[index++];
            }

            from = ValidAction(res) ? index : index > from ? index - 1 : from;
            return res;
        }
    }
}
