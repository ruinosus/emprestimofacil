using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloBasico.Singleton;
using SiteMVCTelerik.ModuloPrazoPagamento.Repositorios;
using SiteMVCTelerik.ModuloPrazoPagamento.Processos;
using SiteMVCTelerik.ModuloPrazoPagamento.Fabricas;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.ModuloPrazoPagamento.Excecoes;
using SiteMVCTelerik.Models.ModuloBasico.VOs;

namespace SiteMVCTelerik.ModuloPrazoPagamento.Processos
{
    /// <summary>
    /// Classe PrazoPagamentoProcesso
    /// </summary>
    public class PrazoPagamentoProcesso : Singleton<PrazoPagamentoProcesso>, IPrazoPagamentoProcesso
    {
        #region Atributos
        private IPrazoPagamentoRepositorio prazoPagamentoRepositorio = null;
        #endregion

        #region Construtor
        public PrazoPagamentoProcesso()
        {
            prazoPagamentoRepositorio = PrazoPagamentoFabrica.IPrazoPagamentoInstance;
        }

        #endregion


        #region Métodos da Interface

        public void Incluir(PrazoPagamento prazoPagamento)
        {
            this.prazoPagamentoRepositorio.Incluir(prazoPagamento);

        }

        public void Excluir(PrazoPagamento prazoPagamento)
        {

            try
            {
                if (prazoPagamento.ID == 0)
                    throw new PrazoPagamentoNaoExcluidoExcecao();

                List<PrazoPagamento> resultado = prazoPagamentoRepositorio.Consultar(prazoPagamento, TipoPesquisa.E);

                if (resultado == null || resultado.Count <= 0 || resultado.Count > 1)
                    throw new PrazoPagamentoNaoExcluidoExcecao();

                this.prazoPagamentoRepositorio.Excluir(prazoPagamento);
            }
            catch (Exception e)
            {

                throw e;
            }
            //this.prazoPagamentoRepositorio.Excluir(prazoPagamento);
        }

        public void Alterar(PrazoPagamento prazoPagamento)
        {
            this.prazoPagamentoRepositorio.Alterar(prazoPagamento);
        }

        public List<PrazoPagamento> Consultar(PrazoPagamento prazoPagamento, TipoPesquisa tipoPesquisa)
        {
            List<PrazoPagamento> prazoPagamentoList = this.prazoPagamentoRepositorio.Consultar(prazoPagamento,tipoPesquisa);           

            return prazoPagamentoList;
        }

        public List<PrazoPagamento> Consultar()
        {
            List<PrazoPagamento> prazoPagamentoList = this.prazoPagamentoRepositorio.Consultar();

            return prazoPagamentoList;
        }

     
        public void Confirmar()
        {
            this.prazoPagamentoRepositorio.Confirmar();
        }

        #endregion
    }
}