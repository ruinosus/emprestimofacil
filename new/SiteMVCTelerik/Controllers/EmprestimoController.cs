﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteMVCTelerik.ModuloEmprestimo.Processos;
using SiteMVCTelerik.Models.ModuloBasico.VOs;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.ModuloMunicipio.Processos;
using SiteMVCTelerik;
using SiteMVCTelerik.ModuloCliente.Processos;
using SiteMVCTelerik.Helpers;

namespace SiteMVCTelerik.Controllers
{
    public class EmprestimoController : Controller
    {
        //
        // GET: /Emprestimo/
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
            IEmprestimoProcesso processo = EmprestimoProcesso.Instance;
            var resultado = processo.Consultar();
            List<Emprestimo> emprestimos = resultado;
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return View(resultado.ToPagedList(currentPageIndex, defaultPageSize));


        }





        public ActionResult IncluirEmprestimoCliente()
        {
            if (ClasseAuxiliar.UsuarioLogado == null || (ClasseAuxiliar.DataSelecionada == default(DateTime) || ClasseAuxiliar.AreaSelecionada == null))
                return RedirectToAction("Index", "Home");
            Emprestimo emprestimo = new Emprestimo();
            emprestimo.cliente_id = ClasseAuxiliar.ClienteSelecionado.id;
            emprestimo.prazospagamento_id = 0;
            emprestimo.data_emprestimo = DateTime.Now;
            emprestimo.tipoemprestimo_id = 0;
            //emprestimo.WeekDays = new List<SiteMVCTelerik.ModuloBasico.Enums.DiasUteis>();

            //emprestimo.WeekDays.Add(DiasUteis.Segunda);
            //emprestimo.WeekDays.Add(DiasUteis.Terca);
            //emprestimo.WeekDays.Add(DiasUteis.Quarta);
            //emprestimo.WeekDays.Add(DiasUteis.Quinta);
            //emprestimo.WeekDays.Add(DiasUteis.Sexta);
            //emprestimo.WeekDays.Add(DiasUteis.Sabado);
            //emprestimo.WeekDays.Add(DiasUteis.Domingo);

            //var rolesList = new List<CheckBoxListInfo>();
            //foreach (var dias in emprestimo.WeekDays)
            //{
            //    rolesList.Add(new CheckBoxListInfo(dias, dias, false));
            //}
            List<int> diasUteis = new List<int>();
            diasUteis.Add(1);
            diasUteis.Add(2);
            diasUteis.Add(3);
            diasUteis.Add(4);
            diasUteis.Add(5);
            ViewData["DiasUteis"] = ClasseAuxiliar.CarregarCheckBoxEnum<DiasUteis>(diasUteis);
            emprestimo.data_emprestimo =  ClasseAuxiliar.DataSelecionada;

            emprestimo.usuario_id = ClasseAuxiliar.UsuarioLogado.id;
            ViewData.Model = emprestimo;
            return View();
        }

        //
        // POST: /StatusParcela/Create

        [HttpPost]
        // [ValidateInput(false)]

        public ActionResult IncluirEmprestimoCliente(Emprestimo emprestimo, string[] dias)
        {

            try
            {
                IClienteProcesso processoCliente = ClienteProcesso.Instance;
                List<Cliente> resultCliente = processoCliente.ConsultarClientesDevedores();
                
                var resultCiente2 = (from cc in resultCliente
                                    where cc.id ==  ClasseAuxiliar.ClienteSelecionado.id
                                    select cc).SingleOrDefault();


                if(resultCiente2!= null && resultCiente2.id == ClasseAuxiliar.ClienteSelecionado.id )
                    ModelState.AddModelError("valor", "O Cliente está com dividas em aberto.");


                List<int> diasUteis = new List<int>();
                List<DayOfWeek> dayOfWeeks = new List<DayOfWeek>();
                if(dias!=null)
                for (int i = 0; i < dias.Length; i++)
                {
                    if (Convert.ToInt16(dias[i]) == (int)DayOfWeek.Friday)
                        dayOfWeeks.Add(DayOfWeek.Friday);
                    if (Convert.ToInt16(dias[i]) == (int)DayOfWeek.Monday)
                        dayOfWeeks.Add(DayOfWeek.Monday);
                    if (Convert.ToInt16(dias[i]) == (int)DayOfWeek.Saturday)
                        dayOfWeeks.Add(DayOfWeek.Saturday);
                    if (Convert.ToInt16(dias[i]) == (int)DayOfWeek.Sunday)
                        dayOfWeeks.Add(DayOfWeek.Sunday);
                    if (Convert.ToInt16(dias[i]) == (int)DayOfWeek.Thursday)
                        dayOfWeeks.Add(DayOfWeek.Thursday);
                    if (Convert.ToInt16(dias[i]) == (int)DayOfWeek.Tuesday)
                        dayOfWeeks.Add(DayOfWeek.Tuesday);
                    if (Convert.ToInt16(dias[i]) == (int)DayOfWeek.Wednesday)
                        dayOfWeeks.Add(DayOfWeek.Wednesday);


                        diasUteis.Add(Convert.ToInt16(dias[i]));
                }


                ViewData["DiasUteis"] = ClasseAuxiliar.CarregarCheckBoxEnum<DiasUteis>(diasUteis);

                var teste = Request;
                IEmprestimoProcesso processo = EmprestimoProcesso.Instance;
                //if (ModelState.IsValid)
                {
                    emprestimo.cliente_id = ClasseAuxiliar.ClienteSelecionado.id;
                    emprestimo.usuario_id = ClasseAuxiliar.UsuarioLogado.id;
                    emprestimo.area_id = ClasseAuxiliar.AreaSelecionada.id;
                    //emprestimo.timeCreated = DateTime.Now;
                    //emprestimo.timeUpdated = DateTime.Now;
                    processo.Incluir(emprestimo, dayOfWeeks);
                    processo.Confirmar();
                    return RedirectToAction("EmprestimoCliente", new { id = ClasseAuxiliar.ClienteSelecionado.id });
                }
                //else
                //{
                //    return View(emprestimo);
                //}
            }
            catch (Exception e)
            {
                return View(emprestimo);
            }
        }

