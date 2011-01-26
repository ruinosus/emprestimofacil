using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteMVC.ModuloParcela.Processos;
using SiteMVC.Models.ModuloBasico.VOs;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.ModuloMunicipio.Processos;
using SiteMVC;
using SiteMVC.ModuloCliente.Processos;
using SiteMVC.ModuloEmprestimo.Processos;

namespace SiteMVC.Controllers
{
    public class ParcelaController : Controller
    {
        //
        // GET: /Parcela/
        private const int defaultPageSize = 10;
        public ActionResult Index()
        {
            return RedirectToAction("Listar");
        }

        public ActionResult Informar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Informar(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    IParcelaProcesso processo = ParcelaProcesso.Instance;
                    Parcela parcela = new Parcela();
                    parcela.ID = id.Value;
                    List<Parcela> resultado = processo.Consultar(parcela, SiteMVC.ModuloBasico.Enums.TipoPesquisa.E);
                    if (resultado.Count > 0)
                        if (resultado[0].statusparcela_id == 2)
                        {
                            if (resultado[0].sequencial > 1 && resultado[0].sequencial != 0)
                            {
                                parcela.ID = parcela.ID - 1;
                                List<Parcela> resultado2 = processo.Consultar(parcela, SiteMVC.ModuloBasico.Enums.TipoPesquisa.E);

                                if (resultado2.Count > 0)
                                {
                                    if (resultado2[0].statusparcela_id == 2)
                                    {
                                        ModelState.AddModelError("id", "Você deve dar baixa na parcela de número: [" + parcela.ID + "]");
                                        return View();
                                    }
                                }
                            }

                            return RedirectToAction("BaixarParcela", new { id = id.Value });
                        }
                        else
                        {
                            ModelState.AddModelError("id", "A parcela informada já foi paga.");
                            return View();
                        }
                    else
                    {
                        ModelState.AddModelError("id", "Parcela Não encontrada.");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("id", "Informe o número da parcela");
                    return View();
                }

            }
            catch (Exception)
            {
                ModelState.AddModelError("id", "Informe um valor numérico.");
                return View();
            }
        }


        public ActionResult ImprimirParcelas(int ID)
        {
            IEmprestimoProcesso processoEmprestimo = EmprestimoProcesso.Instance;
            Emprestimo emprestimo = new Emprestimo();
            emprestimo.ID = ID;
            emprestimo = processoEmprestimo.Consultar(emprestimo, SiteMVC.ModuloBasico.Enums.TipoPesquisa.E)[0];

            Session["EmprestimoSelecionado"] = emprestimo;
            IParcelaProcesso processo = ParcelaProcesso.Instance;
            Parcela parcela = new Parcela();
            parcela.emprestimo_id = ID;
            var resultado = processo.Consultar(parcela, TipoPesquisa.E);

            ViewData["quantidadePaginas"] = Math.Ceiling((decimal)resultado.Count / 5);

            List<Parcela> parcelas = resultado;

            return View(resultado);


        }

        public ActionResult ParcelaEmprestimo(int? page, int ID)
        {
            IEmprestimoProcesso processoEmprestimo = EmprestimoProcesso.Instance;
            Emprestimo emprestimo = new Emprestimo();
            emprestimo.ID = ID;
            emprestimo = processoEmprestimo.Consultar(emprestimo, SiteMVC.ModuloBasico.Enums.TipoPesquisa.E)[0];

            Session["EmprestimoSelecionado"] = emprestimo;
            IParcelaProcesso processo = ParcelaProcesso.Instance;
            Parcela parcela = new Parcela();
            parcela.emprestimo_id = ID;
            var resultado = processo.Consultar(parcela, TipoPesquisa.E);



            List<Parcela> parcelas = resultado;
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return View(resultado.ToPagedList(currentPageIndex, defaultPageSize));


        }

