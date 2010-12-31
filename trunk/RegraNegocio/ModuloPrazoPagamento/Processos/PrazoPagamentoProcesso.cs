using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloBasico.Singleton;
using RegraNegocio.ModuloPrazoPagamento.Repositorios;
using RegraNegocio.ModuloPrazoPagamento.Processos;
using RegraNegocio.ModuloPrazoPagamento.Fabricas;
using RegraNegocio.ModuloBasico.Enums;
using RegraNegocio.ModuloPrazoPagamento.Excecoes;
using RegraNegocio.ModuloBasico.VOs;

namespace RegraNegocio.ModuloPrazoPagamento.Processos
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

                resultado[0].Status = (int)Status.Inativo;
                this.Alterar(resultado[0]);
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