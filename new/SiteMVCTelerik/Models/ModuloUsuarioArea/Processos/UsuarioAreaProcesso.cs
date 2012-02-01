using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloBasico.Singleton;
using SiteMVCTelerik.ModuloUsuarioArea.Repositorios;
using SiteMVCTelerik.ModuloUsuarioArea.Processos;
using SiteMVCTelerik.ModuloUsuarioArea.Fabricas;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.ModuloUsuarioArea.Excecoes;
using SiteMVCTelerik.Models.ModuloBasico.VOs;

namespace SiteMVCTelerik.ModuloUsuarioArea.Processos
{
    /// <summary>
    /// Classe UsuarioAreaProcesso
    /// </summary>
    public class UsuarioAreaProcesso : Singleton<UsuarioAreaProcesso>, IUsuarioAreaProcesso
    {
        #region Atributos
        private IUsuarioAreaRepositorio usuarioAreaRepositorio = null;
        #endregion

        #region Construtor
        public UsuarioAreaProcesso()
        {
            usuarioAreaRepositorio = UsuarioAreaFabrica.IUsuarioAreaInstance;
        }

        #endregion


        #region Métodos da Interface

        public void Incluir(UsuarioArea usuarioArea)
        {
            this.usuarioAreaRepositorio.Incluir(usuarioArea);

        }

        public void Excluir(UsuarioArea usuarioArea)
        {

            try
            {
                if (usuarioArea.id == 0)
                    throw new UsuarioAreaNaoExcluidoExcecao();

                List<UsuarioArea> resultado = usuarioAreaRepositorio.Consultar(usuarioArea, TipoPesquisa.E);

                if (resultado == null || resultado.Count <= 0 || resultado.Count > 1)
                    throw new UsuarioAreaNaoExcluidoExcecao();
                this.usuarioAreaRepositorio.Excluir(usuarioArea);
            }
            catch (Exception e)
            {

                throw e;
            }
            //this.usuarioAreaRepositorio.Excluir(usuarioArea);
        }

        public void Alterar(UsuarioArea usuarioArea)
        {
            this.usuarioAreaRepositorio.Alterar(usuarioArea);
        }

        public List<UsuarioArea> Consultar(UsuarioArea usuarioArea, TipoPesquisa tipoPesquisa)
        {
            List<UsuarioArea> usuarioAreaList = this.usuarioAreaRepositorio.Consultar(usuarioArea,tipoPesquisa);           

            return usuarioAreaList;
        }

        public List<UsuarioArea> Consultar()
        {
            List<UsuarioArea> usuarioAreaList = this.usuarioAreaRepositorio.Consultar();

            return usuarioAreaList;
        }

     
        public void Confirmar()
        {
            this.usuarioAreaRepositorio.Confirmar();
        }

        #endregion
    }
}