using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;

using RegraNegocio.ModuloTipoEmprestimo.Excecoes;
using RegraNegocio.ModuloBasico.Enums;
using RegraNegocio.ModuloBasico.VOs;

namespace RegraNegocio.ModuloTipoEmprestimo.Repositorios
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

                        if (tipoEmprestimo.Parcela.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Parcela.HasValue && c.Parcela.Value == tipoEmprestimo.Parcela.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(tipoEmprestimo.Agencia))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Agencia.Contains(tipoEmprestimo.Agencia)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(tipoEmprestimo.Banco))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Banco.Contains(tipoEmprestimo.Banco)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(tipoEmprestimo.Conta))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Conta.Contains(tipoEmprestimo.Conta)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(tipoEmprestimo.Cpf))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Cpf.Contains(tipoEmprestimo.Cpf)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (tipoEmprestimo.Tipo != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Tipo == tipoEmprestimo.Tipo
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }


                        if (tipoEmprestimo.Parcela.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Parcela.HasValue && c.Parcela.Value == tipoEmprestimo.Parcela.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (tipoEmprestimo.NumTipoEmprestimo.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.NumTipoEmprestimo.HasValue && c.NumTipoEmprestimo.Value == tipoEmprestimo.NumTipoEmprestimo.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (tipoEmprestimo.Status.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Status.HasValue && c.Status.Value == tipoEmprestimo.Status.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (tipoEmprestimo.Valor.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Valor.HasValue && c.Valor.Value == tipoEmprestimo.Valor.Value
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

                        if (tipoEmprestimo.Parcela.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Parcela.HasValue && c.Parcela.Value == tipoEmprestimo.Parcela.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(tipoEmprestimo.Agencia))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Agencia.Contains(tipoEmprestimo.Agencia)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(tipoEmprestimo.Banco))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Banco.Contains(tipoEmprestimo.Banco)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(tipoEmprestimo.Conta))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Conta.Contains(tipoEmprestimo.Conta)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(tipoEmprestimo.Cpf))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Cpf.Contains(tipoEmprestimo.Cpf)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (tipoEmprestimo.Tipo != 0)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Tipo == tipoEmprestimo.Tipo
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }


                        if (tipoEmprestimo.Parcela.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Parcela.HasValue && c.Parcela.Value == tipoEmprestimo.Parcela.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (tipoEmprestimo.NumTipoEmprestimo.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.NumTipoEmprestimo.HasValue && c.NumTipoEmprestimo.Value == tipoEmprestimo.NumTipoEmprestimo.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (tipoEmprestimo.Status.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Status.HasValue && c.Status.Value == tipoEmprestimo.Status.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (tipoEmprestimo.Valor.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Valor.HasValue && c.Valor.Value == tipoEmprestimo.Valor.Value
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
                db.TipoEmprestimo.InsertOnSubmit(tipoEmprestimo);
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

                db.TipoEmprestimo.DeleteOnSubmit(tipoEmprestimoAux);

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

                tipoEmprestimoAux.Agencia = tipoEmprestimo.Agencia;
                tipoEmprestimoAux.Banco = tipoEmprestimo.Banco;
                tipoEmprestimoAux.Conta = tipoEmprestimo.Conta;
                tipoEmprestimoAux.Cpf = tipoEmprestimo.Cpf;
                tipoEmprestimoAux.NumTipoEmprestimo = tipoEmprestimo.NumTipoEmprestimo;
                tipoEmprestimoAux.Parcela = tipoEmprestimo.Parcela;
                tipoEmprestimoAux.Status = tipoEmprestimo.Status;
                tipoEmprestimoAux.Tipo = tipoEmprestimo.Tipo;
                tipoEmprestimoAux.Valor = tipoEmprestimo.Valor;

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
            db.SubmitChanges();
        }

        #endregion

        #region Construtor
        public TipoEmprestimoRepositorio()
        {
            Conexao conexao = new Conexao();
            db = new EmprestimoEntities(new MySqlConnection(conexao.ToString()));

        }
        #endregion


    }
}