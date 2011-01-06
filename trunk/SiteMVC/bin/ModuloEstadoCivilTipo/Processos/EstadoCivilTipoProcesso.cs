using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloBasico.Singleton;
using SiteMVC.ModuloEstadoCivilTipo.Repositorios;
using SiteMVC.ModuloEstadoCivilTipo.Processos;
using SiteMVC.ModuloEstadoCivilTipo.Fabricas;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.ModuloEstadoCivilTipo.Excecoes;
using SiteMVC.Models.ModuloBasico.VOs;

namespace SiteMVC.ModuloEstadoCivilTipo.Processos
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
                if (estadoCivilTipo.ID == 0)
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