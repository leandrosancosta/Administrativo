using Repository.DAL.Padrao;
using System.Linq;
using System.Data.Entity;
using Core.Financeiro;

namespace Repository.DAL.Financeiro
{
    public class DespesaDAL : PadraoContext
    {
        public IQueryable GetDespesasList()
        {
            return _context.Despesas.Include(c => c.Categoria).Include(ct => ct.Cobranca).OrderBy(d => d.Data);
        }

        public Despesa GetDespesaById()
        {
            return null;
        }
    }
}
