using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteMVCTelerik.ModuloParcela.Processos;
using SiteMVCTelerik.Models.ModuloBasico.VOs;
using SiteMVCTelerik.ModuloUsuarioArea.Processos;
using SiteMVCTelerik.ModuloBasico.Enums;

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

            List<Parcela> resultado = new List<Parcela>();//processo.Consultar(parcela, SiteMVCTelerik.ModuloBasico.Enums.TipoPesquisa.E);

            if (resultado.Count > 0)
                Session["visualizarParcelas"] = resultado;
            else
                Session["visualizarParcelas"] = null;

            Session["AreasUsuarioLogado"] = new List<UsuarioArea>();
            if (ClasseAuxiliar.UsuarioLogado != null)
            {

                IUsuarioAreaProcesso processoUsuarioArea = UsuarioAreaProcesso.Instance;
                UsuarioArea usuarioArea = new UsuarioArea();
                usuarioArea.usuario_id = ClasseAuxiliar.UsuarioLogado.ID;
                var resultadoUsuario = processoUsuarioArea.Consultar(usuarioArea, TipoPesquisa.E);
                List<UsuarioArea> usuarioAreas = resultadoUsuario;
                Session["AreasUsuarioLogado"] = usuarioAreas;
            }




            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
