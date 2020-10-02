using Core.Financeiro;
using Repository.Context;
using System.Collections.Generic;
using System.Data.Entity;
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

        public Categoria GetCategoriaById(int id)
        {
            return _context.Categorias.Where(c => c.Id == id).FirstOrDefault();
        }

        public void SaveCategoria(Categoria categoria)
        {
            if (categoria.Id == null)
                _context.Categorias.Add(categoria);
            else
                _context.Entry(categoria).State = EntityState.Modified;

            _context.SaveChanges();
        }

    }
}
