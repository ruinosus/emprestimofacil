using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using MySql.Data.MySqlClient;
using RegraNegocio.ModuloEscolaridade.Excecoes;
using RegraNegocio.ModuloBasico.Enums;
using RegraNegocio.ModuloBasico.VOs;

namespace RegraNegocio.ModuloEscolaridade.Repositorios
{
    public class EscolaridadeRepositorio : IEscolaridadeRepositorio
    {
        #region Atributos

        EmprestimoEntities db;

        #endregion

        #region Métodos da Interface

        public List<Escolaridade> Consultar()
        {
            return db.EscolaridadeSet.ToList();
        }

        public List<Escolaridade> Consultar(Escolaridade escolaridade, TipoPesquisa tipoPesquisa)
        {
            List<Escolaridade> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (escolaridade.ID != 0)
                        {

                            resultado = ((from t in resultado
                                          where
                                          t.ID == escolaridade.ID
                                          select t).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(escolaridade.Nome))
                        {

                            resultado = ((from t in resultado
                                          where
                                          t.Nome.Contains(escolaridade.Nome)
                                          select t).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (escolaridade.Status.HasValue)
                        {

                            resultado = ((from t in resultado
                                          where
                                          t.Status.HasValue && t.Status.Value == escolaridade.Status.Value
                                          select t).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        break;
                    }
                #endregion
                #region Case Ou
                case TipoPesquisa.Ou:
                    {
                        if (escolaridade.ID != 0)
                        {

                            resultado.AddRange((from t in Consultar()
                                                where
                                                t.ID == escolaridade.ID
                                                select t).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(escolaridade.Nome))
                        {

                            resultado.AddRange((from t in Consultar()
                                                where
                                                t.Nome.Contains(escolaridade.Nome)
                                                select t).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (escolaridade.Status.HasValue)
                        {

                            resultado.AddRange((from t in Consultar()
                                                where
                                                t.Status.HasValue && t.Status.Value == escolaridade.Status.Value
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

        public void Incluir(Escolaridade escolaridade)
        {
            try
            {
                db.Escolaridade.InsertOnSubmit(escolaridade);
            }
            catch (Exception)
            {

                throw new EscolaridadeNaoIncluidaExcecao();
            }
        }

        public void Excluir(Escolaridade escolaridade)
        {
            try
            {
                Escolaridade escolaridadeAux = new Escolaridade();
                escolaridadeAux.ID = escolaridade.ID;

                List<Escolaridade> resultado = this.Consultar(escolaridadeAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new EscolaridadeNaoExcluidaExcecao();

                escolaridadeAux = resultado[0];

                db.Escolaridade.DeleteOnSubmit(escolaridadeAux);
            }
            catch (Exception)
            {

                throw new EscolaridadeNaoExcluidaExcecao();
            }
        }

        public void Alterar(Escolaridade escolaridade)
        {
            try
            {
                Escolaridade escolaridadeAux = new Escolaridade();
                escolaridadeAux.ID = escolaridade.ID;

                List<Escolaridade> resultado = this.Consultar(escolaridadeAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new EscolaridadeNaoAlteradaExcecao();

                escolaridadeAux = resultado[0];
                escolaridadeAux.Nome = escolaridade.Nome;
                escolaridadeAux.Status = escolaridade.Status;


                Confirmar();
            }
            catch (Exception)
            {

                throw new EscolaridadeNaoAlteradaExcecao();
            }
        }

        public void Confirmar()
        {
            db.SubmitChanges();
        }

        #endregion

        #region Construtor
        public EscolaridadeRepositorio()
        {
            Conexao conexao = new Conexao();
            db = new EmprestimoEntities(new MySqlConnection(conexao.ToString()));

        }
        #endregion


    }
}