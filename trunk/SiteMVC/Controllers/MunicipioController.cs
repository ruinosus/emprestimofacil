using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteMVC.ModuloMunicipio.Processos;
using SiteMVC.Models.ModuloBasico.VOs;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.ModuloMunicipio.Processos;
using SiteMVC;

namespace SiteMVC.Controllers
{
    public class MunicipioController : Controller
    {
        //
        // GET: /Municipio/
        private const int defaultPageSize = 10;
        public ActionResult Index()
        {
            return RedirectToAction("Listar");
        }

        public ActionResult Listar(int? page)
        {
             
            IMunicipioProcesso processo = MunicipioProcesso.Instance;
            var resultado =  processo.Consultar();
            List<Municipio> municipios = resultado;
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return View(resultado.ToPagedList(currentPageIndex, defaultPageSize));
		
            //EmprestimoEntities db = new EmprestimoEntities();
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
            IMunicipioProcesso processo = MunicipioProcesso.Instance;
            Municipio municipio = new Municipio();
            municipio.ID = id;
            ViewData.Model = processo.Consultar(municipio, TipoPesquisa.E)[0];
            return View();
        }

        //
        // GET: /StatusParcela/Create

        public ActionResult Incluir()
        {
            //IMunicipioProcesso processo = MunicipioProcesso.Instance;
            //List<Municipio> resultado = processo.Consultar();
            //MunicipioFormViewModel municipioFormViewModel = new MunicipioFormViewModel(new Municipio(), resultado);
            //ViewData.Model = municipioFormViewModel;
            ViewData.Model = new Municipio();
            //ViewData["Municipios"] = municipioFormViewModel.MunicipioSelectList;
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
            IMunicipioProcesso processo = MunicipioProcesso.Instance;

            Municipio municipio = new Municipio();
            municipio.ID = id;
            ViewData.Model = processo.Consultar(municipio, SiteMVC.ModuloBasico.Enums.TipoPesquisa.E)[0];
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
                    municipio.ID = id;
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
            IMunicipioProcesso processo = MunicipioProcesso.Instance;
            Municipio municipio = new Municipio();
            municipio.ID = id;
            ViewData.Model = processo.Consultar(municipio, SiteMVC.ModuloBasico.Enums.TipoPesquisa.E)[0];
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
                municipio.ID = id;
                processo.Excluir(municipio);
                processo.Confirmar();
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                ViewData["Mensagem"] = "O registro não pode ser excluído.";
                ViewData.Model = municipio;
                return View();
            }
        }
    }
}
