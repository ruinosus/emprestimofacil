using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteMVCTelerik.ModuloCliente.Processos;
using SiteMVCTelerik.Models.ModuloBasico.VOs;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.ModuloMunicipio.Processos;
using SiteMVCTelerik;

namespace SiteMVCTelerik.Controllers
{
    public class ClienteController : Controller
    {
        //
        // GET: /Cliente/
        private const int defaultPageSize = 10;
        public ActionResult Index()
        {
            if (ClasseAuxiliar.UsuarioLogado == null || (ClasseAuxiliar.DataSelecionada == default(DateTime) || ClasseAuxiliar.AreaSelecionada == null))
                return RedirectToAction("Index", "Home");
            return RedirectToAction("Listar");
        }

        //public ActionResult Listar(int? page)
        //{
        //    if (ClasseAuxiliar.UsuarioLogado == null || (ClasseAuxiliar.DataSelecionada == default(DateTime) || ClasseAuxiliar.AreaSelecionada == null))
        //        return RedirectToAction("Index", "Home");
        //    IClienteProcesso processo = ClienteProcesso.Instance;
        //    Cliente cliente = new Cliente();

        //    //if (SiteMVCTelerik.Models.ModuloBasico.VOs.ClasseAuxiliar.UsuarioLogado.usuariotipo_id != 1)
        //    //    cliente.area_id = ClasseAuxiliar.UsuarioLogado.area_id;

        //    cliente.area_id = ClasseAuxiliar.AreaSelecionada.id;

        //    var resultado =  processo.Consultar(cliente,TipoPesquisa.E);
        //    List<Cliente> clientes = resultado;
        //    int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
        //    return View(resultado.ToPagedList(currentPageIndex, defaultPageSize));
		

        //}
        
        public ActionResult Listar()
        {
            if (ClasseAuxiliar.UsuarioLogado == null || (ClasseAuxiliar.DataSelecionada == default(DateTime) || ClasseAuxiliar.AreaSelecionada == null))
                return RedirectToAction("Index", "Home");
            IClienteProcesso processo = ClienteProcesso.Instance;
            Cliente cliente = new Cliente();
            
            cliente.area_id = ClasseAuxiliar.AreaSelecionada.id;

            var resultado = processo.Consultar(cliente, TipoPesquisa.E);
            List<Cliente> clientes = resultado;
            
            return View(resultado);
        }
        
        //
        // GET: /StatusParcela/Details/5

        public ActionResult Detalhar(int id)
        {
            if (ClasseAuxiliar.UsuarioLogado == null || (ClasseAuxiliar.DataSelecionada == default(DateTime) || ClasseAuxiliar.AreaSelecionada == null))
                return RedirectToAction("Index", "Home");
            IClienteProcesso processo = ClienteProcesso.Instance;
            Cliente cliente = new Cliente();
            cliente.id = id;
            ViewData.Model = processo.Consultar(cliente, TipoPesquisa.E)[0];
            return View();
        }

        //
        // GET: /StatusParcela/Create

        public ActionResult Incluir()
        {
            if (ClasseAuxiliar.UsuarioLogado == null || (ClasseAuxiliar.DataSelecionada == default(DateTime) || ClasseAuxiliar.AreaSelecionada == null))
                return RedirectToAction("Index", "Home");
            Cliente cliente = new Cliente();
            cliente.escolaridade_id = 0;
            cliente.estadoscivistipo_id= 0;
            cliente.orgaosexpedidoresnome_id = 0;
            cliente.cidade_comerc= 0;
            cliente.cidade_resid= 0;
            cliente.data_expedicao = DateTime.Now;

            ViewData.Model = cliente;
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
                    cliente.timeUpdated = DateTime.Now;
                    processo.Incluir(cliente);
                    processo.Confirmar();
                    return RedirectToAction("Index");
                }
                else
                {
                    
                    return View(cliente);
                }
            }
            catch(Exception e)
            {
                    return View(cliente);
            }
        }

        //
        // GET: /StatusParcela/Edit/5

        public ActionResult Alterar(int id)
        {
            if (ClasseAuxiliar.UsuarioLogado == null || (ClasseAuxiliar.DataSelecionada == default(DateTime) || ClasseAuxiliar.AreaSelecionada == null))
                return RedirectToAction("Index", "Home");
            IClienteProcesso processo = ClienteProcesso.Instance;
            Cliente cliente = new Cliente();
            cliente.id = id;
            ViewData.Model = processo.Consultar(cliente, SiteMVCTelerik.ModuloBasico.Enums.TipoPesquisa.E)[0];
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
                    cliente.id = id;
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
            if (ClasseAuxiliar.UsuarioLogado == null || (ClasseAuxiliar.DataSelecionada == default(DateTime) || ClasseAuxiliar.AreaSelecionada == null))
                return RedirectToAction("Index", "Home");
            IClienteProcesso processo = ClienteProcesso.Instance;
            Cliente cliente = new Cliente();
            cliente.id = id;
            ViewData.Model = processo.Consultar(cliente, SiteMVCTelerik.ModuloBasico.Enums.TipoPesquisa.E)[0];
            return View();
            
        }

        ////
        //// POST: /StatusParcela/Delete/5

        [HttpPost]
        public ActionResult Excluir(int id, Cliente cliente)
        {
            IClienteProcesso processo = ClienteProcesso.Instance;
            try
            {
                
             
                cliente.id = id;
                processo.Excluir(cliente);
                processo.Confirmar();
                return RedirectToAction("Index");
            }
            catch
            {
                cliente.id = id;
                ViewData["Mensagem"] = "O registro não pode ser excluído pois já está sendo utilizado.";
             ViewData.Model = processo.Consultar(cliente, SiteMVCTelerik.ModuloBasico.Enums.TipoPesquisa.E)[0]; ;
                return View();
            }


            
        }
    }
}