        public ActionResult EmprestimoCliente(int? page, int ID)
        {
            IClienteProcesso processoCliente = ClienteProcesso.Instance;
            Cliente cliente = new Cliente();
            cliente.id = ID;
            cliente = processoCliente.Consultar(cliente, SiteMVCTelerik.ModuloBasico.Enums.TipoPesquisa.E)[0];

            Session["ClienteSelecionado"] = cliente;
            IEmprestimoProcesso processo = EmprestimoProcesso.Instance;
            Emprestimo emprestimo = new Emprestimo();
            emprestimo.cliente_id = ID;
            var resultado = processo.Consultar(emprestimo, TipoPesquisa.E);



            List<Emprestimo> emprestimos = resultado;
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return View(resultado.ToPagedList(currentPageIndex, defaultPageSize));


        }

        //
        // GET: /StatusParcela/Details/5

        public ActionResult Detalhar(int id)
        {
            IEmprestimoProcesso processo = EmprestimoProcesso.Instance;
            Emprestimo emprestimo = new Emprestimo();
            emprestimo.id = id;
            ViewData.Model = processo.Consultar(emprestimo, TipoPesquisa.E)[0];
            return View();
        }

        //
        // GET: /StatusParcela/Create

        public ActionResult Incluir()
        {
            if (ClasseAuxiliar.UsuarioLogado == null || (ClasseAuxiliar.DataSelecionada == default(DateTime) || ClasseAuxiliar.AreaSelecionada == null))
                return RedirectToAction("Index", "Home");
            Emprestimo emprestimo = new Emprestimo();
            emprestimo.cliente_id = 0;
            emprestimo.data_emprestimo = DateTime.Now;
            emprestimo.prazospagamento_id = 0;
            emprestimo.tipoemprestimo_id = 0;
            emprestimo.usuario_id = ClasseAuxiliar.UsuarioLogado.id;
            List<int> diasUteis = new List<int>();
            diasUteis.Add(1);
            diasUteis.Add(2);
            diasUteis.Add(3);
            diasUteis.Add(4);
            diasUteis.Add(5);
            ViewData["DiasUteis"] = ClasseAuxiliar.CarregarCheckBoxEnum<DiasUteis>(diasUteis);
            ViewData.Model = emprestimo;
            return View();
        }

        //
        // POST: /StatusParcela/Create

        [HttpPost]
        [ValidateInput(false)]

