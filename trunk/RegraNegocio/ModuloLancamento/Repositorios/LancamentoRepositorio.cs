using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using MySql.Data.MySqlClient;
using RegraNegocio.ModuloLancamento.Excecoes;
using RegraNegocio.ModuloBasico.Enums;
using RegraNegocio.ModuloBasico.VOs;

namespace RegraNegocio.ModuloLancamento.Repositorios
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

                        if (lancamento.Parcela.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Parcela.HasValue && c.Parcela.Value == lancamento.Parcela.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(lancamento.Agencia))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Agencia.Contains(lancamento.Agencia)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(lancamento.Banco))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Banco.Contains(lancamento.Banco)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(lancamento.Conta))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Conta.Contains(lancamento.Conta)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(lancamento.Cpf))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Cpf.Contains(lancamento.Cpf)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (lancamento.Tipo != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Tipo == lancamento.Tipo
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }


                        if (lancamento.Parcela.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Parcela.HasValue && c.Parcela.Value == lancamento.Parcela.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (lancamento.NumLancamento.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.NumLancamento.HasValue && c.NumLancamento.Value == lancamento.NumLancamento.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (lancamento.Status.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Status.HasValue && c.Status.Value == lancamento.Status.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (lancamento.Valor.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Valor.HasValue && c.Valor.Value == lancamento.Valor.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
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

                        if (lancamento.Parcela.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Parcela.HasValue && c.Parcela.Value == lancamento.Parcela.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(lancamento.Agencia))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Agencia.Contains(lancamento.Agencia)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(lancamento.Banco))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Banco.Contains(lancamento.Banco)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(lancamento.Conta))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Conta.Contains(lancamento.Conta)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(lancamento.Cpf))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Cpf.Contains(lancamento.Cpf)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (lancamento.Tipo != 0)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Tipo == lancamento.Tipo
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }


                        if (lancamento.Parcela.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Parcela.HasValue && c.Parcela.Value == lancamento.Parcela.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (lancamento.NumLancamento.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.NumLancamento.HasValue && c.NumLancamento.Value == lancamento.NumLancamento.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (lancamento.Status.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Status.HasValue && c.Status.Value == lancamento.Status.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (lancamento.Valor.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Valor.HasValue && c.Valor.Value == lancamento.Valor.Value
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
                db.Lancamento.InsertOnSubmit(lancamento);
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

                db.Lancamento.DeleteOnSubmit(lancamentoAux);

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

                lancamentoAux.Agencia = lancamento.Agencia;
                lancamentoAux.Banco = lancamento.Banco;
                lancamentoAux.Conta = lancamento.Conta;
                lancamentoAux.Cpf = lancamento.Cpf;
                lancamentoAux.NumLancamento = lancamento.NumLancamento;
                lancamentoAux.Parcela = lancamento.Parcela;
                lancamentoAux.Status = lancamento.Status;
                lancamentoAux.Tipo = lancamento.Tipo;
                lancamentoAux.Valor = lancamento.Valor;

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
            db.SubmitChanges();
        }

        #endregion

        #region Construtor
        public LancamentoRepositorio()
        {
            Conexao conexao = new Conexao();
            db = new EmprestimoEntities(new MySqlConnection(conexao.ToString()));

        }
        #endregion


    }
}