using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegraNegocio.ModuloBasico;
using RegraNegocio.ModuloStatusParcela.Processos;


namespace SiteMVC.Controllers
{
    public class StatusParcelaController : Controller
    {
        //
        // GET: /StatusParcela/

        public ActionResult Index()
        {
            StatusParcelaProcesso processo = new StatusParcelaProcesso();
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

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /StatusParcela/Create

        public ActionResult Create()
        {
           
            return View();
        } 

        //
        // POST: /StatusParcela/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /StatusParcela/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /StatusParcela/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /StatusParcela/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /StatusParcela/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
