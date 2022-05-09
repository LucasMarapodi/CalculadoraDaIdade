using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Aniversario.Models
{
    public class DataModel
    {
        [Required(ErrorMessage ="Insira uma data.")]
        public string DataAniversario { get; set; }

    }
}
