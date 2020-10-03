using Core.Financeiro;
using Repository.DAL.Padrao;
using System;
using System.Data.Entity;
using System.Linq;

namespace Repository.DAL.Financeiro
{
    public class CategoriaDAL : PadraoContext
    {


        public IQueryable GetCategoriaList()
        {
            return _context.Categorias.Where(c => c.Status < 99).OrderBy(c => c.Nome);
        }
        public IQueryable GetAllCategoriaList()
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
            {
                categoria.Create = DateTime.Now;
                _context.Categorias.Add(categoria);
            }
            else
            {
                categoria.Modified = DateTime.Now;
                _context.Entry(categoria).State = EntityState.Modified;
            }

            _context.SaveChanges();
        }

    }
}
