using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloBasico.Singleton;
using SiteMVCTelerik.ModuloEstadoCivilTipo.Repositorios;
using SiteMVCTelerik.ModuloEstadoCivilTipo.Processos;
using SiteMVCTelerik.ModuloEstadoCivilTipo.Fabricas;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.ModuloEstadoCivilTipo.Excecoes;
using SiteMVCTelerik.Models.ModuloBasico.VOs;

namespace SiteMVCTelerik.ModuloEstadoCivilTipo.Processos
{
    /// <summary>
    /// Classe EstadoCivilTipoProcesso
    /// </summary>
    public class EstadoCivilTipoProcesso : Singleton<EstadoCivilTipoProcesso>, IEstadoCivilTipoProcesso
    {
        #region Atributos
        private IEstadoCivilTipoRepositorio estadoCivilTipoRepositorio = null;
        #endregion

        #region Construtor
        public EstadoCivilTipoProcesso()
        {
            estadoCivilTipoRepositorio = EstadoCivilTipoFabrica.IEstadoCivilTipoInstance;
        }

        #endregion


        #region Métodos da Interface

        public void Incluir(EstadoCivilTipo estadoCivilTipo)
        {
            this.estadoCivilTipoRepositorio.Incluir(estadoCivilTipo);

        }

        public void Excluir(EstadoCivilTipo estadoCivilTipo)
        {

            try
            {
                if (estadoCivilTipo.id == 0)
                    throw new EstadoCivilTipoNaoExcluidoExcecao();

                List<EstadoCivilTipo> resultado = estadoCivilTipoRepositorio.Consultar(estadoCivilTipo, TipoPesquisa.E);

                if (resultado == null || resultado.Count <= 0 || resultado.Count > 1)
                    throw new EstadoCivilTipoNaoExcluidoExcecao();

                this.estadoCivilTipoRepositorio.Excluir(estadoCivilTipo);
            }
            catch (Exception e)
            {

                throw e;
            }
            //this.estadoCivilTipoRepositorio.Excluir(estadoCivilTipo);
        }

        public void Alterar(EstadoCivilTipo estadoCivilTipo)
        {
            this.estadoCivilTipoRepositorio.Alterar(estadoCivilTipo);
        }

        public List<EstadoCivilTipo> Consultar(EstadoCivilTipo estadoCivilTipo, TipoPesquisa tipoPesquisa)
        {
            List<EstadoCivilTipo> estadoCivilTipoList = this.estadoCivilTipoRepositorio.Consultar(estadoCivilTipo,tipoPesquisa);           

            return estadoCivilTipoList;
        }

        public List<EstadoCivilTipo> Consultar()
        {
            List<EstadoCivilTipo> estadoCivilTipoList = this.estadoCivilTipoRepositorio.Consultar();

            return estadoCivilTipoList;
        }

     
        public void Confirmar()
        {
            this.estadoCivilTipoRepositorio.Confirmar();
        }

        #endregion
    }
}