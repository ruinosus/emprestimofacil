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
            IMunicipioProcesso processo = MunicipioProcesso.Instance;
            List<Municipio> resultado = processo.Consultar();
            AreaFormViewModel areaFormViewModel = new AreaFormViewModel(new Area(), resultado);
            ViewData.Model = areaFormViewModel;
            ViewData["Municipios"] = areaFormViewModel.MunicipioSelectList;
            return View();
        }

        //
        // POST: /StatusParcela/Create

        [HttpPost]
        [ValidateInput(false)]

        public ActionResult Incluir(AreaFormViewModel areaFormViewModel, FormCollection collection)
        {
            //var Municipio_ID = this.Request["municipio_id"];
            try
            {
                //var teste = collection;
              //  var Municipio_ID = this.Request["municipios"];

                //if (string.IsNullOrEmpty(Municipio_ID) || Municipio_ID.Equals("0"))
                //    ModelState.AddModelError("municipio_id", "Informe o municipio.");
                //else
                //    areaFormViewModel.Area.municipio_id = Convert.ToInt16(Municipio_ID);
                if (ModelState.IsValid)
                {
                    IAreaProcesso processo = AreaProcesso.Instance;
                   
                    processo.Incluir(areaFormViewModel.Area);
                    processo.Confirmar();
                    return RedirectToAction("Index");
                }
                else
                {
                    IMunicipioProcesso processo = MunicipioProcesso.Instance;
                    List<Municipio> resultado = processo.Consultar();
                    areaFormViewModel.CarregarMunicipioSelectList(resultado, areaFormViewModel.Area.municipio_id);
                    return View(areaFormViewModel);
                }
            }
            catch
            {
                IMunicipioProcesso processo = MunicipioProcesso.Instance;
                    List<Municipio> resultado = processo.Consultar();
                    areaFormViewModel.CarregarMunicipioSelectList(resultado, areaFormViewModel.Area.municipio_id);
                    return View(areaFormViewModel);
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
                if (string.IsNullOrEmpty(area.descricao))
                    ModelState.AddModelError("descricao", "Informe a descrição.");

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
                    IMunicipioProcesso processo = MunicipioProcesso.Instance;
                    ViewData["municipios"] = processo.Consultar();
                    return View(area);
                }
            }
            catch
            {
                IMunicipioProcesso processo = MunicipioProcesso.Instance;
                ViewData["municipios"] = processo.Consultar();
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
        public ActionResult Delete(int id, FormCollection collection)
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
