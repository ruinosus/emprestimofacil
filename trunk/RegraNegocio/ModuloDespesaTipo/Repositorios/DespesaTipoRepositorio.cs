using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using MySql.Data.MySqlClient;
using Negocios.ModuloDespesaTipo.Excecoes;
using Negocios.ModuloBasico.Enums;
using Negocios.ModuloBasico.VOs;

namespace Negocios.ModuloDespesaTipo.Repositorios
{
    public class DespesaTipoRepositorio : IDespesaTipoRepositorio
    {
        #region Atributos

        ColegioDB db;

        #endregion

        #region Métodos da Interface

        public List<DespesaTipo> Consultar()
        {
            return db.DespesaTipo.ToList();
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

                        if (!string.IsNullOrEmpty(despesaTipo.Nome))
                        {

                            resultado = ((from t in resultado
                                          where
                                          t.Nome.Contains(despesaTipo.Nome)
                                          select t).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (despesaTipo.Status.HasValue)
                        {

                            resultado = ((from t in resultado
                                          where
                                          t.Status.HasValue && t.Status.Value == despesaTipo.Status.Value
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

                        if (!string.IsNullOrEmpty(despesaTipo.Nome))
                        {

                            resultado.AddRange((from t in Consultar()
                                                where
                                                t.Nome.Contains(despesaTipo.Nome)
                                                select t).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (despesaTipo.Status.HasValue)
                        {

                            resultado.AddRange((from t in Consultar()
                                                where
                                                t.Status.HasValue && t.Status.Value == despesaTipo.Status.Value
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
                db.DespesaTipo.InsertOnSubmit(despesaTipo);
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

                db.DespesaTipo.DeleteOnSubmit(despesaTipoAux);
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
                despesaTipoAux.Nome = despesaTipo.Nome;
                despesaTipoAux.Status = despesaTipo.Status;


                Confirmar();
            }
            catch (Exception)
            {

                throw new DespesaTipoNaoAlteradaExcecao();
            }
        }

        public void Confirmar()
        {
            db.SubmitChanges();
        }

        #endregion

        #region Construtor
        public DespesaTipoRepositorio()
        {
            Conexao conexao = new Conexao();
            db = new ColegioDB(new MySqlConnection(conexao.ToString()));

        }
        #endregion


    }
}