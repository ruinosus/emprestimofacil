using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteMVC.Models.ModuloBasico.VOs;
using SiteMVC.ModuloUsuario.Processos;
using SiteMVC.ModuloBasico.Enums;

namespace SiteMVC.Controllers
{
    public class UsuarioController : Controller
    {

        //
        // GET: /Usuario/
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

            IUsuarioProcesso processo = UsuarioProcesso.Instance;
            var resultado = processo.Consultar();
            List<Usuario> usuarios = resultado;
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return View(resultado.ToPagedList(currentPageIndex, defaultPageSize));
        }

        //
        // GET: /StatusParcela/Details/5

        public ActionResult Detalhar(int id)
        {
            if (ClasseAuxiliar.UsuarioLogado == null || (ClasseAuxiliar.DataSelecionada == default(DateTime) || ClasseAuxiliar.AreaSelecionada == null))
                return RedirectToAction("Index", "Home");
            IUsuarioProcesso processo = UsuarioProcesso.Instance;
            Usuario usuario = new Usuario();
            usuario.ID = id;
            ViewData.Model = processo.Consultar(usuario, TipoPesquisa.E)[0];
            return View();
        }

        //
        // GET: /StatusParcela/Create

        public ActionResult Incluir()
        {
            if (ClasseAuxiliar.UsuarioLogado == null || (ClasseAuxiliar.DataSelecionada == default(DateTime) || ClasseAuxiliar.AreaSelecionada == null))
                return RedirectToAction("Index", "Home");
            Usuario usuario = new Usuario();
            usuario.escolaridade_id = 0;
            usuario.estadoscivistipo_id = 0;
            usuario.orgaosexpedidoresnome_id = 0;
            usuario.usuariotipo_id = 0;
            usuario.data_expedicao = DateTime.Now;
            ViewData.Model = usuario;
            return View();
        }

        //
        // POST: /StatusParcela/Create

        [HttpPost]
        [ValidateInput(false)]

        public ActionResult Incluir(Usuario usuario, FormCollection collection)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    IUsuarioProcesso processo = UsuarioProcesso.Instance;
                    usuario.timeCreated = DateTime.Now;
                    processo.Incluir(usuario);
                    processo.Confirmar();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(usuario);
                }
            }
            catch
            {
                return View(usuario);
            }
        }

        //
        // GET: /StatusParcela/Edit/5

        public ActionResult Alterar(int id)
        {
            if (ClasseAuxiliar.UsuarioLogado == null || (ClasseAuxiliar.DataSelecionada == default(DateTime) || ClasseAuxiliar.AreaSelecionada == null))
                return RedirectToAction("Index", "Home");
            IUsuarioProcesso processo = UsuarioProcesso.Instance;
          
            Usuario usuario = new Usuario();
            usuario.ID = id;
            ViewData.Model = processo.Consultar(usuario, SiteMVC.ModuloBasico.Enums.TipoPesquisa.E)[0];
            return View();
        }

        //
        // POST: /StatusParcela/Edit/5

        [HttpPost]
        public ActionResult Alterar(int id, Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuario.ID = id;
                    IUsuarioProcesso processo = UsuarioProcesso.Instance;
                    usuario.timeUpdated = DateTime.Now;
                    processo.Alterar(usuario);
                    processo.Confirmar();
                    // TODO: Add update logic here

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(usuario);
                }
            }
            catch
            {
                return View();
            }
        }




        public ActionResult AlterarSenha(int id)
        {
            if (ClasseAuxiliar.UsuarioLogado == null )
                return RedirectToAction("Index", "Home");
            IUsuarioProcesso processo = UsuarioProcesso.Instance;

            Usuario usuario = new Usuario();
            usuario.ID = id;
            ViewData.Model = processo.Consultar(usuario, SiteMVC.ModuloBasico.Enums.TipoPesquisa.E)[0];
            return View();
        }

        //
        // POST: /StatusParcela/Edit/5

        [HttpPost]
        public ActionResult AlterarSenha(int id, Usuario usuario)
        {
            try
            {
              //  if (ModelState.IsValid)
                {
                    IUsuarioProcesso processo = UsuarioProcesso.Instance;
                    string senhaModificada = usuario.senha;
                    usuario = processo.Consultar(usuario, SiteMVC.ModuloBasico.Enums.TipoPesquisa.E)[0];
                    usuario.ID = id;
                    usuario.senha = senhaModificada;
                    usuario.timeUpdated = DateTime.Now;
                    processo.Alterar(usuario);
                    processo.Confirmar();
                    // TODO: Add update logic here

                    return RedirectToAction("Index", "Home");
                }
              //  else
                {
                //    return View(usuario);
                }
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }


        //
        // GET: /StatusParcela/Delete/5

        public ActionResult Excluir(int id)
        {
            if (ClasseAuxiliar.UsuarioLogado == null || (ClasseAuxiliar.DataSelecionada == default(DateTime) || ClasseAuxiliar.AreaSelecionada == null))
                return RedirectToAction("Index", "Home");
            IUsuarioProcesso processo = UsuarioProcesso.Instance;
            Usuario usuario = new Usuario();
            usuario.ID = id;
            ViewData.Model = processo.Consultar(usuario, SiteMVC.ModuloBasico.Enums.TipoPesquisa.E)[0];
            return View();

        }

        ////
        //// POST: /StatusParcela/Delete/5

        [HttpPost]
        public ActionResult Excluir(int id, Usuario usuario)
        {
            try
            {
                IUsuarioProcesso processo = UsuarioProcesso.Instance;

                usuario.ID = id;
                processo.Excluir(usuario);
                processo.Confirmar();
                return RedirectToAction("Index");
            }
            catch
            {
                ViewData["Mensagem"] = "O registro não pode ser excluído pois já está sendo utilizado.";
                ViewData.Model = usuario;
                return View();
            }



        }
        #region Controle de Acesso

        public ActionResult Deslogar()
        {
            Session.Remove("UsuarioLogado");
            Session.Remove("UsuarioPontoLogadoLista");

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logar()
        {

            if (ClasseAuxiliar.UsuarioLogado != null)
                return RedirectToAction("Index", "Home");
            Usuario usuario = new Usuario();

            return View(usuario);
        }

        [HttpPost]
        public ActionResult Logar(Usuario usuario)
        {
            if (ClasseAuxiliar.UsuarioLogado != null)
                return RedirectToAction("Index", "Home");

         //   if (ModelState.IsValid)
            {
                IUsuarioProcesso processo = UsuarioProcesso.Instance;
                List<Usuario> usuarioLista = processo.Consultar(usuario, TipoPesquisa.E);
                if (usuarioLista.Count != 1)
                    ModelState.AddModelError("", "");
                else
                {
                    Session.Add("UsuarioLogado", usuarioLista[0]);
                    return Redirect("/");
                }
            }
            //Invalido - volta a tela mostrando os erros contidos.
            return View(usuario);

        }
        #endregion
    }

}
