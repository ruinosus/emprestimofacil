using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteMVC.ModuloParcela.Processos;
using SiteMVC.Models.ModuloBasico.VOs;

namespace MvcApplication2.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IParcelaProcesso processo = ParcelaProcesso.Instance;

            Parcela parcela = new Parcela();

            parcela.visualizada = "F";

            List<Parcela> resultado = processo.Consultar(parcela, SiteMVC.ModuloBasico.Enums.TipoPesquisa.E);

            if (resultado.Count > 0)
                Session["visualizarParcelas"] = resultado;
            else
                Session["visualizarParcelas"] = null;
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
