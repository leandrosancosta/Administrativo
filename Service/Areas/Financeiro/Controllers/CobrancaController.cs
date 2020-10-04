using Business.Financeiro;
using Core.Financeiro;
using Service.Areas.Financeiro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Service.Areas.Financeiro.Controllers
{
    public class CobrancaController : Controller
    {
        CobrancaBusiness cb = new CobrancaBusiness();
        // GET: Financeiro/Cobranca
        public ActionResult Index()
        {
            var cobrancas = cb.GetCobrancasList();

            return View(cobrancas);
        }

        public ActionResult Create()
        {
            ConfigureList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CobrancaView cobranca)
        {
            try
            {

                if (!ModelState.IsValid)
                    return View(cobranca);

                Cobranca nCobranca = new Cobranca()
                {
                    Nome = cobranca.Nome,
                    Status = cobranca.Status,
                    DtFechamentoFatura = cobranca.DtFechamentoFatura,
                    DtVencimentoFatura = cobranca.DtVencimentoFatura,
                    TipoCobranca = cobranca.TipoCobranca.ToString()
                };

                cb.SaveCobranca(nCobranca);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(cobranca);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            var ret = cb.GetCobrancaById((int)id);

            TipoCobranca tipo = new TipoCobranca();

            switch (ret.TipoCobranca)
            {
                case "Crédito":
                    tipo = TipoCobranca.Crédito;
                    break;
                case "Débito":
                    tipo = TipoCobranca.Débito;
                    break;
                case "Conta":
                    tipo = TipoCobranca.Conta;
                    break;
            }

            CobrancaView cobranca = new CobrancaView()
            {
                Id = ret.Id,
                Nome = ret.Nome,
                Status = ret.Status,
                TipoCobranca = tipo,
                DtFechamentoFatura = ret.DtFechamentoFatura,
                DtVencimentoFatura = ret.DtVencimentoFatura
            };
            ConfigureList();
            return View(cobranca);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CobrancaView cobranca)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(cobranca);


                Cobranca eCobranca = new Cobranca()
                {
                    Id = cobranca.Id,
                    Nome = cobranca.Nome,
                    DtFechamentoFatura = cobranca.DtFechamentoFatura,
                    DtVencimentoFatura = cobranca.DtVencimentoFatura,
                    TipoCobranca = cobranca.TipoCobranca.ToString(),
                    Status = cobranca.Status
                };

                cb.SaveCobranca(eCobranca);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(cobranca);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(FormCollection form)
        {
            try
            {
                int.TryParse(form["deleteId"], out int id);
                if (cb.DeleteCobranca(id))
                {
                    ViewBag.Message = "Categoria " + form["Nome"] + " salva com sucesso";
                    ViewBag.TypeMsg = "success";
                }
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