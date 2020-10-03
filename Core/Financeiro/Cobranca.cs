using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Financeiro
{
    public class Cobranca : FinanceiroBase
    {
        public int DtFechamentoFatura { get; set; }
        public int DtVencimentoFatura { get; set; }
        public string TipoCobranca { get; set; }
    }
}
