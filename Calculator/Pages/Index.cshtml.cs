using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculator.Models;
using Calculator.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Calculator.Pages
{
    public class IndexModel : PageModel
    {
        private iParser _iParser;
        private iFormulaRepository _iFormulaRepository;
        public IndexModel(iParser iParser, iFormulaRepository iFormulaRepository)
        {
            _iParser = iParser;
            _iFormulaRepository = iFormulaRepository;
            Init();
        }
        
        [BindProperty(SupportsGet = true)]
        public string Text { get; set; }

        [BindProperty(SupportsGet = true)]
        public string XParam { get; set; }

        [BindProperty(SupportsGet = true)]
        public string YParam { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ZParam { get; set; }

        public List<Formula> FormulaList { get; set; }

        [BindProperty(SupportsGet = true)]
        public Formula Formula { get; set; }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost(string submit)
        {
            string message = string.Empty;

            try
            {
                switch (submit)
                {
                    case "=":
                        Dictionary<string, string> Params = new Dictionary<string, string>();

                        if (!string.IsNullOrEmpty(XParam))
                            Params["x"] = XParam;

                        if (!string.IsNullOrEmpty(YParam))
                            Params["y"] = YParam;

                        if (!string.IsNullOrEmpty(ZParam))
                            Params["z"] = ZParam;

                        Text = _iParser.Parse(Text.Replace(" ", ""), Params).ToString();
                        break;
                    case "Save":
                        if(Formula.Id == 0 && !string.IsNullOrEmpty(Text))
                        {
                            var list = _iFormulaRepository.GetFormulaList();

                            Formula.Id = 1;

                            if (list.Count() != 0)
                                Formula.Id = list.Last().Id + 1;

                            Formula.Value = Text;
                            _iFormulaRepository.Insert(Formula);

                            message = "Формула сохранена";
                        }
                        else if (!string.IsNullOrEmpty(Text))
                        {
                            Formula.Value = Text;
                            _iFormulaRepository.Update(Formula);

                            message = "Формула обновлена";
                        }
                                                   
                        break;
                }
                
            }
            catch(ArgumentException ex)
            {
                message = ex.Message;
            }
            catch (Exception)
            {
                message  = "Ошибка";
            }

            return new PartialViewResult
            {
                ViewName = "Partial/Display",
                ViewData = new ViewDataDictionary<Calculator.Pages.Partial.DisplayModel>(ViewData,
                            new Partial.DisplayModel(Text, message, XParam, YParam, ZParam, FormulaList))
            };
        }

        private void Init()
        {
            FormulaList = _iFormulaRepository.GetFormulaList();
        }
    }
}
