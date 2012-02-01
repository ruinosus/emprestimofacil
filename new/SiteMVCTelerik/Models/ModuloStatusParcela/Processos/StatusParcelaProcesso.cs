using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloBasico.Singleton;
using SiteMVCTelerik.ModuloStatusParcela.Repositorios;
using SiteMVCTelerik.ModuloStatusParcela.Processos;
using SiteMVCTelerik.ModuloStatusParcela.Fabricas;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.ModuloStatusParcela.Excecoes;
using SiteMVCTelerik.Models.ModuloBasico.VOs;

namespace SiteMVCTelerik.ModuloStatusParcela.Processos
{
    /// <summary>
    /// Classe StatusParcelaProcesso
    /// </summary>
    public class StatusParcelaProcesso : Singleton<StatusParcelaProcesso>, IStatusParcelaProcesso
    {
        #region Atributos
        private IStatusParcelaRepositorio statusParcelaRepositorio = null;
        #endregion

        #region Construtor
        public StatusParcelaProcesso()
        {
            statusParcelaRepositorio = StatusParcelaFabrica.IStatusParcelaInstance;
        }

        #endregion


        #region Métodos da Interface

        public void Incluir(StatusParcela statusParcela)
        {
            this.statusParcelaRepositorio.Incluir(statusParcela);

        }

        public void Excluir(StatusParcela statusParcela)
        {

            try
            {
                if (statusParcela.id == 0)
                    throw new StatusParcelaNaoExcluidoExcecao();

                List<StatusParcela> resultado = statusParcelaRepositorio.Consultar(statusParcela, TipoPesquisa.E);

                if (resultado == null || resultado.Count <= 0 || resultado.Count > 1)
                    throw new StatusParcelaNaoExcluidoExcecao();

                statusParcelaRepositorio.Excluir(statusParcela);
            }
            catch (Exception e)
            {

                throw e;
            }
            //this.statusParcelaRepositorio.Excluir(statusParcela);
        }

        public void Alterar(StatusParcela statusParcela)
        {
            this.statusParcelaRepositorio.Alterar(statusParcela);
        }

        public List<StatusParcela> Consultar(StatusParcela statusParcela, TipoPesquisa tipoPesquisa)
        {
            List<StatusParcela> statusParcelaList = this.statusParcelaRepositorio.Consultar(statusParcela,tipoPesquisa);           

            return statusParcelaList;
        }

        public List<StatusParcela> Consultar()
        {
            List<StatusParcela> statusParcelaList = this.statusParcelaRepositorio.Consultar();

            return statusParcelaList;
        }

     
        public void Confirmar()
        {
            this.statusParcelaRepositorio.Confirmar();
        }

        #endregion
    }
}