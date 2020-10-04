using System.ComponentModel;

namespace Service.Areas.Financeiro.Models
{
    public enum TipoCobranca { Débito, Crédito, Conta}
    public class CobrancaView : FinanceiroBaseView
    {
        [DisplayName("Dia de Fechamento")]
        public int DtFechamentoFatura { get; set; }
        [DisplayName("Dia de Vencimento")]
        public int DtVencimentoFatura { get; set; }
        [DisplayName("Tipo de Cobrança")]
        public TipoCobranca TipoCobranca { get; set; }
    }
}