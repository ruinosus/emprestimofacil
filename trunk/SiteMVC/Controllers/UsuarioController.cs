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

        #region Incluir
        [HttpPost]
        public ActionResult Incluir(Usuario usuario)
        {
            if (ClasseAuxiliar.UsuarioLogado == null)
                return Redirect("/Usuario/Logar");

            if (ModelState.IsValid)
            {
                IUsuarioProcesso processo = UsuarioProcesso.Instance;
                processo.Incluir(usuario);
                processo.Confirmar();
                return Redirect("/");
            }
            //Invalido - volta a tela mostrando os erros contidos.
            return View(usuario);

        }

        public ActionResult Incluir()
        {
            if (ClasseAuxiliar.UsuarioLogado == null)
                return Redirect("/Usuario/Logar");

            Usuario usuario = new Usuario();
            return View(usuario);
        }
        #endregion

        #region Alterar
        [HttpPost]
        public ActionResult Alterar(Usuario usuario)
        {
            if (ClasseAuxiliar.UsuarioLogado == null)
                return Redirect("/Usuario/Logar");

            string senha = usuario.senha;
            usuario = ClasseAuxiliar.UsuarioLogado;
            usuario.senha = senha;
            if (string.IsNullOrEmpty(senha))
            {
                return View(usuario);
            }

            IUsuarioProcesso processo = UsuarioProcesso.Instance;
            processo.Alterar(usuario);
            processo.Confirmar();
            return Redirect("/PainelAdministrador/ListaPonto");


        }

        public ActionResult Alterar()
        {
            if (ClasseAuxiliar.UsuarioLogado == null)
                return Redirect("/Usuario/Logar");
            return View(ClasseAuxiliar.UsuarioLogado);
        }
        #endregion

        #region Controle de Acesso

        public ActionResult Deslogar()
        {
            Session.Remove("UsuarioLogado");
            Session.Remove("UsuarioPontoLogadoLista");

            return RedirectToAction("Index", "Ponto");
        }

        public ActionResult Logar()
        {

            if (ClasseAuxiliar.UsuarioLogado != null)
                return Redirect("/PainelAdministrador/ListaPonto");
            Usuario usuario = new Usuario();

            return View(usuario);
        }

        [HttpPost]
        public ActionResult Logar(Usuario usuario)
        {
            if (ClasseAuxiliar.UsuarioLogado != null)
                return Redirect("/PainelAdministrador/ListaPonto");

            if (ModelState.IsValid)
            {
                IUsuarioProcesso processo = UsuarioProcesso.Instance;
                List<Usuario> usuarioLista = processo.Consultar(usuario, TipoPesquisa.E);
                if (usuarioLista.Count != 1)
                    ModelState.AddModelError("", "");
                else
                {
                    Session.Add("UsuarioLogado", usuarioLista[0]);
                    return Redirect("/PainelAdministrador/ListaPonto");
                }
            }
            //Invalido - volta a tela mostrando os erros contidos.
            return View(usuario);

        }
        #endregion
    }

}
