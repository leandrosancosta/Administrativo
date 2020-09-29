using Business.Financeiro;
using System.Web.Mvc;

namespace Service.Areas.Financeiro.Controllers
{
    public class CategoriaController : Controller
    {
        private CategoriaBusiness cb = new CategoriaBusiness();

        public ActionResult Index()
        {
            var categorias = cb.GetCategoriaList();
            return View(categorias);
        }
    }
}