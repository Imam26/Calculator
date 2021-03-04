using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Calculator.Pages.Partial
{
    public class DisplayModel : PageModel
    {
        public DisplayModel(List<Formula> formulaList) {
            FormulaList = formulaList;
            Init();
        }

        public DisplayModel(string text, string message, string xParam, string yParam, string zParam, List<Formula> formulaList):this(formulaList)
        {
            Text = text;
            Message = message;
            XParam = xParam;
            YParam = yParam;
            ZParam = zParam;            
        }

        public List<Formula> FormulaList { get; set; }
        public string Text { get; set; }        
        public string XParam { get; set; }        
        public string YParam { get; set; }        
        public string ZParam { get; set; }
        public string Message { get; set; }

        public SelectList ItemsFormula { get; set; }
        public void OnGet()
        {
        }

        private void Init()
        {
            if(FormulaList.Count == 0)
            {
                Formula defaultValue = new Formula();
                FormulaList.Insert(0, defaultValue);
            }

            ItemsFormula = new SelectList(FormulaList, "Id", "Value");            
        }
    }
}