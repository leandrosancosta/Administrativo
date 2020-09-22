using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WApp.Service.Models
{
    public class FinanceiroView
    {
        public int Id { get; set; }
        [DisplayName("Data da compra")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        [DisplayName("Valor (R$)")]
        public double Valor { get; set; }
        [DisplayName("Cobrança")]
        public int CobrancaId { get; set; }
        public string Parcelamento { get; set; }
        [DisplayName("Categoria")]
        public int CategoriaId { get; set; }
        [DisplayName("Observação")]
        public string Observacao { get; set; }
        [DisplayName("Status")]
        public int StatusId { get; set; }
        public DateTime Create { get; set; }
        public DateTime Modified { get; set; }
    }

    public class FinanceiroBase
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Status { get; set; }
        public DateTime Create { get; set; }
        public DateTime Modified { get; set; }
    }

    public class CategoriaView : FinanceiroBase
    {

    }

    public class StatusView : FinanceiroBase
    {

    }

    public class CobrancaView : FinanceiroBase
    {

    }
}