        public ActionResult Incluir(Emprestimo emprestimo, string[] dias)
        {

            try
            {

                IClienteProcesso processoCliente = ClienteProcesso.Instance;
                List<Cliente> resultCliente = processoCliente.ConsultarClientesDevedores();

                var resultCiente2 = (from cc in resultCliente
                                     where cc.id == ClasseAuxiliar.ClienteSelecionado.id
                                     select cc).SingleOrDefault();


                if (resultCiente2 != null && resultCiente2.id == ClasseAuxiliar.ClienteSelecionado.id)
                    ModelState.AddModelError("valor", "O Cliente está com dividas em aberto.");

                List<int> diasUteis = new List<int>();
                List<DayOfWeek> dayOfWeeks = new List<DayOfWeek>();
                if (dias != null)
                    for (int i = 0; i < dias.Length; i++)
                    {
                        if (Convert.ToInt16(dias[i]) == (int)DayOfWeek.Friday)
                            dayOfWeeks.Add(DayOfWeek.Friday);
                        if (Convert.ToInt16(dias[i]) == (int)DayOfWeek.Monday)
                            dayOfWeeks.Add(DayOfWeek.Monday);
                        if (Convert.ToInt16(dias[i]) == (int)DayOfWeek.Saturday)
                            dayOfWeeks.Add(DayOfWeek.Saturday);
                        if (Convert.ToInt16(dias[i]) == (int)DayOfWeek.Sunday)
                            dayOfWeeks.Add(DayOfWeek.Sunday);
                        if (Convert.ToInt16(dias[i]) == (int)DayOfWeek.Thursday)
                            dayOfWeeks.Add(DayOfWeek.Thursday);
                        if (Convert.ToInt16(dias[i]) == (int)DayOfWeek.Tuesday)
                            dayOfWeeks.Add(DayOfWeek.Tuesday);
                        if (Convert.ToInt16(dias[i]) == (int)DayOfWeek.Wednesday)
                            dayOfWeeks.Add(DayOfWeek.Wednesday);


                        diasUteis.Add(Convert.ToInt16(dias[i]));
                    }

                ViewData["DiasUteis"] = ClasseAuxiliar.CarregarCheckBoxEnum<DiasUteis>(diasUteis);
                //if (ModelState.IsValid)
                //{
                    IEmprestimoProcesso processo = EmprestimoProcesso.Instance;
                    emprestimo.area_id = ClasseAuxiliar.AreaSelecionada.id;
                    emprestimo.usuario_id= ClasseAuxiliar.UsuarioLogado.id;
                    emprestimo.data_emprestimo = ClasseAuxiliar.DataSelecionada;
                    //emprestimo.timeCreated = DateTime.Now;
                    //emprestimo.timeUpdated = DateTime.Now;
                    processo.Incluir(emprestimo, dayOfWeeks);
                    processo.Confirmar();
                    return RedirectToAction("IncluirPrestacaoConta","Movimentacao");
                //}
                //else
                //{
                //    return View(emprestimo);
                //}
            }
            catch(Exception e)
            {
                return View(emprestimo);
            }
        }

        //
        // GET: /StatusParcela/Edit/5

        public ActionResult Alterar(int id)
        {
            if (ClasseAuxiliar.UsuarioLogado == null || (ClasseAuxiliar.DataSelecionada == default(DateTime) || ClasseAuxiliar.AreaSelecionada == null))
                return RedirectToAction("Index", "Home");
            IEmprestimoProcesso processo = EmprestimoProcesso.Instance;
            Emprestimo emprestimo = new Emprestimo();
            emprestimo.id = id;
            ViewData.Model = processo.Consultar(emprestimo, SiteMVCTelerik.ModuloBasico.Enums.TipoPesquisa.E)[0];
            return View();
        }

        //
        // POST: /StatusParcela/Edit/5

        [HttpPost]
        public ActionResult Alterar(int id, Emprestimo emprestimo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    emprestimo.id = id;
                    IEmprestimoProcesso processo = EmprestimoProcesso.Instance;
                    //emprestimo.timeUpdated = DateTime.Now;
                    processo.Alterar(emprestimo);
                    processo.Confirmar();
                    // TODO: Add update logic here

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(emprestimo);
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
            IEmprestimoProcesso processo = EmprestimoProcesso.Instance;
            Emprestimo emprestimo = new Emprestimo();
            emprestimo.id = id;
            ViewData.Model = processo.Consultar(emprestimo, SiteMVCTelerik.ModuloBasico.Enums.TipoPesquisa.E)[0];
            processo.Excluir(emprestimo);
            processo.Confirmar();
            return RedirectToAction("EmprestimoCliente", "Emprestimo", new { id= ClasseAuxiliar.ClienteSelecionado.id });
        }

        ////
        //// POST: /StatusParcela/Delete/5

        //[HttpPost]
        //public ActionResult Excluir(int id, Emprestimo emprestimo)
        //{
        //    try
        //    {
        //        IEmprestimoProcesso processo = EmprestimoProcesso.Instance;

        //        emprestimo.id = id;
        //        processo.Excluir(emprestimo);
        //        processo.Confirmar();
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        ViewData["Mensagem"] = "O registro não pode ser excluído pois já está sendo utilizado.";
        //        ViewData.Model = emprestimo;
        //        return View();
        //    }



        //}
    }
}
