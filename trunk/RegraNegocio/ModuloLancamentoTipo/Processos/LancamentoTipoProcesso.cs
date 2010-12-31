using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloBasico.Singleton;
using RegraNegocio.ModuloLancamentoTipo.Repositorios;
using RegraNegocio.ModuloLancamentoTipo.Processos;
using RegraNegocio.ModuloLancamentoTipo.Fabricas;
using RegraNegocio.ModuloBasico.Enums;
using RegraNegocio.ModuloLancamentoTipo.Excecoes;

namespace RegraNegocio.ModuloLancamentoTipo.Processos
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

                resultado[0].Status = (int)Status.Inativo;
                this.Alterar(resultado[0]);
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