using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteMVC.ModuloEmprestimo.Processos;
using SiteMVC.Models.ModuloBasico.VOs;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.ModuloMunicipio.Processos;
using SiteMVC;
using SiteMVC.ModuloCliente.Processos;

namespace SiteMVC.Controllers
{
    public class EmprestimoController : Controller
    {
        //
        // GET: /Emprestimo/
        private const int defaultPageSize = 10;
        public ActionResult Index()
        {
            return RedirectToAction("Listar");
        }

        public ActionResult Listar(int? page)
        {

            IEmprestimoProcesso processo = EmprestimoProcesso.Instance;
            var resultado = processo.Consultar();
            List<Emprestimo> emprestimos = resultado;
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return View(resultado.ToPagedList(currentPageIndex, defaultPageSize));


        }





        public ActionResult IncluirEmprestimoCliente()
        {
            Emprestimo emprestimo = new Emprestimo();
            emprestimo.cliente_id = ClasseAuxiliar.ClienteSelecionado.ID;
            emprestimo.prazospagamento_id = 0;
            emprestimo.data_emprestimo = DateTime.Now;
            emprestimo.tipoemprestimo_id = 0;
            emprestimo.usuario_id = ClasseAuxiliar.UsuarioLogado.ID;
            ViewData.Model = emprestimo;
            return View();
        }

        //
        // POST: /StatusParcela/Create

        [HttpPost]
        [ValidateInput(false)]

        public ActionResult IncluirEmprestimoCliente(Emprestimo emprestimo, FormCollection collection)
        {

            try
            {
                IEmprestimoProcesso processo = EmprestimoProcesso.Instance;
                if (ModelState.IsValid)
                {
                    emprestimo.cliente_id = ClasseAuxiliar.ClienteSelecionado.ID;
                    emprestimo.usuario_id = ClasseAuxiliar.UsuarioLogado.ID;

                    emprestimo.timeCreated = DateTime.Now;
                    processo.Incluir(emprestimo);
                    processo.Confirmar();
                    return RedirectToAction("EmprestimoCliente", new { id = ClasseAuxiliar.ClienteSelecionado.ID });
                }
                else
                {
                    return View(emprestimo);
                }
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
            cliente.ID = ID;
            cliente = processoCliente.Consultar(cliente, SiteMVC.ModuloBasico.Enums.TipoPesquisa.E)[0];

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
            emprestimo.ID = id;
            ViewData.Model = processo.Consultar(emprestimo, TipoPesquisa.E)[0];
            return View();
        }

        //
        // GET: /StatusParcela/Create

        public ActionResult Incluir()
        {
            Emprestimo emprestimo = new Emprestimo();
            emprestimo.cliente_id = 0;
            emprestimo.data_emprestimo = DateTime.Now;
            emprestimo.prazospagamento_id = 0;
            emprestimo.tipoemprestimo_id = 0;
            emprestimo.usuario_id = ClasseAuxiliar.UsuarioLogado.ID;
            ViewData.Model = emprestimo;
            return View();
        }

        //
        // POST: /StatusParcela/Create

        [HttpPost]
        [ValidateInput(false)]

        public ActionResult Incluir(Emprestimo emprestimo, FormCollection collection)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    IEmprestimoProcesso processo = EmprestimoProcesso.Instance;
                    emprestimo.timeCreated = DateTime.Now;
                    processo.Incluir(emprestimo);
                    processo.Confirmar();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(emprestimo);
                }
            }
            catch
            {
                return View(emprestimo);
            }
        }

        //
        // GET: /StatusParcela/Edit/5

        public ActionResult Alterar(int id)
        {
            IEmprestimoProcesso processo = EmprestimoProcesso.Instance;
            Emprestimo emprestimo = new Emprestimo();
            emprestimo.ID = id;
            ViewData.Model = processo.Consultar(emprestimo, SiteMVC.ModuloBasico.Enums.TipoPesquisa.E)[0];
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
                    emprestimo.ID = id;
                    IEmprestimoProcesso processo = EmprestimoProcesso.Instance;
                    emprestimo.timeUpdated = DateTime.Now;
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
            IEmprestimoProcesso processo = EmprestimoProcesso.Instance;
            Emprestimo emprestimo = new Emprestimo();
            emprestimo.ID = id;
            ViewData.Model = processo.Consultar(emprestimo, SiteMVC.ModuloBasico.Enums.TipoPesquisa.E)[0];
            return View();

        }

        ////
        //// POST: /StatusParcela/Delete/5

        [HttpPost]
        public ActionResult Excluir(int id, Emprestimo emprestimo)
        {
            try
            {
                IEmprestimoProcesso processo = EmprestimoProcesso.Instance;

                emprestimo.ID = id;
                processo.Excluir(emprestimo);
                processo.Confirmar();
                return RedirectToAction("Index");
            }
            catch
            {
                ViewData["Mensagem"] = "O registro não pode ser excluído pois já está sendo utilizado.";
                ViewData.Model = emprestimo;
                return View();
            }



        }
    }
}
