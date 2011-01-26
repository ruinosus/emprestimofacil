﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteMVC.ModuloLancamento.Processos;
using SiteMVC.Models.ModuloBasico.VOs;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.ModuloMunicipio.Processos;
using SiteMVC;
using SiteMVC.ModuloParcela.Processos;
using SiteMVC.ModuloCliente.Processos;

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

        #region Relatorios
        public ActionResult Listar(int? page)
        {

            ILancamentoProcesso processo = LancamentoProcesso.Instance;
            var resultado = processo.Consultar();
            List<Lancamento> lancamentos = resultado;
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return View(resultado.ToPagedList(currentPageIndex, defaultPageSize));


        }

        public ActionResult VisualizarResumoLancamento()
        {
            List<Lancamento> lancamentos = new List<Lancamento>();
            ViewData["lancamentos"] = lancamentos;
            Lancamento lancamento = new Lancamento();
            lancamento.data = DateTime.Now;

            return View(lancamento);


        }

        [HttpPost]
        public ActionResult VisualizarResumoLancamento(Lancamento lancamento)
        {
            List<Lancamento> lancamentos = new List<Lancamento>();
            try
            {
                if (default(DateTime) != lancamento.data)
                {
                    ILancamentoProcesso processo = LancamentoProcesso.Instance;
                    var resultado = processo.Consultar(lancamento, TipoPesquisa.E);
                    lancamentos = resultado;
                    ViewData["lancamentos"] = lancamentos;
                    return View(lancamento);
                }
                else
                {
                    throw new Exception("Data do lançamento não informada ou inválida");
                }

            }
            catch (Exception e)
            {
                ViewData["lancamentos"] = lancamentos;
                ModelState.AddModelError("data", e.Message);
                return View(lancamento);

            }

        }

        public ActionResult VisualizarDetalheLancamento()
        {
            List<Lancamento> lancamentos = new List<Lancamento>();
            ViewData["lancamentos"] = lancamentos;
            Lancamento lancamento = new Lancamento();
            lancamento.data = DateTime.Now;

            return View(lancamento);


        }

        [HttpPost]
        public ActionResult VisualizarDetalheLancamento(Lancamento lancamento)
        {
            List<Lancamento> lancamentos = new List<Lancamento>();
            try
            {
                if (default(DateTime) != lancamento.data)
                {
                    ILancamentoProcesso processo = LancamentoProcesso.Instance;
                    var resultado = processo.Consultar(lancamento, TipoPesquisa.E);
                    lancamentos = resultado;
                    ViewData["lancamentos"] = lancamentos;
                    return View(lancamento);
                }
                else
                {
                    throw new Exception("Data do lançamento não informada ou inválida");
                }

            }
            catch (Exception e)
            {
                ViewData["lancamentos"] = lancamentos;
                ModelState.AddModelError("data", e.Message);
                return View(lancamento);

            }

        }

        public ActionResult VisualizarDetalheParcelas()
        {
            List<Parcela> parcelas = new List<Parcela>();
            ViewData["parcelas"] = parcelas;
            Parcela parcela = new Parcela();
            parcela.data_pagamento = DateTime.Now;

            return View(parcela);


        }

        [HttpPost]
        public ActionResult VisualizarDetalheParcelas(Parcela parcela)
        {
            List<Parcela> parcelas = new List<Parcela>();
            try
            {
                if (default(DateTime) != parcela.data_pagamento)
                {
                    IParcelaProcesso processo = ParcelaProcesso.Instance;
                    var resultado = processo.Consultar(parcela, TipoPesquisa.E);
                    parcelas = resultado;
                    ViewData["parcelas"] = parcelas;
                    return View(parcela);
                }
                else
                {
                    throw new Exception("Data das parcelas não informada ou inválida");
                }

            }
            catch (Exception e)
            {
                ViewData["parcelas"] = parcelas;
                ModelState.AddModelError("data_pagamento", e.Message);
                return View(parcela);

            }

        }

        public ActionResult VisualizarClientesDevedores()
        {
            List<Cliente> clientes = new List<Cliente>();
            IClienteProcesso processo = ClienteProcesso.Instance;
            var resultado = processo.ConsultarClientesDevedores();
            Cliente cliente = new Cliente();
     
            return View(resultado);
        }

        #endregion

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
            lancamento.usuario_id = 0;
            lancamento.data = DateTime.Now;
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

        public List<Parcela> parcelas { get; set; }
    }
}
