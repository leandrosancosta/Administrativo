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
                if (ModelState.IsValid)
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
                else
                {
                    return View(categoria);
                }
            }
            catch (Exception ex)
            {
                return View(categoria);
            }
        }

        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    var ret = cb.GetCategoriaById((int)id);

                    CategoriaView categoria = new CategoriaView()
                    {
                        Id = ret.Id,
                        Nome = ret.Nome,
                        Status = ret.Status
                    };

                    ConfigureList();

                    return View(categoria);
                }
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(CategoriaView categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Categoria eCategoria = new Categoria()
                    {
                        Id = categoria.Id,
                        Nome = categoria.Nome,
                        Status = categoria.Status,
                        Modified = DateTime.Now
                    };

                    cb.SaveCategoria(eCategoria);

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(categoria);
                }
            }
            catch
            {
                return View(categoria);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(FormCollection form)
        {
            try
            {
                int.TryParse(form["deleteId"], out int id);

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }


        private void ConfigureList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Value = "0", Text = "Inativo" });
            list.Add(new SelectListItem() { Value = "1", Text = "Ativo" });
            ViewBag.List = list;
        }
    }
}