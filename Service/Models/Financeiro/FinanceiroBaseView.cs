using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Service.Models.Financeiro
{
    public class FinanceiroBaseView
    {
        [Required(ErrorMessage = "Informe o nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o status")]
        public int Status { get; set; }
        public DateTime Create { get; set; }
        public DateTime Modified { get; set; }
    }
}