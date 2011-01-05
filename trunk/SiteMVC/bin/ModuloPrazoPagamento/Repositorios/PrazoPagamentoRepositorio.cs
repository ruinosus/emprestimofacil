using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;

using SiteMVC.ModuloPrazoPagamento.Excecoes;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.Models.ModuloBasico.VOs;

namespace SiteMVC.ModuloPrazoPagamento.Repositorios
{
    public class PrazoPagamentoRepositorio : IPrazoPagamentoRepositorio
    {
        #region Atributos

        EmprestimoEntities db;

        #endregion

        #region Métodos da Interface

        public List<PrazoPagamento> Consultar()
        {
            return db.PrazoPagamentoSet.ToList();
        }

        public List<PrazoPagamento> Consultar(PrazoPagamento prazoPagamento, TipoPesquisa tipoPesquisa)
        {
            List<PrazoPagamento> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (prazoPagamento.ID != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.ID == prazoPagamento.ID
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        break;
                    }
                #endregion
                #region Case Ou
                case TipoPesquisa.Ou:
                    {
                        if (prazoPagamento.ID != 0)
                        {
                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.ID == prazoPagamento.ID
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
                db.AddToPrazoPagamentoSet(prazoPagamento);
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
                prazoPagamentoAux.ID = prazoPagamento.ID;


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
                prazoPagamentoAux.ID = prazoPagamento.ID;


                List<PrazoPagamento> resultado = this.Consultar(prazoPagamentoAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new PrazoPagamentoNaoAlteradoExcecao();

                prazoPagamentoAux.descricao = prazoPagamento.descricao;
                prazoPagamentoAux.ID = prazoPagamento.ID;
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

            db = new EmprestimoEntities();

        }
        #endregion


    }
}