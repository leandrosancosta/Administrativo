using Core.Financeiro;
using Repository.Context;
using System.Collections.Generic;
using System.Linq;

namespace Repository.DAL.Financeiro
{
    public class CategoriaDAL
    {
        private DataContext _context = new DataContext();


        public IQueryable GetCategoriaList()
        {
            return _context.Categorias.OrderBy(c => c.Nome);
        }

    }
}
