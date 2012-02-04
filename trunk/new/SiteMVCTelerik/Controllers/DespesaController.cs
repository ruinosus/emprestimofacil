using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteMVCTelerik.ModuloDespesa.Processos;
using SiteMVCTelerik.Models.ModuloBasico.VOs;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.ModuloDespesa.Processos;
using SiteMVCTelerik;

namespace SiteMVCTelerik.Controllers
{
    public class DespesaController : Controller
    {
        //
        // GET: /Despesa/
        private const int defaultPageSize = 10;
        public ActionResult Index()
        {
            if (ClasseAuxiliar.UsuarioLogado == null || (ClasseAuxiliar.DataSelecionada == default(DateTime) || ClasseAuxiliar.AreaSelecionada == null))
                return RedirectToAction("Index", "Home");
            return RedirectToAction("Listar");
        }

        public ActionResult Listar(int? page)
        {
            if (ClasseAuxiliar.UsuarioLogado == null || (ClasseAuxiliar.DataSelecionada == default(DateTime) || ClasseAuxiliar.AreaSelecionada == null))
                return RedirectToAction("Index", "Home");
            IDespesaProcesso processo = DespesaProcesso.Instance;
            var resultado = processo.Consultar();
            List<Despesa> Despesas = resultado;
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return View(resultado.ToPagedList(currentPageIndex, defaultPageSize));

            //emprestimoEntities db = new emprestimoEntities();
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
            if (ClasseAuxiliar.UsuarioLogado == null || (ClasseAuxiliar.DataSelecionada == default(DateTime) || ClasseAuxiliar.AreaSelecionada == null))
                return RedirectToAction("Index", "Home");
            IDespesaProcesso processo = DespesaProcesso.Instance;
            Despesa Despesa = new Despesa();
            Despesa.id = id;

            ViewData.Model = processo.Consultar(Despesa, TipoPesquisa.E)[0];
            return View();
        }

        //
        // GET: /StatusParcela/Create

        public ActionResult Incluir()
        {
            if (ClasseAuxiliar.UsuarioLogado == null || (ClasseAuxiliar.DataSelecionada == default(DateTime) || ClasseAuxiliar.AreaSelecionada == null))
                return RedirectToAction("Index", "Home");
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
                Despesa.data = ClasseAuxiliar.DataSelecionada;
                if (ModelState.IsValid)
                {
                    IDespesaProcesso processo = DespesaProcesso.Instance;
                    //Despesa.timeCreated = DateTime.Now;
                    //Despesa.timeUpdated = DateTime.Now;
                    Despesa.area_id = ClasseAuxiliar.AreaSelecionada.id;
                    processo.Incluir(Despesa);
                    processo.Confirmar();
                    return RedirectToAction("IncluirPrestacaoConta", "Movimentacao");
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
            if (ClasseAuxiliar.UsuarioLogado == null || (ClasseAuxiliar.DataSelecionada == default(DateTime) || ClasseAuxiliar.AreaSelecionada == null))
                return RedirectToAction("Index", "Home");
            IDespesaProcesso processo = DespesaProcesso.Instance;

            Despesa Despesa = new Despesa();
            Despesa.id = id;
            ViewData.Model = processo.Consultar(Despesa, SiteMVCTelerik.ModuloBasico.Enums.TipoPesquisa.E)[0];
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
                    despesa.id = id;
                    IDespesaProcesso processo = DespesaProcesso.Instance;
                    //despesa.timeUpdated = DateTime.Now;
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
            if (ClasseAuxiliar.UsuarioLogado == null || (ClasseAuxiliar.DataSelecionada == default(DateTime) || ClasseAuxiliar.AreaSelecionada == null))
                return RedirectToAction("Index", "Home");
            IDespesaProcesso processo = DespesaProcesso.Instance;
            Despesa Despesa = new Despesa();
            Despesa.id = id;
            ViewData.Model = processo.Consultar(Despesa, SiteMVCTelerik.ModuloBasico.Enums.TipoPesquisa.E)[0];
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
                Despesa.id = id;
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
