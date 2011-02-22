using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;

using SiteMVCTelerik.ModuloDespesaTipo.Excecoes;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.Models.ModuloBasico.VOs;

namespace SiteMVCTelerik.ModuloDespesaTipo.Repositorios
{
    public class DespesaTipoRepositorio : IDespesaTipoRepositorio
    {
        #region Atributos

        EmprestimoEntities db;

        #endregion

        #region Métodos da Interface

        public List<DespesaTipo> Consultar()
        {
            return db.DespesaTipoSet.ToList();
        }

        public List<DespesaTipo> Consultar(DespesaTipo despesaTipo, TipoPesquisa tipoPesquisa)
        {
            List<DespesaTipo> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (despesaTipo.ID != 0)
                        {

                            resultado = ((from t in resultado
                                          where
                                          t.ID == despesaTipo.ID
                                          select t).ToList());

                            resultado = resultado.Distinct().ToList();
                        }


                        break;
                    }
                #endregion
                #region Case Ou
                case TipoPesquisa.Ou:
                    {
                        if (despesaTipo.ID != 0)
                        {

                            resultado.AddRange((from t in Consultar()
                                                where
                                                t.ID == despesaTipo.ID
                                                select t).ToList());

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

        public void Incluir(DespesaTipo despesaTipo)
        {
            try
            {
                db.AddToDespesaTipoSet(despesaTipo);
            }
            catch (Exception)
            {

                throw new DespesaTipoNaoIncluidaExcecao();
            }
        }

        public void Excluir(DespesaTipo despesaTipo)
        {
            try
            {
                DespesaTipo despesaTipoAux = new DespesaTipo();
                despesaTipoAux.ID = despesaTipo.ID;

                List<DespesaTipo> resultado = this.Consultar(despesaTipoAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new DespesaTipoNaoExcluidaExcecao();

                despesaTipoAux = resultado[0];

                db.DeleteObject(despesaTipoAux);
            }
            catch (Exception)
            {

                throw new DespesaTipoNaoExcluidaExcecao();
            }
        }

        public void Alterar(DespesaTipo despesaTipo)
        {
            try
            {
                DespesaTipo despesaTipoAux = new DespesaTipo();
                despesaTipoAux.ID = despesaTipo.ID;

                List<DespesaTipo> resultado = this.Consultar(despesaTipoAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new DespesaTipoNaoAlteradaExcecao();

                despesaTipoAux = resultado[0];
                despesaTipoAux.descricao = despesaTipo.descricao;
                despesaTipoAux.ID = despesaTipo.ID;
                despesaTipoAux.posdescricao = despesaTipo.posdescricao;



                Confirmar();
            }
            catch (Exception)
            {

                throw new DespesaTipoNaoAlteradaExcecao();
            }
        }

        public void Confirmar()
        {
            db.SaveChanges();
        }

        #endregion

        #region Construtor
        public DespesaTipoRepositorio()
        {
            db = new EmprestimoEntities();
        }
        #endregion


    }
}