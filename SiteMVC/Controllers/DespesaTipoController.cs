using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteMVC.ModuloDespesaTipo.Processos;
using SiteMVC.Models.ModuloBasico.VOs;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.ModuloDespesaTipo.Processos;
using SiteMVC;

namespace SiteMVC.Controllers
{
    public class DespesaTipoController : Controller
    {
        //
        // GET: /DespesaTipo/
        private const int defaultPageSize = 10;
        public ActionResult Index()
        {
            return RedirectToAction("Listar");
        }

        public ActionResult Listar(int? page)
        {

            IDespesaTipoProcesso processo = DespesaTipoProcesso.Instance;
            var resultado = processo.Consultar();
            List<DespesaTipo> DespesaTipos = resultado;
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return View(resultado.ToPagedList(currentPageIndex, defaultPageSize));

            //EmprestimoEntities db = new EmprestimoEntities();
            //StatusParcela sss = new StatusParcela();
            //var teste = db.StatusParcelaSetSet.ToList();
            ////emprestimoEntities db = new emprestimoEntities();
            //ViewData.Model = teste;

            //return View();
        }

        //
        // GET: /StatusParcela/Details/5

        public ActionResult Detalhar(int id)
        {
            IDespesaTipoProcesso processo = DespesaTipoProcesso.Instance;
            DespesaTipo DespesaTipo = new DespesaTipo();
            DespesaTipo.ID = id;

            ViewData.Model = processo.Consultar(DespesaTipo, TipoPesquisa.E)[0];
            return View();
        }

        //
        // GET: /StatusParcela/Create

        public ActionResult Incluir()
        {
            DespesaTipo DespesaTipo = new DespesaTipo();
            //DespesaTipo.uf = "0";
            ViewData.Model = DespesaTipo;
            return View();
        }

        //
        // POST: /StatusParcela/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Incluir(DespesaTipo DespesaTipo, FormCollection collection)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    IDespesaTipoProcesso processo = DespesaTipoProcesso.Instance;
                    DespesaTipo.timeCreated = DateTime.Now;
                    processo.Incluir(DespesaTipo);
                    processo.Confirmar();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(DespesaTipo);
                }
            }
            catch
            {
                return View(DespesaTipo);
            }
        }

        //
        // GET: /StatusParcela/Edit/5

        public ActionResult Alterar(int id)
        {
            IDespesaTipoProcesso processo = DespesaTipoProcesso.Instance;

            DespesaTipo DespesaTipo = new DespesaTipo();
            DespesaTipo.ID = id;
            ViewData.Model = processo.Consultar(DespesaTipo, SiteMVC.ModuloBasico.Enums.TipoPesquisa.E)[0];
            return View();
        }

        //
        // POST: /StatusParcela/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Alterar(int id, DespesaTipo DespesaTipo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DespesaTipo.ID = id;
                    IDespesaTipoProcesso processo = DespesaTipoProcesso.Instance;
                    DespesaTipo.timeUpdated = DateTime.Now;
                    processo.Alterar(DespesaTipo);
                    processo.Confirmar();
                    // TODO: Add update logic here

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(DespesaTipo);
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
            IDespesaTipoProcesso processo = DespesaTipoProcesso.Instance;
            DespesaTipo DespesaTipo = new DespesaTipo();
            DespesaTipo.ID = id;
            ViewData.Model = processo.Consultar(DespesaTipo, SiteMVC.ModuloBasico.Enums.TipoPesquisa.E)[0];
            return View();

        }

        ////
        //// POST: /StatusParcela/Delete/5

        [HttpPost]
        public ActionResult Excluir(int id, DespesaTipo DespesaTipo)
        {
            // DespesaTipo DespesaTipoAux = DespesaTipo;
            try
            {
                IDespesaTipoProcesso processo = DespesaTipoProcesso.Instance;
                // DespesaTipo = new DespesaTipo();
                DespesaTipo.ID = id;
                processo.Excluir(DespesaTipo);
                processo.Confirmar();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewData["Mensagem"] = "O registro não pode ser excluído pois já está sendo utilizado.";
                ViewData.Model = DespesaTipo;
                return View();
            }
        }
    }
}
