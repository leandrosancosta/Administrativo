using Core.Financeiro;
using Repository.DAL.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Financeiro
{
    class CobrancaBusiness
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
