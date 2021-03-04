using Calculator.Models;
using Calculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Repositories
{
    public class FormulaRepository : iFormulaRepository
    {
        private static List<Formula> _formulaList = new List<Formula>();
        public List<Formula> GetFormulaList()
        {
            return _formulaList;
        }

        public bool Insert(Formula item)
        {
            _formulaList.Add(item);
            return true;
        }

        public bool Update(Formula item)
        {
            var updated = _formulaList.Where(x => x.Id == item.Id).SingleOrDefault();
            var index = _formulaList.IndexOf(updated);
            _formulaList[index].Value = item.Value;
            return true;
        }
    }
}
