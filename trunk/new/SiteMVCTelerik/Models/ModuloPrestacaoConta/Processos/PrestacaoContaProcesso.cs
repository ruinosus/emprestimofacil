
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloBasico.Singleton;
using SiteMVCTelerik.ModuloPrestacaoConta.Repositorios;
using SiteMVCTelerik.ModuloPrestacaoConta.Processos;
using SiteMVCTelerik.ModuloPrestacaoConta.Fabricas;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.ModuloPrestacaoConta.Excecoes;
using SiteMVCTelerik.Models.ModuloBasico.VOs;
namespace SiteMVCTelerik.ModuloPrestacaoConta.Processos
{
    /// <summary>
    /// Classe PrestacaoContaProcesso
    /// </summary>
    public class PrestacaoContaProcesso : Singleton<PrestacaoContaProcesso>, IPrestacaoContaProcesso
    {
        #region Atributos
        private IPrestacaoContaRepositorio prestacaoContaRepositorio = null;
        #endregion

        #region Construtor
        public PrestacaoContaProcesso()
        {
            prestacaoContaRepositorio = PrestacaoContaFabrica.IPrestacaoContaInstance;
        }

        #endregion


        #region Métodos da Interface

        public void Incluir(PrestacaoConta prestacaoConta)
        {
            this.prestacaoContaRepositorio.Incluir(prestacaoConta);

        }

        public void Excluir(PrestacaoConta prestacaoConta)
        {
            try
            {
                if (prestacaoConta.id == 0)
                    throw new PrestacaoContaNaoExcluidaExcecao();

                List<PrestacaoConta> resultado = prestacaoContaRepositorio.Consultar(prestacaoConta, TipoPesquisa.E);

                if (resultado == null || resultado.Count <= 0 || resultado.Count > 1)
                    throw new PrestacaoContaNaoExcluidaExcecao();

                this.prestacaoContaRepositorio.Excluir(prestacaoConta);
            }
            catch (Exception e)
            {

                throw e;
            }
            //this.prestacaoContaRepositorio.Excluir(prestacaoConta);
        }

        public void Alterar(PrestacaoConta prestacaoConta)
        {
            this.prestacaoContaRepositorio.Alterar(prestacaoConta);
        }

        public List<PrestacaoConta> Consultar(PrestacaoConta prestacaoConta, TipoPesquisa tipoPesquisa)
        {
            List<PrestacaoConta> prestacaoContaList = this.prestacaoContaRepositorio.Consultar(prestacaoConta,tipoPesquisa);           

            return prestacaoContaList;
        }

        public List<PrestacaoConta> Consultar()
        {
            List<PrestacaoConta> prestacaoContaList = this.prestacaoContaRepositorio.Consultar();

            return prestacaoContaList;
        }

        public void Confirmar()
        {
            this.prestacaoContaRepositorio.Confirmar();
        }

        #endregion
    }
}