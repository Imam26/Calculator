using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Services
{
    public interface iFormulaRepository
    {
        List<Formula> GetFormulaList();
        bool Insert(Formula item);
        bool Update(Formula item);
    }
}
