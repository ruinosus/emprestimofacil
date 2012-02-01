using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloBasico.Singleton;
using SiteMVCTelerik.ModuloUsuarioTipo.Repositorios;
using SiteMVCTelerik.ModuloUsuarioTipo.Processos;
using SiteMVCTelerik.ModuloUsuarioTipo.Fabricas;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.ModuloUsuarioTipo.Excecoes;
using SiteMVCTelerik.Models.ModuloBasico.VOs;

namespace SiteMVCTelerik.ModuloUsuarioTipo.Processos
{
    /// <summary>
    /// Classe UsuarioTipoProcesso
    /// </summary>
    public class UsuarioTipoProcesso : Singleton<UsuarioTipoProcesso>, IUsuarioTipoProcesso
    {
        #region Atributos
        private IUsuarioTipoRepositorio usuarioTipoRepositorio = null;
        #endregion

        #region Construtor
        public UsuarioTipoProcesso()
        {
            usuarioTipoRepositorio = UsuarioTipoFabrica.IUsuarioTipoInstance;
        }

        #endregion


        #region Métodos da Interface

        public void Incluir(UsuarioTipo usuarioTipo)
        {
            this.usuarioTipoRepositorio.Incluir(usuarioTipo);

        }

        public void Excluir(UsuarioTipo usuarioTipo)
        {

            try
            {
                if (usuarioTipo.id == 0)
                    throw new UsuarioTipoNaoExcluidoExcecao();

                List<UsuarioTipo> resultado = usuarioTipoRepositorio.Consultar(usuarioTipo, TipoPesquisa.E);

                if (resultado == null || resultado.Count <= 0 || resultado.Count > 1)
                    throw new UsuarioTipoNaoExcluidoExcecao();
                this.usuarioTipoRepositorio.Excluir(usuarioTipo);
            }
            catch (Exception e)
            {

                throw e;
            }
            //this.usuarioTipoRepositorio.Excluir(usuarioTipo);
        }

        public void Alterar(UsuarioTipo usuarioTipo)
        {
            this.usuarioTipoRepositorio.Alterar(usuarioTipo);
        }

        public List<UsuarioTipo> Consultar(UsuarioTipo usuarioTipo, TipoPesquisa tipoPesquisa)
        {
            List<UsuarioTipo> usuarioTipoList = this.usuarioTipoRepositorio.Consultar(usuarioTipo,tipoPesquisa);           

            return usuarioTipoList;
        }

        public List<UsuarioTipo> Consultar()
        {
            List<UsuarioTipo> usuarioTipoList = this.usuarioTipoRepositorio.Consultar();

            return usuarioTipoList;
        }

     
        public void Confirmar()
        {
            this.usuarioTipoRepositorio.Confirmar();
        }

        #endregion
    }
}