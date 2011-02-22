using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;

using SiteMVCTelerik.ModuloTipoEmprestimo.Excecoes;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.Models.ModuloBasico.VOs;

namespace SiteMVCTelerik.ModuloTipoEmprestimo.Repositorios
{
    public class TipoEmprestimoRepositorio : ITipoEmprestimoRepositorio
    {
        #region Atributos

        EmprestimoEntities db;

        #endregion

        #region Métodos da Interface

        public List<TipoEmprestimo> Consultar()
        {
            return db.TipoEmprestimoSet.ToList();
        }

        public List<TipoEmprestimo> Consultar(TipoEmprestimo tipoEmprestimo, TipoPesquisa tipoPesquisa)
        {
            List<TipoEmprestimo> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (tipoEmprestimo.ID != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.ID == tipoEmprestimo.ID
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }


                        break;
                    }
                #endregion
                #region Case Ou
                case TipoPesquisa.Ou:
                    {
                        if (tipoEmprestimo.ID != 0)
                        {
                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.ID == tipoEmprestimo.ID
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

        public void Incluir(TipoEmprestimo tipoEmprestimo)
        {
            try
            {
                db.AddToTipoEmprestimoSet(tipoEmprestimo);
            }
            catch (Exception)
            {

                throw new TipoEmprestimoNaoIncluidoExcecao();
            }
        }

        public void Excluir(TipoEmprestimo tipoEmprestimo)
        {
            try
            {
                TipoEmprestimo tipoEmprestimoAux = new TipoEmprestimo();
                tipoEmprestimoAux.ID = tipoEmprestimo.ID;


                List<TipoEmprestimo> resultado = this.Consultar(tipoEmprestimoAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new TipoEmprestimoNaoExcluidoExcecao();

                tipoEmprestimoAux = resultado[0];

                db.DeleteObject(tipoEmprestimoAux);

            }
            catch (Exception)
            {

                throw new TipoEmprestimoNaoExcluidoExcecao();
            }
        }

        public void Alterar(TipoEmprestimo tipoEmprestimo)
        {
            try
            {
                TipoEmprestimo tipoEmprestimoAux = new TipoEmprestimo();
                tipoEmprestimoAux.ID = tipoEmprestimo.ID;


                List<TipoEmprestimo> resultado = this.Consultar(tipoEmprestimoAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new TipoEmprestimoNaoAlteradoExcecao();

                tipoEmprestimoAux.descricao = tipoEmprestimo.descricao;
                tipoEmprestimoAux.ID = tipoEmprestimo.ID;

   

                tipoEmprestimoAux = resultado[0];

                Confirmar();
            }
            catch (Exception)
            {

                throw new TipoEmprestimoNaoAlteradoExcecao();
            }
        }

        public void Confirmar()
        {
            db.SaveChanges();
        }

        #endregion

        #region Construtor
        public TipoEmprestimoRepositorio()
        {

            db = new EmprestimoEntities();

        }
        #endregion


    }
}