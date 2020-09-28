using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WApp.Service.Context;
using WApp.Service.Models;

namespace WApp.Service.Areas.Financeiro.Controllers
{
    public class CobrancaController : Controller
    {
        private DataContext _context = new DataContext();
        
        public ActionResult Index()
        {
            IQueryable<Cobranca> cobrancas;

            cobrancas = _context.Cobrancas.OrderBy(c => c.Nome);

            return View(cobrancas);
        }

        public ActionResult Create()
        {
            SetViewBag();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cobranca categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoria.Create = DateTime.Now;
                    _context.Cobrancas.Add(categoria);

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

            Cobranca cobranca = _context.Cobrancas.Where(c => c.CobrancaId == id).FirstOrDefault();
            SetViewBag(cobranca);

            return View(cobranca);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cobranca categoria)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(FormCollection form)
        {
            try
            {
                int.TryParse(form["deleteId"], out int id);

                Cobranca categoria = _context.Cobrancas.Where(c => c.CobrancaId == id).FirstOrDefault();

                _context.Cobrancas.Remove(categoria);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        #region metódos privados
        private void SetViewBag(Cobranca cobranca = null)
        {
            var Status = new[]
            {
                new SelectListItem {Value = "1", Text = "Ativo"},
                new SelectListItem {Value = "0", Text = "Inativo"}
            };

            var Tipo = new[]
            {
                new SelectListItem {Value = "0", Text = "Débito"},
                new SelectListItem {Value = "1", Text = "Crédito"},
            };


            if (cobranca == null)
            {
                ViewBag.Status = new SelectList(Status, "Value", "Text");
                ViewBag.Tipo = new SelectList(Tipo, "Value", "Text");
            }
            else
            {
                ViewBag.Status = new SelectList(Status, "Value", "Text", cobranca.Status);
                ViewBag.Tipo = new SelectList(Tipo, "Value", "Text");
            }
        }

        #endregion
    }
}
