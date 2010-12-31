using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;

using RegraNegocio.ModuloParcela.Excecoes;
using RegraNegocio.ModuloBasico.Enums;
using RegraNegocio.ModuloBasico.VOs;

namespace RegraNegocio.ModuloParcela.Repositorios
{
    public class ParcelaRepositorio : IParcelaRepositorio
    {
        #region Atributos

        EmprestimoEntities db;

        #endregion

        #region Métodos da Interface

        public List<Parcela> Consultar()
        {
            return db.ParcelaSet.ToList();
        }

        public List<Parcela> Consultar(Parcela parcela, TipoPesquisa tipoPesquisa)
        {
            List<Parcela> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (parcela.ID != 0)
                        {

                            resultado = ((from t in resultado
                                          where
                                          t.ID == parcela.ID
                                          select t).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(parcela.Nome))
                        {

                            resultado = ((from t in resultado
                                          where
                                          t.Nome.Contains(parcela.Nome)
                                          select t).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (parcela.Status.HasValue)
                        {

                            resultado = ((from t in resultado
                                          where
                                          t.Status.HasValue && t.Status.Value == parcela.Status.Value
                                          select t).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        break;
                    }
                #endregion
                #region Case Ou
                case TipoPesquisa.Ou:
                    {
                        if (parcela.ID != 0)
                        {

                            resultado.AddRange((from t in Consultar()
                                                where
                                                t.ID == parcela.ID
                                                select t).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(parcela.Nome))
                        {

                            resultado.AddRange((from t in Consultar()
                                                where
                                                t.Nome.Contains(parcela.Nome)
                                                select t).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (parcela.Status.HasValue)
                        {

                            resultado.AddRange((from t in Consultar()
                                                where
                                                t.Status.HasValue && t.Status.Value == parcela.Status.Value
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

        public void Incluir(Parcela parcela)
        {
            try
            {
                db.Parcela.InsertOnSubmit(parcela);
            }
            catch (Exception)
            {

                throw new ParcelaNaoIncluidaExcecao();
            }
        }

        public void Excluir(Parcela parcela)
        {
            try
            {
                Parcela parcelaAux = new Parcela();
                parcelaAux.ID = parcela.ID;

                List<Parcela> resultado = this.Consultar(parcelaAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new ParcelaNaoExcluidaExcecao();

                parcelaAux = resultado[0];

                db.Parcela.DeleteOnSubmit(parcelaAux);
            }
            catch (Exception)
            {

                throw new ParcelaNaoExcluidaExcecao();
            }
        }

        public void Alterar(Parcela parcela)
        {
            try
            {
                Parcela parcelaAux = new Parcela();
                parcelaAux.ID = parcela.ID;

                List<Parcela> resultado = this.Consultar(parcelaAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new ParcelaNaoAlteradaExcecao();

                parcelaAux = resultado[0];
                parcelaAux.Nome = parcela.Nome;
                parcelaAux.Status = parcela.Status;


                Confirmar();
            }
            catch (Exception)
            {

                throw new ParcelaNaoAlteradaExcecao();
            }
        }

        public void Confirmar()
        {
            db.SubmitChanges();
        }

        #endregion

        #region Construtor
        public ParcelaRepositorio()
        {
            db = new EmprestimoEntities();
        }
        #endregion


    }
}