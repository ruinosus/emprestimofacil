using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloBasico.Singleton;
using SiteMVCTelerik.ModuloLancamento.Repositorios;
using SiteMVCTelerik.ModuloLancamento.Processos;
using SiteMVCTelerik.ModuloLancamento.Fabricas;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.ModuloLancamento.Excecoes;
using SiteMVCTelerik.Models.ModuloBasico.VOs;

namespace SiteMVCTelerik.ModuloLancamento.Processos
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
            lancamento.area_id = ClasseAuxiliar.AreaSelecionada.id;
            this.lancamentoRepositorio.Incluir(lancamento);

        }

        public void Excluir(Lancamento lancamento)
        {

            try
            {
                if (lancamento.id == 0)
                    throw new LancamentoNaoExcluidoExcecao();

                List<Lancamento> resultado = lancamentoRepositorio.Consultar(lancamento, TipoPesquisa.E);

                if (resultado == null || resultado.Count <= 0 || resultado.Count > 1)
                    throw new LancamentoNaoExcluidoExcecao();

                this.lancamentoRepositorio.Excluir(lancamento);
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