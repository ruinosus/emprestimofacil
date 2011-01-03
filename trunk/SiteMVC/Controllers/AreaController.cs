using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteMVC.ModuloArea.Processos;
using SiteMVC.Models.ModuloBasico.VOs;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.ModuloMunicipio.Processos;

namespace SiteMVC.Controllers
{
    public class AreaController : Controller
    {
        //
        // GET: /Area/

        public ActionResult Index()
        {
            return RedirectToAction("Listar");
        }

        public ActionResult Listar()
        {
            IAreaProcesso processo = AreaProcesso.Instance;
            ViewData.Model = processo.Consultar();
            //EmprestimoEntities db = new EmprestimoEntities();
            //StatusParcela sss = new StatusParcela();
            //var teste = db.StatusParcelaSetSet.ToList();
            ////emprestimoEntities db = new emprestimoEntities();
            //ViewData.Model = teste;

            return View();
        }

        //
        // GET: /StatusParcela/Details/5

        public ActionResult Detalhar(int id)
        {
            IAreaProcesso processo = AreaProcesso.Instance;
            Area area = new Area();
            area.ID = id;
            ViewData.Model = processo.Consultar(area, TipoPesquisa.E)[0];
            return View();
        }

        //
        // GET: /StatusParcela/Create

        public ActionResult Incluir()
        {
            //IMunicipioProcesso processo = MunicipioProcesso.Instance;
            //List<Municipio> resultado = processo.Consultar();
            //AreaFormViewModel areaFormViewModel = new AreaFormViewModel(new Area(), resultado);
            //ViewData.Model = areaFormViewModel;
            ViewData.Model = new Area();
            //ViewData["Municipios"] = areaFormViewModel.MunicipioSelectList;
            return View();
        }

        //
        // POST: /StatusParcela/Create

        [HttpPost]
        [ValidateInput(false)]

        public ActionResult Incluir(Area area, FormCollection collection)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    IAreaProcesso processo = AreaProcesso.Instance;
                   
                    processo.Incluir(area);
                    processo.Confirmar();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(area);
                }
            }
            catch
            {
                    return View(area);
            }
        }

        //
        // GET: /StatusParcela/Edit/5

        public ActionResult Alterar(int id)
        {
            IAreaProcesso processo = AreaProcesso.Instance;
            IMunicipioProcesso processoMunicipio = MunicipioProcesso.Instance;
            ViewData["municipios"] = processoMunicipio.Consultar();
            Area area = new Area();
            area.ID = id;
            ViewData.Model = processo.Consultar(area, SiteMVC.ModuloBasico.Enums.TipoPesquisa.E)[0];
            return View();
        }

        //
        // POST: /StatusParcela/Edit/5

        [HttpPost]
        public ActionResult Alterar(int id, Area area)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    area.ID = id;
                    IAreaProcesso processo = AreaProcesso.Instance;
                    processo.Alterar(area);
                    processo.Confirmar();
                    // TODO: Add update logic here

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(area);
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
            IAreaProcesso processo = AreaProcesso.Instance;
            Area area = new Area();
            area.ID = id;
            ViewData.Model = processo.Consultar(area, SiteMVC.ModuloBasico.Enums.TipoPesquisa.E)[0];
            return View();
            
        }

        ////
        //// POST: /StatusParcela/Delete/5

        [HttpPost]
        public ActionResult Excluir(int id, FormCollection collection)
        {
            try
            {
                IAreaProcesso processo = AreaProcesso.Instance;
                Area area = new Area();
                area.ID = id;
                processo.Excluir(area);
                processo.Confirmar();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
