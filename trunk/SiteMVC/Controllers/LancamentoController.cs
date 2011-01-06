using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteMVC.ModuloLancamento.Processos;
using SiteMVC.Models.ModuloBasico.VOs;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.ModuloMunicipio.Processos;
using SiteMVC;

namespace SiteMVC.Controllers
{
    public class LancamentoController : Controller
    {
        //
        // GET: /Lancamento/
        private const int defaultPageSize = 10;
        public ActionResult Index()
        {
            return RedirectToAction("Listar");
        }

        public ActionResult Listar(int? page)
        {
             
            ILancamentoProcesso processo = LancamentoProcesso.Instance;
            var resultado =  processo.Consultar();
            List<Lancamento> lancamentos = resultado;
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return View(resultado.ToPagedList(currentPageIndex, defaultPageSize));
		

        }

        //
        // GET: /StatusParcela/Details/5

        public ActionResult Detalhar(int id)
        {
            ILancamentoProcesso processo = LancamentoProcesso.Instance;
            Lancamento lancamento = new Lancamento();
            lancamento.ID = id;
            ViewData.Model = processo.Consultar(lancamento, TipoPesquisa.E)[0];
            return View();
        }

        //
        // GET: /StatusParcela/Create

        public ActionResult Incluir()
        {
            Lancamento lancamento = new Lancamento();
            lancamento.lancamentotipo_id = 0;
            lancamento.usuario_id= 0;
         
            ViewData.Model = lancamento;
            return View();
        }

        //
        // POST: /StatusParcela/Create

        [HttpPost]
        [ValidateInput(false)]

        public ActionResult Incluir(Lancamento lancamento, FormCollection collection)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    ILancamentoProcesso processo = LancamentoProcesso.Instance;
                    lancamento.timeCreated = DateTime.Now;
                    processo.Incluir(lancamento);
                    processo.Confirmar();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(lancamento);
                }
            }
            catch
            {
                    return View(lancamento);
            }
        }

        //
        // GET: /StatusParcela/Edit/5

        public ActionResult Alterar(int id)
        {
            ILancamentoProcesso processo = LancamentoProcesso.Instance;
            Lancamento lancamento = new Lancamento();
            lancamento.ID = id;
            ViewData.Model = processo.Consultar(lancamento, SiteMVC.ModuloBasico.Enums.TipoPesquisa.E)[0];
            return View();
        }

        //
        // POST: /StatusParcela/Edit/5

        [HttpPost]
        public ActionResult Alterar(int id, Lancamento lancamento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    lancamento.ID = id;
                    ILancamentoProcesso processo = LancamentoProcesso.Instance;
                    lancamento.timeUpdated = DateTime.Now;
                    processo.Alterar(lancamento);
                    processo.Confirmar();
                    // TODO: Add update logic here

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(lancamento);
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
            ILancamentoProcesso processo = LancamentoProcesso.Instance;
            Lancamento lancamento = new Lancamento();
            lancamento.ID = id;
            ViewData.Model = processo.Consultar(lancamento, SiteMVC.ModuloBasico.Enums.TipoPesquisa.E)[0];
            return View();
            
        }

        ////
        //// POST: /StatusParcela/Delete/5

        [HttpPost]
        public ActionResult Excluir(int id, Lancamento lancamento)
        {
            ILancamentoProcesso processo = LancamentoProcesso.Instance;
            try
            {
                
             
                lancamento.ID = id;
                processo.Excluir(lancamento);
                processo.Confirmar();
                return RedirectToAction("Index");
            }
            catch
            {
                lancamento.ID = id;
                ViewData["Mensagem"] = "O registro não pode ser excluído pois já está sendo utilizado.";
             ViewData.Model = processo.Consultar(lancamento, SiteMVC.ModuloBasico.Enums.TipoPesquisa.E)[0]; ;
                return View();
            }


            
        }
    }
}
