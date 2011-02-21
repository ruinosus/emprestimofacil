using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteMVC.ModuloArea.Processos;
using SiteMVC.Models.ModuloBasico.VOs;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.ModuloMunicipio.Processos;
using SiteMVC;
using SiteMVC.Helpers;
using SiteMVC.ModuloUsuarioArea.Processos;

namespace SiteMVC.Controllers
{
    public class AreaController : Controller
    {
        //
        // GET: /Area/
        private const int defaultPageSize = 10;
        public ActionResult Index()
        {
            if (ClasseAuxiliar.UsuarioLogado == null ||(ClasseAuxiliar.DataSelecionada== default(DateTime) || ClasseAuxiliar.AreaSelecionada == null))
                return RedirectToAction("Index", "Home");
            return RedirectToAction("Listar");
        }

       
        public ActionResult Listar(int? page)
        {
            if (ClasseAuxiliar.UsuarioLogado == null || (ClasseAuxiliar.DataSelecionada == default(DateTime) || ClasseAuxiliar.AreaSelecionada == null))
                return RedirectToAction("Index", "Home");

            IAreaProcesso processo = AreaProcesso.Instance;
            var resultado = processo.Consultar();
            List<Area> areas = resultado;
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return View(resultado.ToPagedList(currentPageIndex, defaultPageSize));
        }

        //
        // GET: /StatusParcela/Details/5

        public ActionResult Detalhar(int id)
        {
            if (ClasseAuxiliar.UsuarioLogado == null || (ClasseAuxiliar.DataSelecionada == default(DateTime) || ClasseAuxiliar.AreaSelecionada == null))
                return RedirectToAction("Index", "Home");
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
            if (ClasseAuxiliar.UsuarioLogado == null || (ClasseAuxiliar.DataSelecionada == default(DateTime) || ClasseAuxiliar.AreaSelecionada == null))
                return RedirectToAction("Index", "Home");
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
                    area.timeCreated = DateTime.Now;
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
            if (ClasseAuxiliar.UsuarioLogado == null || (ClasseAuxiliar.DataSelecionada == default(DateTime) || ClasseAuxiliar.AreaSelecionada == null))
                return RedirectToAction("Index", "Home");
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
                    area.timeUpdated = DateTime.Now;
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
            if (ClasseAuxiliar.UsuarioLogado == null || (ClasseAuxiliar.DataSelecionada == default(DateTime) || ClasseAuxiliar.AreaSelecionada == null))
                return RedirectToAction("Index", "Home");
            IAreaProcesso processo = AreaProcesso.Instance;
            Area area = new Area();
            area.ID = id;
            ViewData.Model = processo.Consultar(area, SiteMVC.ModuloBasico.Enums.TipoPesquisa.E)[0];
            return View();

        }

        ////
        //// POST: /StatusParcela/Delete/5

        [HttpPost]
        public ActionResult Excluir(int id, Area area)
        {
            try
            {
                IAreaProcesso processo = AreaProcesso.Instance;

                area.ID = id;
                processo.Excluir(area);
                processo.Confirmar();
                return RedirectToAction("Index");
            }
            catch
            {
                ViewData["Mensagem"] = "O registro não pode ser excluído pois já está sendo utilizado.";
                ViewData.Model = area;
                return View();
            }



        }
    }
}
