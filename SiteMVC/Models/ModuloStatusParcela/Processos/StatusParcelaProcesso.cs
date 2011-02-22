using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloBasico.Singleton;
using SiteMVC.ModuloStatusParcela.Repositorios;
using SiteMVC.ModuloStatusParcela.Processos;
using SiteMVC.ModuloStatusParcela.Fabricas;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.ModuloStatusParcela.Excecoes;
using SiteMVC.Models.ModuloBasico.VOs;

namespace SiteMVC.ModuloStatusParcela.Processos
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


        #region M�todos da Interface

        public void Incluir(StatusParcela statusParcela)
        {
            this.statusParcelaRepositorio.Incluir(statusParcela);

        }

        public void Excluir(StatusParcela statusParcela)
        {

            try
            {
                if (statusParcela.ID == 0)
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