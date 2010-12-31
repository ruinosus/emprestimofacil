using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using MySql.Data.MySqlClient;
using Negocios.ModuloPrestacaoConta.Excecoes;
using Negocios.ModuloBasico.Enums;
using Negocios.ModuloBasico.VOs;

namespace Negocios.ModuloPrestacaoConta.Repositorios
{
    public class PrestacaoContaRepositorio : IPrestacaoContaRepositorio
    {
        #region Atributos

        ColegioDB db;

        #endregion

        #region Métodos da Interface

        public List<PrestacaoConta> Consultar()
        {
            return db.PrestacaoConta.ToList();
        }

        public List<PrestacaoConta> Consultar(PrestacaoConta prestacaoConta, TipoPesquisa tipoPesquisa)
        {
            List<PrestacaoConta> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (prestacaoConta.ID != 0)
                        {

                            resultado = ((from t in resultado
                                          where
                                          t.ID == prestacaoConta.ID
                                          select t).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(prestacaoConta.Nome))
                        {

                            resultado = ((from t in resultado
                                          where
                                          t.Nome.Contains(prestacaoConta.Nome)
                                          select t).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (prestacaoConta.Status.HasValue)
                        {

                            resultado = ((from t in resultado
                                          where
                                          t.Status.HasValue && t.Status.Value == prestacaoConta.Status.Value
                                          select t).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        break;
                    }
                #endregion
                #region Case Ou
                case TipoPesquisa.Ou:
                    {
                        if (prestacaoConta.ID != 0)
                        {

                            resultado.AddRange((from t in Consultar()
                                                where
                                                t.ID == prestacaoConta.ID
                                                select t).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(prestacaoConta.Nome))
                        {

                            resultado.AddRange((from t in Consultar()
                                                where
                                                t.Nome.Contains(prestacaoConta.Nome)
                                                select t).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (prestacaoConta.Status.HasValue)
                        {

                            resultado.AddRange((from t in Consultar()
                                                where
                                                t.Status.HasValue && t.Status.Value == prestacaoConta.Status.Value
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

        public void Incluir(PrestacaoConta prestacaoConta)
        {
            try
            {
                db.PrestacaoConta.InsertOnSubmit(prestacaoConta);
            }
            catch (Exception)
            {

                throw new PrestacaoContaNaoIncluidaExcecao();
            }
        }

        public void Excluir(PrestacaoConta prestacaoConta)
        {
            try
            {
                PrestacaoConta prestacaoContaAux = new PrestacaoConta();
                prestacaoContaAux.ID = prestacaoConta.ID;

                List<PrestacaoConta> resultado = this.Consultar(prestacaoContaAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new PrestacaoContaNaoExcluidaExcecao();

                prestacaoContaAux = resultado[0];

                db.PrestacaoConta.DeleteOnSubmit(prestacaoContaAux);
            }
            catch (Exception)
            {

                throw new PrestacaoContaNaoExcluidaExcecao();
            }
        }

        public void Alterar(PrestacaoConta prestacaoConta)
        {
            try
            {
                PrestacaoConta prestacaoContaAux = new PrestacaoConta();
                prestacaoContaAux.ID = prestacaoConta.ID;

                List<PrestacaoConta> resultado = this.Consultar(prestacaoContaAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new PrestacaoContaNaoAlteradaExcecao();

                prestacaoContaAux = resultado[0];
                prestacaoContaAux.Nome = prestacaoConta.Nome;
                prestacaoContaAux.Status = prestacaoConta.Status;


                Confirmar();
            }
            catch (Exception)
            {

                throw new PrestacaoContaNaoAlteradaExcecao();
            }
        }

        public void Confirmar()
        {
            db.SubmitChanges();
        }

        #endregion

        #region Construtor
        public PrestacaoContaRepositorio()
        {
            Conexao conexao = new Conexao();
            db = new ColegioDB(new MySqlConnection(conexao.ToString()));

        }
        #endregion


    }
}