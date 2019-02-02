using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Dominio;
using Dominio.Enums;

namespace FaleMais.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var listaPrecos =  new PrecoOrigemDestino().GerarListaPrecos();
            GridView gridView = new GridView();
            gridView.DataSource = listaPrecos;
            gridView.DataBind();

            using (System.IO.StringWriter sw = new System.IO.StringWriter())
            {
                using (System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw))
                {
                    gridView.RenderControl(htw);
                    ViewBag.GridViewValoresMinuto = sw.ToString();
                }
            }
            var comparacao = new PlanoComparacao().GerarListaComparacao(20, Plano.Todos);
            return View(listaPrecos);
        }
        [HttpPost]
        public ActionResult GerarComparacoes(int min, int plan)
        {
            var comparacao = new List<PlanoComparacao>();

            var valores = Enum.GetValues(typeof(Plano));
            foreach (var item in valores)
            {
                if (item.GetHashCode() == plan)
                {
                    comparacao = new PlanoComparacao().GerarListaComparacao(min, (Plano)item);
                }
            }
            
            return PartialView(@"~\Views\Home\Resultado.cshtml",comparacao);
        }
    }
}