﻿using Core.Financeiro;
using Repository.DAL.Financeiro;
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

        public Categoria GetCategoriaById(int id)
        {
            return categoriaDAL.GetCategoriaById(id);
        }

        public void SaveCategoria(Categoria categoria)
        {
            categoriaDAL.SaveCategoria(categoria);
        }
    }
}
