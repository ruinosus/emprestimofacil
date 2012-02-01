using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteMVCTelerik.ModuloMunicipio.Processos;
using SiteMVCTelerik.Models.ModuloBasico.VOs;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.ModuloMunicipio.Processos;
using SiteMVCTelerik;

namespace SiteMVCTelerik.Controllers
{
    public class MunicipioController : Controller
    {
        //
        // GET: /Municipio/
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
            IMunicipioProcesso processo = MunicipioProcesso.Instance;
            var resultado =  processo.Consultar();
            List<Municipio> municipios = resultado;
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
            IMunicipioProcesso processo = MunicipioProcesso.Instance;
            Municipio municipio = new Municipio();
            municipio.id = id;

            ViewData.Model = processo.Consultar(municipio, TipoPesquisa.E)[0];
            return View();
        }

        //
        // GET: /StatusParcela/Create

        public ActionResult Incluir()
        {
            if (ClasseAuxiliar.UsuarioLogado == null || (ClasseAuxiliar.DataSelecionada == default(DateTime) || ClasseAuxiliar.AreaSelecionada == null))
                return RedirectToAction("Index", "Home"); 
            
            Municipio municipio = new Municipio();
            municipio.uf = "0";
            ViewData.Model = municipio;
            return View();
        }

        //
        // POST: /StatusParcela/Create

        [HttpPost]
        [ValidateInput(false)]

        public ActionResult Incluir(Municipio municipio, FormCollection collection)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    IMunicipioProcesso processo = MunicipioProcesso.Instance;
                    municipio.timeCreated = DateTime.Now;
                    processo.Incluir(municipio);
                    processo.Confirmar();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(municipio);
                }
            }
            catch
            {
                    return View(municipio);
            }
        }

        //
        // GET: /StatusParcela/Edit/5

        public ActionResult Alterar(int id)
        {
            if (ClasseAuxiliar.UsuarioLogado == null || (ClasseAuxiliar.DataSelecionada == default(DateTime) || ClasseAuxiliar.AreaSelecionada == null))
                return RedirectToAction("Index", "Home");
            IMunicipioProcesso processo = MunicipioProcesso.Instance;

            Municipio municipio = new Municipio();
            municipio.id = id;
            ViewData.Model = processo.Consultar(municipio, SiteMVCTelerik.ModuloBasico.Enums.TipoPesquisa.E)[0];
            return View();
        }

        //
        // POST: /StatusParcela/Edit/5

        [HttpPost]
        public ActionResult Alterar(int id, Municipio municipio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    municipio.id = id;
                    IMunicipioProcesso processo = MunicipioProcesso.Instance;
                    municipio.timeUpdated = DateTime.Now;
                    processo.Alterar(municipio);
                    processo.Confirmar();
                    // TODO: Add update logic here

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(municipio);
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
            IMunicipioProcesso processo = MunicipioProcesso.Instance;
            Municipio municipio = new Municipio();
            municipio.id = id;
            ViewData.Model = processo.Consultar(municipio, SiteMVCTelerik.ModuloBasico.Enums.TipoPesquisa.E)[0];
            return View();
            
        }

        ////
        //// POST: /StatusParcela/Delete/5

        [HttpPost]
        public ActionResult Excluir(int id, Municipio municipio)
        {
           // Municipio municipioAux = municipio;
            try
            {
                IMunicipioProcesso processo = MunicipioProcesso.Instance;
                // municipio = new Municipio();
                municipio.id = id;
                processo.Excluir(municipio);
                processo.Confirmar();
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                ViewData["Mensagem"] = "O registro não pode ser excluído pois já está sendo utilizado.";
                ViewData.Model = municipio;
                return View();
            }
        }
    }
}
