using Repository.DAL.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Financeiro
{
    public class DespesaBusiness
    {
        DespesaDAL despesaDAL = new DespesaDAL();

        public IQueryable GetCategoriaList()
        {
            return despesaDAL.GetDespesasList();
        }
    }
}
