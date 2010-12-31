using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloBasico.Singleton;
using RegraNegocio.ModuloLancamento.Repositorios;
using RegraNegocio.ModuloLancamento.Processos;
using RegraNegocio.ModuloLancamento.Fabricas;
using RegraNegocio.ModuloBasico.Enums;
using RegraNegocio.ModuloLancamento.Excecoes;
using RegraNegocio.ModuloBasico.VOs;

namespace RegraNegocio.ModuloLancamento.Processos
{
    /// <summary>
    /// Classe LancamentoProcesso
    /// </summary>
    public class LancamentoProcesso : Singleton<LancamentoProcesso>, ILancamentoProcesso
    {
        #region Atributos
        private ILancamentoRepositorio lancamentoRepositorio = null;
        #endregion

        #region Construtor
        public LancamentoProcesso()
        {
            lancamentoRepositorio = LancamentoFabrica.ILancamentoInstance;
        }

        #endregion


        #region Métodos da Interface

        public void Incluir(Lancamento lancamento)
        {
            this.lancamentoRepositorio.Incluir(lancamento);

        }

        public void Excluir(Lancamento lancamento)
        {

            try
            {
                if (lancamento.ID == 0)
                    throw new LancamentoNaoExcluidoExcecao();

                List<Lancamento> resultado = lancamentoRepositorio.Consultar(lancamento, TipoPesquisa.E);

                if (resultado == null || resultado.Count <= 0 || resultado.Count > 1)
                    throw new LancamentoNaoExcluidoExcecao();

                resultado[0].Status = (int)Status.Inativo;
                this.Alterar(resultado[0]);
            }
            catch (Exception e)
            {

                throw e;
            }
            //this.lancamentoRepositorio.Excluir(lancamento);
        }

        public void Alterar(Lancamento lancamento)
        {
            this.lancamentoRepositorio.Alterar(lancamento);
        }

        public List<Lancamento> Consultar(Lancamento lancamento, TipoPesquisa tipoPesquisa)
        {
            List<Lancamento> lancamentoList = this.lancamentoRepositorio.Consultar(lancamento,tipoPesquisa);           

            return lancamentoList;
        }

        public List<Lancamento> Consultar()
        {
            List<Lancamento> lancamentoList = this.lancamentoRepositorio.Consultar();

            return lancamentoList;
        }

     
        public void Confirmar()
        {
            this.lancamentoRepositorio.Confirmar();
        }

        #endregion
    }
}