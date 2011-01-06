using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloBasico.Singleton;
using SiteMVC.ModuloUsuario.Repositorios;
using SiteMVC.ModuloUsuario.Processos;
using SiteMVC.ModuloUsuario.Fabricas;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.ModuloUsuario.Excecoes;
using SiteMVC.Models.ModuloBasico.VOs;

namespace SiteMVC.ModuloUsuario.Processos
{
    /// <summary>
    /// Classe UsuarioProcesso
    /// </summary>
    public class UsuarioProcesso : Singleton<UsuarioProcesso>, IUsuarioProcesso
    {
        #region Atributos
        private IUsuarioRepositorio usuarioRepositorio = null;
        #endregion

        #region Construtor
        public UsuarioProcesso()
        {
            usuarioRepositorio = UsuarioFabrica.IUsuarioInstance;
        }

        #endregion


        #region Métodos da Interface

        public void Incluir(Usuario usuario)
        {
            this.usuarioRepositorio.Incluir(usuario);

        }

        public void Excluir(Usuario usuario)
        {

            try
            {
                if (usuario.ID == 0)
                    throw new UsuarioNaoExcluidoExcecao();

                List<Usuario> resultado = usuarioRepositorio.Consultar(usuario, TipoPesquisa.E);

                if (resultado == null || resultado.Count <= 0 || resultado.Count > 1)
                    throw new UsuarioNaoExcluidoExcecao();

                this.usuarioRepositorio.Excluir(usuario);
            }
            catch (Exception e)
            {

                throw e;
            }
            //this.usuarioRepositorio.Excluir(usuario);
        }

        public void Alterar(Usuario usuario)
        {
            this.usuarioRepositorio.Alterar(usuario);
        }

        public List<Usuario> Consultar(Usuario usuario, TipoPesquisa tipoPesquisa)
        {
            List<Usuario> usuarioList = this.usuarioRepositorio.Consultar(usuario,tipoPesquisa);           

            return usuarioList;
        }

        public List<Usuario> Consultar()
        {
            List<Usuario> usuarioList = this.usuarioRepositorio.Consultar();

            return usuarioList;
        }

     
        public void Confirmar()
        {
            this.usuarioRepositorio.Confirmar();
        }

        #endregion
    }
}