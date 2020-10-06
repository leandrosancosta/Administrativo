using Core.Financeiro;
using MySql.Data.MySqlClient;
using Repository.DAL.Padrao;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Repository.DAL.Financeiro
{
    public class CategoriaDAL : PadraoContext
    {


        public IQueryable GetCategoriaList()
        {
            return _context.Categorias.Where(c => c.Status < 99).OrderBy(c => c.Nome);
        }

        public List<Categoria> GetActivedCategorias()
        {
            MySqlParameter p1 = new MySqlParameter();
            p1.ParameterName = "@status";
            p1.Value = 1;
            p1.MySqlDbType = MySqlDbType.Int32;

            return _context.Categorias.SqlQuery("Select * from Categorias where status = @status",p1).ToList();
        }

        public int GetQtdCategoria()
        {
            return _context.Categorias.Where(c => c.Status < 99).Count();
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
                Categoria cat = GetCategoriaById((int)categoria.Id);
                categoria.Create = cat.Create;
                categoria.Modified = DateTime.Now;
                //_context.Entry(categoria).State = EntityState.Modified;
                _context.Categorias.AddOrUpdate<Categoria>(categoria);
            }

            _context.SaveChanges();
        }

    }
}