        public ActionResult BaixarParcela(int id)
        {
            IParcelaProcesso processo = ParcelaProcesso.Instance;
            Parcela parcela = new Parcela();
            parcela.ID = id;
            parcela = processo.Consultar(parcela, SiteMVC.ModuloBasico.Enums.TipoPesquisa.E)[0];
            parcela.data_pagamento = DateTime.Now;
            parcela.valor_pago = parcela.valor;
            ViewData.Model = parcela;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult BaixarParcela(int id, Parcela parcela)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    float valorPago = parcela.valor_pago.Value;
                    DateTime dataAtual = parcela.data_pagamento.Value;
                    parcela.ID = id;

                    IParcelaProcesso processo = ParcelaProcesso.Instance;
                    parcela = processo.Consultar(parcela, SiteMVC.ModuloBasico.Enums.TipoPesquisa.Ou)[0];
                    parcela.valor_pago = valorPago;
                    parcela.data_pagamento = dataAtual;
                    parcela.statusparcela_id = 1;
                    if (parcela.data_pagamento.Value.Date < DateTime.Now.Date)
                    {
                        parcela.visualizada = "F";
                    }
                    parcela.timeUpdated = DateTime.Now;
                    processo.Alterar(parcela);
                    processo.Confirmar();
                    // TODO: Add update logic here

                    return RedirectToAction("Informar");
                }
                else
                {
                    return View(parcela);
                }
            }
            catch (Exception e)
            {
                return View(parcela);
            }
        }

        //
        // GET: /StatusParcela/Details/5


        //
        // GET: /StatusParcela/Edit/5

        public ActionResult Alterar(int id)
        {
            IParcelaProcesso processo = ParcelaProcesso.Instance;
            Parcela parcela = new Parcela();
            parcela.ID = id;
            ViewData.Model = processo.Consultar(parcela, SiteMVC.ModuloBasico.Enums.TipoPesquisa.E)[0];
            return View();
        }


        //
        // POST: /StatusParcela/Edit/5

        [HttpPost]
        public ActionResult Alterar(int id, Parcela parcela)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    float valorPago = parcela.valor_pago.Value;

                    parcela.ID = id;

                    IParcelaProcesso processo = ParcelaProcesso.Instance;
                    parcela = processo.Consultar(parcela, SiteMVC.ModuloBasico.Enums.TipoPesquisa.E)[0];
                    parcela.valor_pago = valorPago;
                    parcela.statusparcela_id = 1;
                    parcela.data_pagamento = DateTime.Now;
                    parcela.timeUpdated = DateTime.Now;
                    processo.Alterar(parcela);
                    processo.Confirmar();
                    // TODO: Add update logic here

                    return RedirectToAction("ParcelaEmprestimo", new { id = ClasseAuxiliar.EmprestimoSelecionado.ID });
                }
                else
                {
                    return View(parcela);
                }
            }
            catch (Exception e)
            {
                return View(parcela);
            }
        }



        public ActionResult VisualizarParcelas()
        {
            if (Session["VisualizarParcelas"] != null)
            {
                ViewData.Model = (List<Parcela>)Session["VisualizarParcelas"];
                return View();
            }
            else
                return RedirectToAction("Index", "Home");
        }


        //
        // POST: /StatusParcela/Edit/5

        [HttpPost]
        public ActionResult VisualizarParcelas(FormCollection form)
        {
            List<Parcela> parcelas = null;
            if (Session["VisualizarParcelas"] != null)
            {
                parcelas = (List<Parcela>)Session["VisualizarParcelas"];
            }
            else
                return RedirectToAction("Index", "Home");


            try
            {
                foreach (Parcela parcela in parcelas)
                {
                    IParcelaProcesso processo = ParcelaProcesso.Instance;
                    parcela.timeUpdated = DateTime.Now;
                    parcela.visualizada = "V";
                    processo.Alterar(parcela);
                    processo.Confirmar();
                }
                Session["VisualizarParcelas"] = null;
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                ViewData.Model = (List<Parcela>)Session["VisualizarParcelas"];
                return View();

            }
        }

    }
}
