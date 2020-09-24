using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WApp.Service.Models
{
    public class Despesa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DespesaId { get; set; }
        [DisplayName("Data da compra")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        [DisplayName("Valor (R$)")]
        public double Valor { get; set; }
        [ForeignKey("Cobranca")]
        [DisplayName("Cobrança")]
        public int CobrancaId { get; set; }
        public Cobranca Cobranca { get; set; }
        public string Parcelamento { get; set; }
        [ForeignKey("Categoria")]
        [DisplayName("Categoria")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        [DisplayName("Observação")]
        public string Observacao { get; set; }
        [ForeignKey("Situacao")]
        [DisplayName("Situação")]
        public int SituacaoId { get; set; }
        public Situacao Situacao { get; set; }
        public DateTime Create { get; set; }
        public DateTime Modified { get; set; }
    }

    public class FinanceiroBase
    {
              
        public string Nome { get; set; }
        public int Status { get; set; }
        public DateTime Create { get; set; }
        public DateTime Modified { get; set; }

        public ICollection<Despesa> Despesas { get; set; }
    }

    public class Categoria : FinanceiroBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoriaId { get; set; }
    }

    public class Situacao : FinanceiroBase { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SituacaoId { get; set; }
    }

    public class Cobranca : FinanceiroBase
    {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CobrancaId { get; set; }
    }
}