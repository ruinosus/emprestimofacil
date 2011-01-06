using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloBasico.Singleton;
using SiteMVC.ModuloPrazoPagamento.Repositorios;
using SiteMVC.ModuloPrazoPagamento.Processos;
using SiteMVC.ModuloPrazoPagamento.Fabricas;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.ModuloPrazoPagamento.Excecoes;
using SiteMVC.Models.ModuloBasico.VOs;

namespace SiteMVC.ModuloPrazoPagamento.Processos
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

                this.Excluir(prazoPagamento);
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