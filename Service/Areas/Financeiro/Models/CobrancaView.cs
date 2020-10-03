using System.ComponentModel;

namespace Service.Areas.Financeiro.Models
{
    public enum TipoCobranca { Débito, Crédito, Conta}
    public class CobrancaView : FinanceiroBaseView
    {
        [DisplayName("Data de Fechamento")]
        public int DtFechamentoFatura { get; set; }
        [DisplayName("Data de Vencimento")]
        public int DtVencimentoFatura { get; set; }
        [DisplayName("Tipo de Cobrança")]
        public TipoCobranca TipoCobranca { get; set; }
    }
}