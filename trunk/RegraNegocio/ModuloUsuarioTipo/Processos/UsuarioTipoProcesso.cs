using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using Negocios.ModuloBasico.Singleton;
using Negocios.ModuloUsuarioTipo.Repositorios;
using Negocios.ModuloUsuarioTipo.Processos;
using Negocios.ModuloUsuarioTipo.Fabricas;
using Negocios.ModuloBasico.Enums;
using Negocios.ModuloUsuarioTipo.Excecoes;

namespace Negocios.ModuloUsuarioTipo.Processos
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
                if (usuarioTipo.ID == 0)
                    throw new UsuarioTipoNaoExcluidoExcecao();

                List<UsuarioTipo> resultado = usuarioTipoRepositorio.Consultar(usuarioTipo, TipoPesquisa.E);

                if (resultado == null || resultado.Count <= 0 || resultado.Count > 1)
                    throw new UsuarioTipoNaoExcluidoExcecao();

                resultado[0].Status = (int)Status.Inativo;
                this.Alterar(resultado[0]);
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