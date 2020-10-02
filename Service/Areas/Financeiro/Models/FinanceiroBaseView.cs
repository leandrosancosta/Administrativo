using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Service.Areas.Financeiro.Models
{
    public class FinanceiroBaseView
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Informe o nome")]
        [MaxLength(50,ErrorMessage = "Tamanho máximo de 50 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o status")]
        public int Status { get; set; }
        public DateTime Create { get; set; }
        public DateTime Modified { get; set; }
    }
}