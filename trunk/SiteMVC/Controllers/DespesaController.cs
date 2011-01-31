using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteMVC.ModuloDespesa.Processos;
using SiteMVC.Models.ModuloBasico.VOs;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.ModuloDespesa.Processos;
using SiteMVC;

namespace SiteMVC.Controllers
{
    public class DespesaController : Controller
    {
        //
        // GET: /Despesa/
        private const int defaultPageSize = 10;
        public ActionResult Index()
        {
            return RedirectToAction("Listar");
        }

        public ActionResult Listar(int? page)
        {

            IDespesaProcesso processo = DespesaProcesso.Instance;
            var resultado = processo.Consultar();
            List<Despesa> Despesas = resultado;
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
            IDespesaProcesso processo = DespesaProcesso.Instance;
            Despesa Despesa = new Despesa();
            Despesa.ID = id;

            ViewData.Model = processo.Consultar(Despesa, TipoPesquisa.E)[0];
            return View();
        }

        //
        // GET: /StatusParcela/Create

        public ActionResult Incluir()
        {
            Despesa Despesa = new Despesa();
            Despesa.data = DateTime.Now;
            //Despesa.uf = "0";
            ViewData.Model = Despesa;
            return View();
        }

        //
        // POST: /StatusParcela/Create

        [HttpPost]
        [ValidateInput(false)]

        public ActionResult Incluir(Despesa Despesa, FormCollection collection)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    IDespesaProcesso processo = DespesaProcesso.Instance;
                    Despesa.timeCreated = DateTime.Now;
                    processo.Incluir(Despesa);
                    processo.Confirmar();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(Despesa);
                }
            }
            catch
            {
                return View(Despesa);
            }
        }

        //
        // GET: /StatusParcela/Edit/5

        public ActionResult Alterar(int id)
        {
            IDespesaProcesso processo = DespesaProcesso.Instance;

            Despesa Despesa = new Despesa();
            Despesa.ID = id;
            ViewData.Model = processo.Consultar(Despesa, SiteMVC.ModuloBasico.Enums.TipoPesquisa.E)[0];
            return View();
        }

        //
        // POST: /StatusParcela/Edit/5

        [HttpPost]
        public ActionResult Alterar(int id, Despesa despesa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    despesa.ID = id;
                    IDespesaProcesso processo = DespesaProcesso.Instance;
                    despesa.timeUpdated = DateTime.Now;
                    processo.Alterar(despesa);
                    processo.Confirmar();
                    // TODO: Add update logic here

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(despesa);
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
            IDespesaProcesso processo = DespesaProcesso.Instance;
            Despesa Despesa = new Despesa();
            Despesa.ID = id;
            ViewData.Model = processo.Consultar(Despesa, SiteMVC.ModuloBasico.Enums.TipoPesquisa.E)[0];
            return View();

        }

        ////
        //// POST: /StatusParcela/Delete/5

        [HttpPost]
        public ActionResult Excluir(int id, Despesa Despesa)
        {
            // Despesa DespesaAux = Despesa;
            try
            {
                IDespesaProcesso processo = DespesaProcesso.Instance;
                // Despesa = new Despesa();
                Despesa.ID = id;
                processo.Excluir(Despesa);
                processo.Confirmar();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewData["Mensagem"] = "O registro não pode ser excluído pois já está sendo utilizado.";
                ViewData.Model = Despesa;
                return View();
            }
        }
    }
}
