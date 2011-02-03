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
using SiteMVC.ModuloEmprestimo.Processos;
using SiteMVC.ModuloPrestacaoConta.Processos;
using SiteMVC.ModuloDespesa.Processos;

namespace SiteMVC.Controllers
{
    public class MovimentacaoController : Controller
    {

        #region Atributos
        private const int defaultPageSize = 10;
        #endregion

        #region Relatorios

        #region Visualizar Resumo Lancamento
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

        #endregion

        #region Visualizar Detalhe Lancamento
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
        #endregion

        #region Visualizar Detalhe Parcelas
        public ActionResult VisualizarDetalheParcelas()
        {
            List<Parcela> parcelas = new List<Parcela>();
            ViewData["parcelas"] = parcelas;
            ParcelaPesquisa parcela = new ParcelaPesquisa();
            parcela.DataInicio = DateTime.Now;

            return View(parcela);


        }

        [HttpPost]
        public ActionResult VisualizarDetalheParcelas(ParcelaPesquisa parcelaPesquisa)
        {
            List<Parcela> parcelas = new List<Parcela>();
            try
            {
                if (default(DateTime) != parcelaPesquisa.DataInicio)
                {
                    IParcelaProcesso processo = ParcelaProcesso.Instance;
                    Parcela p = new Parcela();
                    p.data_pagamento = parcelaPesquisa.DataInicio;
                    var resultado = processo.Consultar(p, TipoPesquisa.E);
                    parcelas = resultado;
                    ViewData["parcelas"] = parcelas;
                    return View(parcelaPesquisa);
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
                return View(parcelaPesquisa);

            }

        }
        #endregion

        #region Visualizar Clientes Devedores
        public ActionResult VisualizarClientesDevedores()
        {
            List<Cliente> clientes = new List<Cliente>();
            IClienteProcesso processo = ClienteProcesso.Instance;
            var resultado = processo.ConsultarClientesDevedores();
            Cliente cliente = new Cliente();

            return View(resultado);
        }

        #endregion

        #region Visualizar Emprestimos Por Periodo
        public ActionResult VisualizarEmprestimosPorPeriodo()
        {
            IEmprestimoProcesso processo = EmprestimoProcesso.Instance;
            List<Emprestimo> emprestimos = processo.Consultar();
            EmprestimoPesquisa emprestimoPesquisa = new EmprestimoPesquisa();
            emprestimoPesquisa.DataInicio = DateTime.Now;
            emprestimoPesquisa.DataFim = DateTime.Now;
            ViewData["emprestimos"] = emprestimos;
            return View(emprestimoPesquisa);
        }

        [HttpPost]
        public ActionResult VisualizarEmprestimosPorPeriodo(EmprestimoPesquisa emprestimoPesquisa)
        {
            List<Emprestimo> emprestimos = new List<Emprestimo>();
            try
            {
                if (emprestimoPesquisa.DataFim < emprestimoPesquisa.DataInicio)
                    ModelState.AddModelError("DataFim", "A data final nao pode ser maior que a data inicial.");

                if (ModelState.IsValid)
                {
                    IEmprestimoProcesso processo = EmprestimoProcesso.Instance;
                    emprestimos = processo.ConsultarEmprestimosPorPeriodo(emprestimoPesquisa.DataInicio, emprestimoPesquisa.DataFim);
                    ViewData["emprestimos"] = emprestimos;
                    ViewData.Model = emprestimoPesquisa;
                    return View(emprestimoPesquisa);
                }
                else
                {
                    ViewData["emprestimos"] = emprestimos;
                    return View(emprestimoPesquisa);
                }
            }
            catch (Exception e)
            {
                ViewData["emprestimos"] = emprestimos;
                return View(emprestimoPesquisa);
            }

        }
        #endregion

        #region Visualizar Lista Clientes Por Area
        public ActionResult VisualizarListaClientesPorArea()
        {
            List<Cliente> clientes = new List<Cliente>();
            IClienteProcesso processo = ClienteProcesso.Instance;
            var resultado = processo.ConsultarClientesDevedores();
            ClientePesquisa clientePesquisa = new ClientePesquisa();
            ViewData["clientes"] = clientes;
            return View(clientePesquisa);
        }

        [HttpPost]
        public ActionResult VisualizarListaClientesPorArea(ClientePesquisa clientePesquisa)
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                //if (emprestimoPesquisa.DataFim < emprestimoPesquisa.DataInicio)
                //    ModelState.AddModelError("DataFim", "A data final nao pode ser maior que a data inicial.");

                if (ModelState.IsValid)
                {
                    IClienteProcesso processo = ClienteProcesso.Instance;
                    Cliente c = new Cliente();
                    c.area_id = clientePesquisa.area;
                    clientes = processo.Consultar(c, TipoPesquisa.E);
                    ViewData["clientes"] = clientes;
                    ViewData.Model = clientePesquisa;
                    return View(clientePesquisa);
                }
                else
                {
                    ViewData["clientes"] = clientes;
                    return View(clientePesquisa);
                }
            }
            catch (Exception e)
            {
                ViewData["clientes"] = clientes;
                return View(clientePesquisa);
            }
        }
        #endregion

