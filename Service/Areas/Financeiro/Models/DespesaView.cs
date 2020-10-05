using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Service.Areas.Financeiro.Models
{
    public class DespesaView
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Data de Compra")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Required]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required]
        [DisplayName("Valor (R$)")]
        public double Valor { get; set; }

        [DisplayName("Tipo de Cobrança")]
        public int CobrancaId { get; set; }

        public string Parcelamento { get; set; }

        [DisplayName("Categoria")]
        public int CategoriaId { get; set; }

        [DisplayName("Observação")]
        public string Observacao { get; set; }

        public DateTime Create { get; set; }
        public DateTime Modified { get; set; }

        public CobrancaView Cobranca { get; set; }
        public CategoriaView Categoria { get; set; }
    }
}