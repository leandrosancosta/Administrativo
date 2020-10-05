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
        DespesaDAL despesa = new DespesaDAL();

        public IQueryable GetCategoriaList()
        {
            return despesa.GetDespesasList();
        }
    }
}
