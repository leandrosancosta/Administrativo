using Core.Financeiro;
using Repository.DAL.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Financeiro
{
    public class CategoriaBusiness
    {
        private CategoriaDAL categoriaDAL = new CategoriaDAL();

        public IQueryable GetCategoriaList()
        {
            return categoriaDAL.GetCategoriaList();
        }

        public List<Categoria> GetActivedCategorias()
        {
            return categoriaDAL.GetActivedCategorias();
        }

        public IQueryable GetAllCategoriaList()
        {
            return categoriaDAL.GetAllCategoriaList();
        }

        public int GetQtdCategoria()
        {
            return categoriaDAL.GetQtdCategoria();
        }

        public Categoria GetCategoriaById(int id)
        {
            return categoriaDAL.GetCategoriaById(id);
        }

        public void SaveCategoria(Categoria categoria)
        {
            categoriaDAL.SaveCategoria(categoria);
        }


        public bool DeleteCategoria(int id)
        {
            try
            {
                Categoria categoria = GetCategoriaById(id);
                categoria.Status = 99;
                SaveCategoria(categoria);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
