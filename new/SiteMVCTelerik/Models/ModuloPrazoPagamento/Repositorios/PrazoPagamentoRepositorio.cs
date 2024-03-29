using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;

using SiteMVCTelerik.ModuloPrazoPagamento.Excecoes;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.Models.ModuloBasico.VOs;

namespace SiteMVCTelerik.ModuloPrazoPagamento.Repositorios
{
    public class PrazoPagamentoRepositorio : IPrazoPagamentoRepositorio
    {
        #region Atributos

        emprestimoEntities db;

        #endregion

        #region M�todos da Interface

        public List<PrazoPagamento> Consultar()
        {
            return db.prazopagamento.ToList();
        }

        public List<PrazoPagamento> Consultar(PrazoPagamento prazoPagamento, TipoPesquisa tipoPesquisa)
        {
            List<PrazoPagamento> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (prazoPagamento.id != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.id == prazoPagamento.id
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        break;
                    }
                #endregion
                #region Case Ou
                case TipoPesquisa.Ou:
                    {
                        if (prazoPagamento.id != 0)
                        {
                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.id == prazoPagamento.id
                                                select c).ToList());
                            resultado = resultado.Distinct().ToList();
                        }

                        break;
                    }
                #endregion
                default:
                    break;
            }

            return resultado;
        }

        public void Incluir(PrazoPagamento prazoPagamento)
        {
            try
            {
                db.AddToprazopagamento(prazoPagamento);
            }
            catch (Exception)
            {

                throw new PrazoPagamentoNaoIncluidoExcecao();
            }
        }

        public void Excluir(PrazoPagamento prazoPagamento)
        {
            try
            {
                PrazoPagamento prazoPagamentoAux = new PrazoPagamento();
                prazoPagamentoAux.id = prazoPagamento.id;


                List<PrazoPagamento> resultado = this.Consultar(prazoPagamentoAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new PrazoPagamentoNaoExcluidoExcecao();

                prazoPagamentoAux = resultado[0];

                db.DeleteObject(prazoPagamentoAux);

            }
            catch (Exception)
            {

                throw new PrazoPagamentoNaoExcluidoExcecao();
            }
        }

        public void Alterar(PrazoPagamento prazoPagamento)
        {
            try
            {
                PrazoPagamento prazoPagamentoAux = new PrazoPagamento();
                prazoPagamentoAux.id = prazoPagamento.id;


                List<PrazoPagamento> resultado = this.Consultar(prazoPagamentoAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new PrazoPagamentoNaoAlteradoExcecao();

                prazoPagamentoAux.descricao = prazoPagamento.descricao;
                prazoPagamentoAux.id = prazoPagamento.id;
                prazoPagamentoAux.qtde_dias = prazoPagamento.qtde_dias;
              

                prazoPagamentoAux = resultado[0];

                Confirmar();
            }
            catch (Exception)
            {

                throw new PrazoPagamentoNaoAlteradoExcecao();
            }
        }

        public void Confirmar()
        {
            db.SaveChanges();
        }

        #endregion

        #region Construtor
        public PrazoPagamentoRepositorio()
        {

            db = new emprestimoEntities();

        }
        #endregion


    }
}