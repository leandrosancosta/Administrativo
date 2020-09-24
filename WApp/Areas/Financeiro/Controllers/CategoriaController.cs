using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WApp.Service.Context;
using WApp.Service.Models;

namespace WApp.Service.Areas.Financeiro.Controllers
{
    public class CategoriaController : Controller
    {
        private DataContext _context = new DataContext();
        // GET: Financeiro/Categoria
        public ActionResult Index()
        {
            IQueryable<Categoria> categoria;

            categoria = _context.Categorias.OrderBy(c => c.CategoriaId);

            return View(categoria);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}