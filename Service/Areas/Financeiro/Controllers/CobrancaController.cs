using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Service.Areas.Financeiro.Controllers
{
    public class CobrancaController : Controller
    {
        // GET: Financeiro/Cobranca
        public ActionResult Index()
        {
            return View();
        }
    }
}