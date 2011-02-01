using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteMVC.Models.ModuloBasico.VOs;
using SiteMVC.ModuloUsuarioArea.Processos;
using SiteMVC.ModuloBasico.Enums;

namespace SiteMVC.Controllers
{
    public class UsuarioAreaController : Controller
    {

        //
        // GET: /UsuarioArea/
        private const int defaultPageSize = 10;
        public ActionResult Index()
        {
            return RedirectToAction("Listar");
        }

        public ActionResult Listar(int? page)
        {

            IUsuarioAreaProcesso processo = UsuarioAreaProcesso.Instance;
            UsuarioArea usuarioArea = new UsuarioArea();
            usuarioArea.usuario_id = ClasseAuxiliar.UsuarioLogado.ID;
            var resultado = processo.Consultar(usuarioArea,TipoPesquisa.E);
            List<UsuarioArea> usuarioAreas = resultado;
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return View(resultado.ToPagedList(currentPageIndex, defaultPageSize));
        }

        //
        // GET: /StatusParcela/Details/5

        public ActionResult Detalhar(int id)
        {
            IUsuarioAreaProcesso processo = UsuarioAreaProcesso.Instance;
            UsuarioArea usuarioArea = new UsuarioArea();
            usuarioArea.ID = id;
            ViewData.Model = processo.Consultar(usuarioArea, TipoPesquisa.E)[0];
            return View();
        }

        [HttpGet]
        public ActionResult SelecionarArea(int id)
        {
            Session.Add("AreaSelecionada", id);
            return RedirectToAction("Index", "Home");
        }


        //
        // GET: /StatusParcela/Create

        public ActionResult Incluir()
        {
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
                    usuarioArea.timeCreated = DateTime.Now;
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
            IUsuarioAreaProcesso processo = UsuarioAreaProcesso.Instance;

            UsuarioArea usuarioArea = new UsuarioArea();
            usuarioArea.ID = id;
            ViewData.Model = processo.Consultar(usuarioArea, SiteMVC.ModuloBasico.Enums.TipoPesquisa.E)[0];
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
                    usuarioArea.ID = id;
                    IUsuarioAreaProcesso processo = UsuarioAreaProcesso.Instance;
                    usuarioArea.timeUpdated = DateTime.Now;
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
            IUsuarioAreaProcesso processo = UsuarioAreaProcesso.Instance;
            UsuarioArea usuarioArea = new UsuarioArea();
            usuarioArea.ID = id;
            ViewData.Model = processo.Consultar(usuarioArea, SiteMVC.ModuloBasico.Enums.TipoPesquisa.E)[0];
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

                usuarioArea.ID = id;
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
