using Microsoft.AspNetCore.Mvc;
using Projeto_Aniversario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Aniversario.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(DataModel dataModel)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    ValidarData(DateTime.Parse(dataModel.DataAniversario));

                    int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                    int dob = int.Parse(DateTime.Parse(dataModel.DataAniversario).ToString("yyyyMMdd"));
                    int idade = (now - dob) / 10000;

                    var dataInput = dataModel.DataAniversario.Split("-");
                    var data = DateTime.Now.ToString().Split("/");





                    if ((dataInput[2] == data[0])&& (dataInput[1] == data[1]))
                    {
                        TempData["MensagemSucesso"] = "Você tem " + idade + " anos. Parabens pelo seu aniversário!.";
                    }
                    else
                    {
                        TempData["MensagemFracasso"] = "Você tem " + idade + " anos."; 

                    }
                }
                catch(Exception e)
                {
                    TempData["MensagemErro"] = "Erro : " + e.Message;
                }
            }

            return View();
        }

        public DateTime ValidarData (DateTime data)
        {
            if (data > DateTime.Now)
                throw new Exception("Data invalida.");

            return data;
        }
    }
}