        #region Visualizar Parcelas Por Periodo
        public ActionResult VisualizarParcelasPorPeriodo()
        {
            IParcelaProcesso processo = ParcelaProcesso.Instance;

            ParcelaPesquisa parcelaPesquisa = new ParcelaPesquisa();
            parcelaPesquisa.DataInicio = DateTime.Now.AddDays(1);
            parcelaPesquisa.DataFim = DateTime.Now.AddDays(1);

            List<Parcela> parcelas = processo.ConsultarParcelasPorPeriodo(parcelaPesquisa.DataInicio, parcelaPesquisa.DataFim);
            ViewData["parcelas"] = parcelas;
            return View(parcelaPesquisa);
        }

        [HttpPost]
        public ActionResult VisualizarParcelasPorPeriodo(ParcelaPesquisa parcelaPesquisa)
        {
            List<Parcela> parcelas = new List<Parcela>();
            try
            {
                if (parcelaPesquisa.DataFim < parcelaPesquisa.DataInicio)
                    ModelState.AddModelError("DataFim", "A data final nao pode ser maior que a data inicial.");

                if (ModelState.IsValid)
                {
                    IParcelaProcesso processo = ParcelaProcesso.Instance;
                    parcelas = processo.ConsultarParcelasPorPeriodo(parcelaPesquisa.DataInicio, parcelaPesquisa.DataFim);
                    ViewData["parcelas"] = parcelas;
                    ViewData.Model = parcelaPesquisa;
                    return View(parcelaPesquisa);
                }
                else
                {
                    ViewData["parcelas"] = parcelas;
                    return View(parcelaPesquisa);
                }
            }
            catch (Exception e)
            {
                ViewData["parcelas"] = parcelas;
                return View(parcelaPesquisa);
            }

        }
        #endregion

        #endregion

        #region Método Index
        public ActionResult Index()
        {
            return RedirectToAction("Listar");
        }
        #endregion

        #region Método Listar
        public ActionResult Listar(int? page)
        {

            ILancamentoProcesso processo = LancamentoProcesso.Instance;
            var resultado = processo.Consultar();
            List<Lancamento> lancamentos = resultado;
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return View(resultado.ToPagedList(currentPageIndex, defaultPageSize));

        }

        #endregion

        #region Método Detalhar
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
        #endregion

        #region Método Incluir
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
        #endregion

        #region Método Alterar

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
        #endregion

        #region Método Excluir
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
        #endregion

        #region Método Incluir Prestacao Conta

        public ActionResult IncluirPrestacaoConta()
        {

            PrestacaoConta prestacaoConta = new PrestacaoConta();



            IDespesaProcesso despesaProcesso = DespesaProcesso.Instance;
            Despesa despesa = new Despesa();
            despesa.area_id = ClasseAuxiliar.AreaSelecionada.ID;
            despesa.data = ClasseAuxiliar.DataPrestacaoContaSelecionada;

            ViewData["despesas"] = despesaProcesso.Consultar(despesa, TipoPesquisa.E);

            IEmprestimoProcesso emprestimoProcesso = EmprestimoProcesso.Instance;
            Emprestimo emp = new Emprestimo();
            emp.area_id = ClasseAuxiliar.AreaSelecionada.ID;
            emp.data_emprestimo = ClasseAuxiliar.DataPrestacaoContaSelecionada;

            ViewData["emprestimos"] = emprestimoProcesso.Consultar(emp, TipoPesquisa.E);



            ViewData["lancamentos"] = new List<Lancamento>();
            ViewData.Model = prestacaoConta;
            return View();

        }


        [HttpPost]
        public ActionResult IncluirPrestacaoConta(PrestacaoConta prestacaoConta)
        {
            IPrestacaoContaProcesso processo = PrestacaoContaProcesso.Instance;
            try
            {
                processo.Incluir(prestacaoConta);
                processo.Confirmar();
                return RedirectToAction("Index");
            }
            catch
            {
                // ViewData["Mensagem"] = "O registro não pode ser excluído pois já está sendo utilizado.";
                ViewData.Model = processo.Consultar(prestacaoConta, SiteMVC.ModuloBasico.Enums.TipoPesquisa.E)[0]; ;
                return View();
            }



        }
        #endregion

        #region Metodo Informar data Prestacao conta
        public ActionResult InformarDataPrestacaoConta()
        {
            PrestacaoContaPesquisa prestacaoContaPesquisa = new PrestacaoContaPesquisa();
            prestacaoContaPesquisa.DataPrestacaoConta = DateTime.Now;
            ViewData.Model = prestacaoContaPesquisa;
            return View();
        }

        [HttpPost]
        public ActionResult InformarDataPrestacaoConta(PrestacaoContaPesquisa prestacaoContaPesquisa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Session["DataPrestacaoContaSelecionada"] = prestacaoContaPesquisa.DataPrestacaoConta;

                    return RedirectToAction("IncluirPrestacaoConta");
                }
                else
                {
                    return View(prestacaoContaPesquisa);
                }
            }
            catch
            {
                return View(prestacaoContaPesquisa);
            }
        }
        #endregion
    }
}
