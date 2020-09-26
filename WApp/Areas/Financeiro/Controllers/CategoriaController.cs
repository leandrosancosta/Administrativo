﻿using System;
using System.Data.Entity;
using System.Linq;
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
            ViewBagStatus();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoria.Create = DateTime.Now;
                    _context.Categorias.Add(categoria);

                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(categoria);
                }
            }
            catch (Exception ex)
            {
                //
            }

            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            Categoria categoria = _context.Categorias.Where(c => c.CategoriaId == id).FirstOrDefault();
            ViewBagStatus(categoria);

            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    categoria.Modified = DateTime.Now;
                    _context.Entry(categoria).State = EntityState.Modified;

                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(categoria);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }

        }

        #region metódos privados
        private void ViewBagStatus(Categoria categoria = null)
        {
            var Status = new[]
            {
                new SelectListItem {Value = "1", Text = "Ativo"},
                new SelectListItem {Value = "0", Text = "Inativo"}
            };

            if (categoria == null)
            {
                ViewBag.Status = new SelectList(Status, "Value", "Text");
            }
            else
            {
                ViewBag.Status = new SelectList(Status, "Value", "Text", categoria.Status);
            }
        }

        #endregion
    }
}