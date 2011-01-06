using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteMVC.ModuloCliente.Processos;
using SiteMVC.Models.ModuloBasico.VOs;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.ModuloMunicipio.Processos;
using SiteMVC;

namespace SiteMVC.Controllers
{
    public class ClienteController : Controller
    {
        //
        // GET: /Cliente/
        private const int defaultPageSize = 10;
        public ActionResult Index()
        {
            return RedirectToAction("Listar");
        }

        public ActionResult Listar(int? page)
        {
             
            IClienteProcesso processo = ClienteProcesso.Instance;
            var resultado =  processo.Consultar();
            List<Cliente> clientes = resultado;
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return View(resultado.ToPagedList(currentPageIndex, defaultPageSize));
		

        }

        //
        // GET: /StatusParcela/Details/5

        public ActionResult Detalhar(int id)
        {
            IClienteProcesso processo = ClienteProcesso.Instance;
            Cliente cliente = new Cliente();
            cliente.ID = id;
            ViewData.Model = processo.Consultar(cliente, TipoPesquisa.E)[0];
            return View();
        }

        //
        // GET: /StatusParcela/Create

        public ActionResult Incluir()
        {
            ViewData.Model = new Cliente();
            return View();
        }

        //
        // POST: /StatusParcela/Create

        [HttpPost]
        [ValidateInput(false)]

        public ActionResult Incluir(Cliente cliente, FormCollection collection)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    IClienteProcesso processo = ClienteProcesso.Instance;
                    cliente.timeCreated = DateTime.Now;
                    processo.Incluir(cliente);
                    processo.Confirmar();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(cliente);
                }
            }
            catch
            {
                    return View(cliente);
            }
        }

        //
        // GET: /StatusParcela/Edit/5

        public ActionResult Alterar(int id)
        {
            IClienteProcesso processo = ClienteProcesso.Instance;
            Cliente cliente = new Cliente();
            cliente.ID = id;
            ViewData.Model = processo.Consultar(cliente, SiteMVC.ModuloBasico.Enums.TipoPesquisa.E)[0];
            return View();
        }

        //
        // POST: /StatusParcela/Edit/5

        [HttpPost]
        public ActionResult Alterar(int id, Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    cliente.ID = id;
                    IClienteProcesso processo = ClienteProcesso.Instance;
                    cliente.timeUpdated = DateTime.Now;
                    processo.Alterar(cliente);
                    processo.Confirmar();
                    // TODO: Add update logic here

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(cliente);
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
            IClienteProcesso processo = ClienteProcesso.Instance;
            Cliente cliente = new Cliente();
            cliente.ID = id;
            ViewData.Model = processo.Consultar(cliente, SiteMVC.ModuloBasico.Enums.TipoPesquisa.E)[0];
            return View();
            
        }

        ////
        //// POST: /StatusParcela/Delete/5

        [HttpPost]
        public ActionResult Excluir(int id, Cliente cliente)
        {
            try
            {
                IClienteProcesso processo = ClienteProcesso.Instance;
             
                cliente.ID = id;
                processo.Excluir(cliente);
                processo.Confirmar();
                return RedirectToAction("Index");
            }
            catch
            {
                ViewData["Mensagem"] = "O registro não pode ser excluído pois já está sendo utilizado.";
                ViewData.Model = cliente;
                return View();
            }


            
        }
    }
}
