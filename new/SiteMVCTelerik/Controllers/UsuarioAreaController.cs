using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteMVCTelerik.Models.ModuloBasico.VOs;
using SiteMVCTelerik.ModuloUsuarioArea.Processos;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.ModuloArea.Processos;
using SiteMVCTelerik;
namespace SiteMVCTelerik.Controllers
{
    public class UsuarioAreaController : Controller
    {

        //
        // GET: /UsuarioArea/
        private const int defaultPageSize = 10;
        public ActionResult Index()
        {
            if (ClasseAuxiliar.UsuarioLogado == null )
                return RedirectToAction("Index", "Home");
            return RedirectToAction("Listar");
        }

        public ActionResult Listar(int? page)
        {
            if (ClasseAuxiliar.UsuarioLogado == null )
                return RedirectToAction("Index", "Home");
            IUsuarioAreaProcesso processo = UsuarioAreaProcesso.Instance;
            UsuarioArea usuarioArea = new UsuarioArea();
            usuarioArea.usuario_id = ClasseAuxiliar.UsuarioLogado.id;
            var resultado = processo.Consultar(usuarioArea,TipoPesquisa.E);
            List<UsuarioArea> usuarioAreas = resultado;
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return View(resultado.ToPagedList(currentPageIndex, defaultPageSize));
        }

        //
        // GET: /StatusParcela/Details/5

        public ActionResult Detalhar(int id)
        {
            if (ClasseAuxiliar.UsuarioLogado == null || (ClasseAuxiliar.DataSelecionada == default(DateTime) || ClasseAuxiliar.AreaSelecionada == null))
                return RedirectToAction("Index", "Home");
            IUsuarioAreaProcesso processo = UsuarioAreaProcesso.Instance;
            UsuarioArea usuarioArea = new UsuarioArea();
            usuarioArea.id = id;
            ViewData.Model = processo.Consultar(usuarioArea, TipoPesquisa.E)[0];
            return View();
        }

        [HttpGet]
        public ActionResult SelecionarArea(int id)
        {
            IAreaProcesso processo = AreaProcesso.Instance;
            Area area = new Area();
            area.id = id;
            var areas = processo.Consultar(area, TipoPesquisa.E);
            Session.Add("AreaSelecionada", areas[0]);
            return RedirectToAction("Index", "Home");
        }


        //
        // GET: /StatusParcela/Create

        public ActionResult Incluir()
        {
            if (ClasseAuxiliar.UsuarioLogado == null || (ClasseAuxiliar.DataSelecionada == default(DateTime) || ClasseAuxiliar.AreaSelecionada == null))
                return RedirectToAction("Index", "Home");
            UsuarioArea usuarioArea = new UsuarioArea();
            usuarioArea.area_id = 0;
            usuarioArea.usuario_id = 0;
           
            ViewData.Model = usuarioArea;
            return View();
        }

        //
        // POST: /StatusParcela/Create

        [HttpPost]
        [ValidateInput(false)]

        public ActionResult Incluir(UsuarioArea usuarioArea, FormCollection collection)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    IUsuarioAreaProcesso processo = UsuarioAreaProcesso.Instance;
                    //usuarioArea.timeCreated = DateTime.Now;
                    //usuarioArea.timeUpdated = DateTime.Now;
                    processo.Incluir(usuarioArea);
                    processo.Confirmar();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(usuarioArea);
                }
            }
            catch
            {
                return View(usuarioArea);
            }
        }

        //
        // GET: /StatusParcela/Edit/5

        public ActionResult Alterar(int id)
        {
            if (ClasseAuxiliar.UsuarioLogado == null || (ClasseAuxiliar.DataSelecionada == default(DateTime) || ClasseAuxiliar.AreaSelecionada == null))
                return RedirectToAction("Index", "Home");
            IUsuarioAreaProcesso processo = UsuarioAreaProcesso.Instance;

            UsuarioArea usuarioArea = new UsuarioArea();
            usuarioArea.id = id;
            ViewData.Model = processo.Consultar(usuarioArea, SiteMVCTelerik.ModuloBasico.Enums.TipoPesquisa.E)[0];
            return View();
        }

        //
        // POST: /StatusParcela/Edit/5

        [HttpPost]
        public ActionResult Alterar(int id, UsuarioArea usuarioArea)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuarioArea.id = id;
                    IUsuarioAreaProcesso processo = UsuarioAreaProcesso.Instance;
                    //usuarioArea.timeUpdated = DateTime.Now;
                    processo.Alterar(usuarioArea);
                    processo.Confirmar();
                    // TODO: Add update logic here

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(usuarioArea);
                }
            }
            catch
            {
                return View();
            }
        }



        //
        // GET: /StatusParcela/Delete/5

        public ActionResult Excluir(int id)
        {
            if (ClasseAuxiliar.UsuarioLogado == null || (ClasseAuxiliar.DataSelecionada == default(DateTime) || ClasseAuxiliar.AreaSelecionada == null))
                return RedirectToAction("Index", "Home");
            IUsuarioAreaProcesso processo = UsuarioAreaProcesso.Instance;
            UsuarioArea usuarioArea = new UsuarioArea();
            usuarioArea.id = id;
            ViewData.Model = processo.Consultar(usuarioArea, SiteMVCTelerik.ModuloBasico.Enums.TipoPesquisa.E)[0];
            return View();

        }

        ////
        //// POST: /StatusParcela/Delete/5

        [HttpPost]
        public ActionResult Excluir(int id, UsuarioArea usuarioArea)
        {
            try
            {
                IUsuarioAreaProcesso processo = UsuarioAreaProcesso.Instance;

                usuarioArea.id = id;
                processo.Excluir(usuarioArea);
                processo.Confirmar();
                return RedirectToAction("Index");
            }
            catch
            {
                ViewData["Mensagem"] = "O registro não pode ser excluído pois já está sendo utilizado.";
                ViewData.Model = usuarioArea;
                return View();
            }



        }
        #region Controle de Acesso

        public ActionResult Deslogar()
        {
            Session.Remove("UsuarioLogado");
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logar()
        {

            if (ClasseAuxiliar.UsuarioLogado != null)
                return RedirectToAction("Index", "Home");
            UsuarioArea usuarioArea = new UsuarioArea();

            return View(usuarioArea);
        }

        [HttpPost]
        public ActionResult Logar(UsuarioArea usuarioArea)
        {
            if (ClasseAuxiliar.UsuarioLogado != null)
                return RedirectToAction("Index", "Home");

            //   if (ModelState.IsValid)
            {
                IUsuarioAreaProcesso processo = UsuarioAreaProcesso.Instance;
                List<UsuarioArea> usuarioAreaLista = processo.Consultar(usuarioArea, TipoPesquisa.E);
                if (usuarioAreaLista.Count != 1)
                    ModelState.AddModelError("", "");
                else
                {
                    Session.Add("UsuarioLogado", usuarioAreaLista[0]);
                    return Redirect("/");
                }
            }
            //Invalido - volta a tela mostrando os erros contidos.
            return View(usuarioArea);

        }
        #endregion
    }

}
