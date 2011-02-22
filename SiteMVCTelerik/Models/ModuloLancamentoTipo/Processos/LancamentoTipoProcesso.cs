using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloBasico.Singleton;
using SiteMVCTelerik.ModuloLancamentoTipo.Repositorios;
using SiteMVCTelerik.ModuloLancamentoTipo.Processos;
using SiteMVCTelerik.ModuloLancamentoTipo.Fabricas;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.ModuloLancamentoTipo.Excecoes;
using SiteMVCTelerik.Models.ModuloBasico.VOs;

namespace SiteMVCTelerik.ModuloLancamentoTipo.Processos
{
    /// <summary>
    /// Classe LancamentoTipoProcesso
    /// </summary>
    public class LancamentoTipoProcesso : Singleton<LancamentoTipoProcesso>, ILancamentoTipoProcesso
    {
        #region Atributos
        private ILancamentoTipoRepositorio lancamentoTipoRepositorio = null;
        #endregion

        #region Construtor
        public LancamentoTipoProcesso()
        {
            lancamentoTipoRepositorio = LancamentoTipoFabrica.ILancamentoTipoInstance;
        }

        #endregion


        #region Métodos da Interface

        public void Incluir(LancamentoTipo lancamentoTipo)
        {
            this.lancamentoTipoRepositorio.Incluir(lancamentoTipo);

        }

        public void Excluir(LancamentoTipo lancamentoTipo)
        {

            try
            {
                if (lancamentoTipo.ID == 0)
                    throw new LancamentoTipoNaoExcluidoExcecao();

                List<LancamentoTipo> resultado = lancamentoTipoRepositorio.Consultar(lancamentoTipo, TipoPesquisa.E);

                if (resultado == null || resultado.Count <= 0 || resultado.Count > 1)
                    throw new LancamentoTipoNaoExcluidoExcecao();

                this.lancamentoTipoRepositorio.Excluir(lancamentoTipo);
            }
            catch (Exception e)
            {

                throw e;
            }
            //this.lancamentoTipoRepositorio.Excluir(lancamentoTipo);
        }

        public void Alterar(LancamentoTipo lancamentoTipo)
        {
            this.lancamentoTipoRepositorio.Alterar(lancamentoTipo);
        }

        public List<LancamentoTipo> Consultar(LancamentoTipo lancamentoTipo, TipoPesquisa tipoPesquisa)
        {
            List<LancamentoTipo> lancamentoTipoList = this.lancamentoTipoRepositorio.Consultar(lancamentoTipo,tipoPesquisa);           

            return lancamentoTipoList;
        }

        public List<LancamentoTipo> Consultar()
        {
            List<LancamentoTipo> lancamentoTipoList = this.lancamentoTipoRepositorio.Consultar();

            return lancamentoTipoList;
        }

     
        public void Confirmar()
        {
            this.lancamentoTipoRepositorio.Confirmar();
        }

        #endregion
    }
}