using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;

using RegraNegocio.ModuloLancamentoTipo.Excecoes;
using RegraNegocio.ModuloBasico.Enums;
using RegraNegocio.ModuloBasico.VOs;

namespace RegraNegocio.ModuloLancamentoTipo.Repositorios
{
    public class LancamentoTipoRepositorio : ILancamentoTipoRepositorio
    {
        #region Atributos

        EmprestimoEntities db;

        #endregion

        #region Métodos da Interface

        public List<LancamentoTipo> Consultar()
        {
            return db.LancamentoTipoSet.ToList();
        }

        public List<LancamentoTipo> Consultar(LancamentoTipo lancamentoTipo, TipoPesquisa tipoPesquisa)
        {
            List<LancamentoTipo> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (lancamentoTipo.ID != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.ID == lancamentoTipo.ID
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        break;
                    }
                #endregion
                #region Case Ou
                case TipoPesquisa.Ou:
                    {
                        if (lancamentoTipo.ID != 0)
                        {
                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.ID == lancamentoTipo.ID
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

        public void Incluir(LancamentoTipo lancamentoTipo)
        {
            try
            {
                db.AddToLancamentoTipoSet(lancamentoTipo);
            }
            catch (Exception)
            {

                throw new LancamentoTipoNaoIncluidoExcecao();
            }
        }

        public void Excluir(LancamentoTipo lancamentoTipo)
        {
            try
            {
                LancamentoTipo lancamentoTipoAux = new LancamentoTipo();
                lancamentoTipoAux.ID = lancamentoTipo.ID;


                List<LancamentoTipo> resultado = this.Consultar(lancamentoTipoAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new LancamentoTipoNaoExcluidoExcecao();

                lancamentoTipoAux = resultado[0];

                db.DeleteObject(lancamentoTipoAux);

            }
            catch (Exception)
            {

                throw new LancamentoTipoNaoExcluidoExcecao();
            }
        }

        public void Alterar(LancamentoTipo lancamentoTipo)
        {
            try
            {
                LancamentoTipo lancamentoTipoAux = new LancamentoTipo();
                lancamentoTipoAux.ID = lancamentoTipo.ID;


                List<LancamentoTipo> resultado = this.Consultar(lancamentoTipoAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new LancamentoTipoNaoAlteradoExcecao();

                lancamentoTipoAux.descricao = lancamentoTipo.descricao;
                lancamentoTipoAux.ID = lancamentoTipo.ID;
                lancamentoTipoAux.sinal = lancamentoTipo.sinal;
                

                lancamentoTipoAux = resultado[0];

                Confirmar();
            }
            catch (Exception)
            {

                throw new LancamentoTipoNaoAlteradoExcecao();
            }
        }

        public void Confirmar()
        {
            db.SaveChanges();
        }

        #endregion

        #region Construtor
        public LancamentoTipoRepositorio()
        {
   
            db = new EmprestimoEntities();

        }
        #endregion


    }
}