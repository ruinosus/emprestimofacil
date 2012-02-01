using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;

using SiteMVCTelerik.ModuloLancamentoTipo.Excecoes;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.Models.ModuloBasico.VOs;

namespace SiteMVCTelerik.ModuloLancamentoTipo.Repositorios
{
    public class LancamentoTipoRepositorio : ILancamentoTipoRepositorio
    {
        #region Atributos

        emprestimoEntities db;

        #endregion

        #region Métodos da Interface

        public List<LancamentoTipo> Consultar()
        {
            return db.lancamentotipo.ToList();
        }

        public List<LancamentoTipo> Consultar(LancamentoTipo lancamentoTipo, TipoPesquisa tipoPesquisa)
        {
            List<LancamentoTipo> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (lancamentoTipo.id != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.id == lancamentoTipo.id
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        break;
                    }
                #endregion
                #region Case Ou
                case TipoPesquisa.Ou:
                    {
                        if (lancamentoTipo.id != 0)
                        {
                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.id == lancamentoTipo.id
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
                db.AddTolancamentotipo(lancamentoTipo);
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
                lancamentoTipoAux.id = lancamentoTipo.id;


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
                lancamentoTipoAux.id = lancamentoTipo.id;


                List<LancamentoTipo> resultado = this.Consultar(lancamentoTipoAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new LancamentoTipoNaoAlteradoExcecao();

                lancamentoTipoAux.descricao = lancamentoTipo.descricao;
                lancamentoTipoAux.id = lancamentoTipo.id;
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
   
            db = new emprestimoEntities();

        }
        #endregion


    }
}