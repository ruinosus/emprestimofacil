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
using SiteMVC.ModuloParcela.Processos;
using SiteMVC.ModuloCliente.Processos;
using SiteMVC.ModuloEmprestimo.Processos;

namespace SiteMVC.Controllers
{
    public class MovimentacaoController : Controller
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

        public ActionResult VisualizarClientesDevedores()
        {
            List<Cliente> clientes = new List<Cliente>();
            IClienteProcesso processo = ClienteProcesso.Instance;
            var resultado = processo.ConsultarClientesDevedores();
            Cliente cliente = new Cliente();

            return View(resultado);
        }

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
                    clientes = processo.Consultar(c,TipoPesquisa.E);
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
