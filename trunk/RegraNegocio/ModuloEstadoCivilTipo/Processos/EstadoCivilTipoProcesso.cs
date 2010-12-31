using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloBasico.Singleton;
using RegraNegocio.ModuloEstadoCivilTipo.Repositorios;
using RegraNegocio.ModuloEstadoCivilTipo.Processos;
using RegraNegocio.ModuloEstadoCivilTipo.Fabricas;
using RegraNegocio.ModuloBasico.Enums;
using RegraNegocio.ModuloEstadoCivilTipo.Excecoes;

namespace RegraNegocio.ModuloEstadoCivilTipo.Processos
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

                resultado[0].Status = (int)Status.Inativo;
                this.Alterar(resultado[0]);
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