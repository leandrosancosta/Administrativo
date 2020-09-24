using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WApp.Service.Areas.Financeiro.Controllers
{
    public class DespesaController : Controller
    {
        // GET: Financeiro/Despesa
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}