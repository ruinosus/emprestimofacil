using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;

using SiteMVC.ModuloLancamento.Excecoes;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.Models.ModuloBasico.VOs;

namespace SiteMVC.ModuloLancamento.Repositorios
{
    public class LancamentoRepositorio : ILancamentoRepositorio
    {
        #region Atributos

        EmprestimoEntities db;

        #endregion

        #region Métodos da Interface

        public List<Lancamento> Consultar()
        {
            return db.LancamentoSet.ToList();
        }

        public List<Lancamento> Consultar(Lancamento lancamento, TipoPesquisa tipoPesquisa)
        {
            List<Lancamento> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (lancamento.ID != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.ID == lancamento.ID
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }
                        else
                        {
                            if (default(DateTime) != lancamento.data)
                            {

                                resultado = ((from c in resultado
                                              where
                                              c.data.ToShortDateString() == lancamento.data.ToShortDateString()
                                              select c).ToList());

                                resultado = resultado.Distinct().ToList();
                            }


                            if (lancamento.area_id != 0)
                            {

                                resultado = ((from c in resultado
                                              where
                                              c.area_id == lancamento.area_id
                                              select c).ToList());

                                resultado = resultado.Distinct().ToList();
                            }

                        }
                        break;
                    }
                #endregion
                #region Case Ou
                case TipoPesquisa.Ou:
                    {
                        if (lancamento.ID != 0)
                        {
                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.ID == lancamento.ID
                                                select c).ToList());
                            resultado = resultado.Distinct().ToList();
                        }
                        if (default(DateTime) != lancamento.data)
                        {

                            resultado.AddRange((from c in resultado
                                          where
                                          c.data.ToShortDateString() == lancamento.data.ToShortDateString()
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

        public void Incluir(Lancamento lancamento)
        {
            try
            {
                db.AddToLancamentoSet(lancamento);
            }
            catch (Exception)
            {

                throw new LancamentoNaoIncluidoExcecao();
            }
        }

        public void Excluir(Lancamento lancamento)
        {
            try
            {
                Lancamento lancamentoAux = new Lancamento();
                lancamentoAux.ID = lancamento.ID;


                List<Lancamento> resultado = this.Consultar(lancamentoAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new LancamentoNaoExcluidoExcecao();

                lancamentoAux = resultado[0];

                db.DeleteObject(lancamentoAux);

            }
            catch (Exception)
            {

                throw new LancamentoNaoExcluidoExcecao();
            }
        }

        public void Alterar(Lancamento lancamento)
        {
            try
            {
                Lancamento lancamentoAux = new Lancamento();
                lancamentoAux.ID = lancamento.ID;


                List<Lancamento> resultado = this.Consultar(lancamentoAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new LancamentoNaoAlteradoExcecao();

                lancamentoAux.data = lancamento.data;
                lancamentoAux.ID = lancamento.ID;
                lancamentoAux.lancamentotipo_id = lancamento.lancamentotipo_id;
                lancamentoAux.observacoes = lancamento.observacoes;
                lancamentoAux.outrasinfos = lancamento.outrasinfos;
                lancamentoAux.usuario_id = lancamento.usuario_id;
                lancamentoAux.valor = lancamento.valor;


                lancamentoAux = resultado[0];

                Confirmar();
            }
            catch (Exception)
            {

                throw new LancamentoNaoAlteradoExcecao();
            }
        }

        public void Confirmar()
        {
            db.SaveChanges();
        }

        #endregion

        #region Construtor
        public LancamentoRepositorio()
        {
        
            db = new EmprestimoEntities();

        }
        #endregion


    }
}