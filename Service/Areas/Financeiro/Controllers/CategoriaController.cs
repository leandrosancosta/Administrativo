using Business.Financeiro;
using Core.Financeiro;
using Service.Areas.Financeiro.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Service.Areas.Financeiro.Controllers
{
    public class CategoriaController : Controller
    {
        private CategoriaBusiness cb = new CategoriaBusiness();

        public ActionResult Index()
        {
            try
            {
                var categorias = cb.GetCategoriaList();

                return View(categorias);

            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult Create()
        {
            ConfigureList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoriaView categoria)
        {
            try
            {
                Categoria nCategoria = new Categoria
                {
                    Nome = categoria.Nome,
                    Status = categoria.Status,
                    Create = DateTime.Now,
                };

                cb.SaveCategoria(nCategoria);

                ViewBag.Message = "Categoria " + categoria.Nome + " salva com sucesso";
                ViewBag.TypeMsg = "success";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(categoria);
            }

        }


        private void ConfigureList(CategoriaView categoria = null)
        {
            if (categoria == null)
            {
                ViewBag.Status = new SelectList(new List<SelectListItem>
                {
                    new SelectListItem { Text = "Ativo", Value = "1" },
                    new SelectListItem { Text = "Inativo" , Value = "0"}
                }, "Value", "Text", "1"
                );
            }
            else
            {
                ViewBag.Status = new SelectList(new List<SelectListItem>
                {
                    new SelectListItem { Text = "Ativo", Value = "1" },
                    new SelectListItem { Text = "Inativo" , Value = "0"}
                }, "Value", "Text", categoria.Status.ToString()
                );
            }
        }
    }
}