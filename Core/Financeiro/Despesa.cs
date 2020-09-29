using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Financeiro
{
    public class Despesa
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        [ForeignKey("Cobranca")]
        public int CobrancaId { get; set; }
        public string Parcelamento { get; set; }
        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }
        public string Observacao { get; set; }
        public DateTime Create { get; set; }
        public DateTime Modified { get; set; }

        public Cobranca Cobranca { get; set; }
        public Categoria Categoria { get; set; }
    }
}