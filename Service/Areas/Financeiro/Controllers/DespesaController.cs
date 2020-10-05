using Business.Financeiro;
using Core.Financeiro;
using Service.Areas.Financeiro.Models;
using System.Web.Mvc;

namespace Service.Areas.Financeiro.Controllers
{
    public class DespesaController : Controller
    {
        DespesaBusiness db = new DespesaBusiness();
        CategoriaBusiness catb = new CategoriaBusiness();
        CobrancaBusiness cob = new CobrancaBusiness();

        // GET: Financeiro/Despesa
        public ActionResult Index()
        {
            var despesas = db.GetCategoriaList();


            return View(despesas);
        }

        public ActionResult Create()
        {
            PopulateDropDownLists();
            return View();
        }

        [HttpPost]
        public ActionResult Create(DespesaView despesa)
        {
            if (!ModelState.IsValid)
                return View(despesa);

            Despesa nDespesa = new Despesa()
            {
                Descricao = despesa.Descricao,
                CategoriaId = despesa.CategoriaId,
                Data = despesa.Data,
                Parcelamento = despesa.Parcelamento,
            };
            return RedirectToAction("Index");
        }

        private void PopulateDropDownLists()
        {
            if (catb.GetQtdCategoria() > 0)
            {
                ViewBag.CategoriaId = new SelectList(catb.GetCategoriaList(), "Id", "Nome");
            }
            if (cob.GetQtdCobrancas() > 0)
            {
                ViewBag.CobrancaId = new SelectList(cob.GetCobrancasList(), "Id", "Nome");
            }
        }
    }
}