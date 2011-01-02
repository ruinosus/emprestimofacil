using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteMVC.ModuloBasico;
using SiteMVC.ModuloStatusParcela.Processos;
using SiteMVC.Models.ModuloBasico.VOs;
using SiteMVC.ModuloBasico.Enums;


namespace SiteMVC.Controllers
{
    public class StatusParcelaController : Controller
    {
        //
        // GET: /StatusParcela/

        public ActionResult Index()
        {
            return RedirectToAction("Listar");
        }

        public ActionResult Listar()
        {
            IStatusParcelaProcesso processo = StatusParcelaProcesso.Instance;
            ViewData.Model = processo.Consultar();
            //EmprestimoEntities db = new EmprestimoEntities();
            //StatusParcela sss = new StatusParcela();
            //var teste = db.StatusParcelaSetSet.ToList();
            ////emprestimoEntities db = new emprestimoEntities();
            //ViewData.Model = teste;

            return View();
        }

        //
        // GET: /StatusParcela/Details/5

        public ActionResult Detalhar(int id)
        {
            IStatusParcelaProcesso processo = StatusParcelaProcesso.Instance;
            StatusParcela statusParcela = new StatusParcela();
            statusParcela.ID = id;
            ViewData.Model = processo.Consultar(statusParcela, TipoPesquisa.E)[0];
            return View();
        }

        //
        // GET: /StatusParcela/Create

        public ActionResult Incluir()
        {
            IStatusParcelaProcesso processo = StatusParcelaProcesso.Instance;
            ViewData["dropTeste"] = processo.Consultar();
            ViewData.Model = new StatusParcela();
            return View();
        }

        //
        // POST: /StatusParcela/Create

        [HttpPost]
        public ActionResult Incluir(StatusParcela statusParcela)
        {
            try
            {
                //if (string.IsNullOrEmpty(statusParcela.descricao))
                //    ModelState.AddModelError("descricao", "Informe a descrição.");
              
                if (ModelState.IsValid)
                {
                    IStatusParcelaProcesso processo = StatusParcelaProcesso.Instance;
                    processo.Incluir(statusParcela);
                    processo.Confirmar();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(statusParcela);
                }
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /StatusParcela/Edit/5

        public ActionResult Alterar(int id)
        {
            IStatusParcelaProcesso processo = StatusParcelaProcesso.Instance;
            StatusParcela statusParcela = new StatusParcela();
            statusParcela.ID = id;
            ViewData.Model = processo.Consultar(statusParcela, SiteMVC.ModuloBasico.Enums.TipoPesquisa.E)[0];
            return View();
        }

        //
        // POST: /StatusParcela/Edit/5

        [HttpPost]
        public ActionResult Alterar(int id, StatusParcela statusParcela)
        {
            try
            {
                //if (string.IsNullOrEmpty(statusParcela.descricao))
                //    ModelState.AddModelError("descricao", "Informe a descrição.");
              
                if (ModelState.IsValid)
                {
                    statusParcela.ID = id;
                    IStatusParcelaProcesso processo = StatusParcelaProcesso.Instance;
                    processo.Alterar(statusParcela);
                    processo.Confirmar();
                    // TODO: Add update logic here

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(statusParcela);
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
            IStatusParcelaProcesso processo = StatusParcelaProcesso.Instance;
            StatusParcela statusParcela = new StatusParcela();
            statusParcela.ID = id;
            ViewData.Model = processo.Consultar(statusParcela, SiteMVC.ModuloBasico.Enums.TipoPesquisa.E)[0];
            return View();
            
        }

        ////
        //// POST: /StatusParcela/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                IStatusParcelaProcesso processo = StatusParcelaProcesso.Instance;
                StatusParcela statusParcela = new StatusParcela();
                statusParcela.ID = id;
                processo.Excluir(statusParcela);
                processo.Confirmar();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
