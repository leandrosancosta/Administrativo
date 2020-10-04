using Core.Financeiro;
using Repository.DAL.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Financeiro
{
    public class CobrancaBusiness
    {
        CobrancaDAL cd = new CobrancaDAL();
        public IQueryable GetCobrancasList()
        {
            return cd.GetCobrancasList();
        }

        public IQueryable GetAllCobrancas()
        {
            return cd.GetAllCobrancas();
        }

        public Cobranca GetCobrancaById(int id)
        {
            return cd.GetCobrancaById(id);
        }

        public void SaveCobranca(Cobranca cobranca)
        {
            cobranca.DtVencimentoFatura = cobranca.TipoCobranca.ToString().Contains("Débito") ? 0 : cobranca.DtVencimentoFatura;
            cobranca.DtFechamentoFatura = cobranca.TipoCobranca.ToString().Contains("Débito") ? 0 : cobranca.DtFechamentoFatura;
            cd.SaveCobranca(cobranca);
        }

        public bool DeleteCobranca(int id)
        {
            try{

                Cobranca cobranca = cd.GetCobrancaById(id);

                cobranca.Status = 99;

                cd.SaveCobranca(cobranca);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
